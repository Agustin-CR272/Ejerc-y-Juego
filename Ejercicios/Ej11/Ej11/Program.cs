using System;
using System.Collections.Generic;


namespace Ej11
{
    class Program
    {
        static void Main(string[] args)
        {
            const int dineroInicial = 20000;
            Apuesta apuesta = new Apuesta(dineroInicial);

            apuesta.AgregarJugador(new Jugador("joaco"));
            apuesta.AgregarJugador(new Jugador("jatniel"));
            apuesta.AgregarJugador(new Jugador("lautaro"));

            for (int jornada = 1; jornada < 5; jornada++)
            {
                Console.WriteLine("Jornada :" + jornada);
                apuesta.jugarJornada();
            }

            Console.WriteLine("Resultados Finales");
            apuesta.MostrarResultadosFinales();
            Console.ReadKey();
        }
    }

    public interface IApuesta
    {
        void jugarJornada();
        void MostrarResultadosFinales();
    }

    public class Jugador
    {
        public string Nombre { get;  set; }
        public int Dinero { get;  set; }
        public int VecesGanadas { get;  set; }
        public (int, int) Apuesta1 { get;  set; }
        public (int, int) Apuesta2 { get;  set; }

        public Jugador(string nombre)
        {
            Nombre = nombre;
            Dinero = 2000;
            VecesGanadas = 0;
        }

        public bool PuedeApostar()
        {
            return Dinero >= 500;
        }

        public void RealizarApuesta(Random random)
        {
            Apuesta1 = (random.Next(0, 5), random.Next(0, 5));
            Apuesta2 = (random.Next(0, 5), random.Next(0, 5));
            Dinero -= 500;
        }

        public void Ganar(int WIN)
        {
            Dinero += WIN;
            VecesGanadas++;
        }

        public override string ToString()
        {
            return (Nombre + " Dinero: " + Dinero + " Veces que ganaste: " + VecesGanadas);
        }
    }

    public class Apuesta : IApuesta
    {
        private List<Jugador> jugadores;
        private int WIN;
        private Random random;

        public Apuesta(int dineroInicial)
        {
            jugadores = new List<Jugador>();
            WIN = 0;
            random = new Random();
        }

        public void AgregarJugador(Jugador jugador)
        {
            jugadores.Add(jugador);
        }

        public void jugarJornada()
        {
            WIN += jugadores.Count * 500;
            (int, int) resultadoPartido1 = (random.Next(0, 5), random.Next(0, 5));
            (int, int) resultadoPartido2 = (random.Next(0, 5), random.Next(0, 5));

            Console.WriteLine("Resultado del primer partido: " + resultadoPartido1);
            Console.WriteLine("Resultado del segundo partido: " + resultadoPartido2);

            bool hayGanador = false;
            foreach (var jugador in jugadores)
            {
                if (jugador.PuedeApostar())
                {
                    jugador.RealizarApuesta(random);
                    Console.WriteLine(jugador.Nombre + " aposto: " + jugador.Apuesta1 + " y " + jugador.Apuesta2);

                    if (jugador.Apuesta1 == resultadoPartido1 && jugador.Apuesta2 == resultadoPartido2)
                    {
                        jugador.Ganar(WIN);
                        Console.WriteLine(jugador.Nombre + " SE HIZO LA WIN DE: " + WIN + " pesos");
                        WIN = 0;
                        hayGanador = true;
                        break;
                    }
                }
            }

            if (!hayGanador)
            {
                Console.WriteLine("Nadie gano, la WIN se le suma mas plata.");
            }
        }

        public void MostrarResultadosFinales()
        {
            foreach (var jugador in jugadores)
            {
                Console.WriteLine(jugador);
            }
            Console.WriteLine("Valor de la WIN: " + WIN + " pesos");
        }
    }
}

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

            apuesta.AgregarJugador(new Jugador("Martin"));
            apuesta.AgregarJugador(new Jugador("Juan"));
            apuesta.AgregarJugador(new Jugador("Matias"));

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
        public string Nombre { get; private set; }
        public int Dinero { get; private set; }
        public int VecesGanadas { get; private set; }
        public (int, int) Apuesta1 { get; private set; }
        public (int, int) Apuesta2 { get; private set; }

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

        public void Ganar(int LAMAXWIN)
        {
            Dinero += LAMAXWIN;
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
        private int LAMAXWIN;
        private Random random;

        public Apuesta(int dineroInicial)
        {
            jugadores = new List<Jugador>();
            LAMAXWIN = 0;
            random = new Random();
        }

        public void AgregarJugador(Jugador jugador)
        {
            jugadores.Add(jugador);
        }

        public void jugarJornada()
        {
            LAMAXWIN += jugadores.Count * 500;
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
                        jugador.Ganar(LAMAXWIN);
                        Console.WriteLine(jugador.Nombre + " SE HIZO LA MAXWIN DE: " + LAMAXWIN + " pesos");
                        LAMAXWIN = 0;
                        hayGanador = true;
                        break;
                    }
                }
            }

            if (!hayGanador)
            {
                Console.WriteLine("Nadie gano, la MAXWIN se le suma mas plata.");
            }
        }

        public void MostrarResultadosFinales()
        {
            foreach (var jugador in jugadores)
            {
                Console.WriteLine(jugador);
            }
            Console.WriteLine("Valor de la MAXWIN: " + LAMAXWIN + " pesos");
        }
    }
}

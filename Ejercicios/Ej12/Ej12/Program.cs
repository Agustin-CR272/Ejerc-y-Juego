using System;
using System.Collections.Generic;

namespace Ej12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Jugador> jugadores = new List<Jugador>();

            Console.WriteLine("Introduzca el numero de jugadores (1-6): ");
            int cantidadJugadores;
            cantidadJugadores = int.Parse(Console.ReadLine());

            for (int i = 1; i <= cantidadJugadores; i++)
            {
                jugadores.Add(new Jugador(i, "Jugador" + i));
            }

            Revolver revolver = new Revolver();

            Juego juego = new Juego(jugadores, revolver);
            juego.IniciarJuego();
            Console.ReadKey();
        }
    }

    public class Revolver
    {
        private int posicionActual;
        private int posicionBala;

        public Revolver()
        {
            Random random = new Random();
            posicionActual = random.Next(1, 7);
            posicionBala = random.Next(1, 7);
        }

        public bool Disparar()
        {
            return posicionActual == posicionBala;
        }

        public void SiguienteBala()
        {
            posicionActual = (posicionActual % 6) + 1;
        }

        public override string ToString()
        {
            return ("Posicion Actual:" + posicionActual + ", Posicion de la bala: " + posicionBala);
        }
    }

    public class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Vivo { get; set; } = true;

        public Jugador(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public void DispararRevolver(Revolver revolver)
        {
            Console.WriteLine(Nombre + " apunta y dispara");
            if (revolver.Disparar())
            {
                Vivo = false;
                Console.WriteLine(Nombre + " ha muerto");
            }
            else
            {
                Console.WriteLine(Nombre + " esta vivo");
                revolver.SiguienteBala();
            }
        }
    }

    public class Juego
    {
        private List<Jugador> jugadores;
        private Revolver revolver;

        public Juego(List<Jugador> jugadores, Revolver revolver)
        {
            this.jugadores = jugadores;
            this.revolver = revolver;
        }

        public bool FinJuego()
        {
            foreach (var jugador in jugadores)
            {
                if (!jugador.Vivo)  
                {
                    return true;
                }
            }
            return false;  
        }

        public void Ronda()
        {
            while (!FinJuego())  
            {
                foreach (var jugador in jugadores)
                {
                    if (jugador.Vivo)
                    {
                        jugador.DispararRevolver(revolver);
                        if (FinJuego()) break;  
                    }
                }
            }
        }

        public void IniciarJuego()
        {
            Console.WriteLine("Iniciando el juego");
            Console.WriteLine(revolver.ToString());
            Ronda();
            Console.WriteLine("El juego ha terminado");
        }
    }
}

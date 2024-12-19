using System;
using System.Collections.Generic;

namespace Ej9
{
    internal class Program
    {
        Random random = new Random();
        static void Main(string[] args)
        {
            List<asiento> list1 = new List<asiento>();

            asiento asiento = new asiento();
            
            asiento.crearAsientos(list1);
            
            Pelicula pelicula = new Pelicula("Cars2", 90, 12, "John Lasseter");
            
            Cine cine = new Cine(pelicula, 200);
            
            Espectador espectador1 = new Espectador("joaco", 14, 41);
            Espectador espectador2 = new Espectador("jatniel", 10, 201);
            Espectador espectador3 = new Espectador("lautaro", 14, 440);
            
            asiento.sentarPersona(cine, pelicula, espectador1, list1);
            asiento.sentarPersona(cine, pelicula, espectador2, list1);
            asiento.sentarPersona(cine, pelicula, espectador3, list1);
        }

        public class Cine
        {
            public Pelicula Pelicula { get; set; }

            public int PrecioEntrada { get; set; }


            public Cine(Pelicula Pelicula, int PrecioEntrada)

            {
                this.Pelicula = Pelicula;
                this.PrecioEntrada = PrecioEntrada;
            }
        }

        public class Pelicula
        {
            public string Titulo { get; set; }
            public int Duracion { get; set; }
            public int EdadMinima { get; set; }
            public string Director { get; set; }

            public Pelicula(string Titulo, int Duracion, int EdadMinima, string Director)
            {
                this.Titulo = Titulo;
                this.Duracion = Duracion;
                this.EdadMinima = EdadMinima;
                this.Director = Director;
            }
        }

        public class Espectador
        {
            public string Nombre { get; set; }
            public int Edad { get; set; }
            public double Dinero { get; set; }

            public Espectador(string Nombre, int Edad, double Dinero)
            {
                this.Nombre = Nombre;
                this.Edad = Edad;
                this.Dinero = Dinero;
            }
        }

        public class asiento
        {
            public char columna;
            public int fila;
            public bool ocupado;
            public Espectador espectador;

            public asiento()
            {

            }
            public asiento(char columna, int fila)
            {
                this.columna = columna;
                this.fila = fila;
            }

            public void crearAsientos(List<asiento> list)
            {
                for (int fila = 8; fila >= 1; fila--)
                {
                    for (char columna = 'A'; columna < 'I'; columna++)
                    {
                        list.Add(new asiento(columna, fila));
                    }
                }
            }
            public void sentarPersona(Cine cine, Pelicula pelicula, Espectador espectador, List<asiento> list)
            {
                if (espectador.Dinero <= cine.PrecioEntrada)
                {
                    Console.WriteLine(espectador.Nombre + " NO tiene dinero");
                    return;
                }
                if (espectador.Edad <= pelicula.EdadMinima)
                {
                    Console.WriteLine(espectador.Nombre + " NO tiene la edad minima");
                    return;
                }

                foreach (asiento asiento in list)
                {
                    if (!asiento.ocupado)
                    {
                        asiento.ocupado = true;
                        asiento.espectador = espectador;
                        Console.WriteLine("Espectador " + espectador.Nombre + " se sentó en el asiento " + asiento.fila + asiento.columna);
                        return;
                    }
                }
                Console.WriteLine("No hay asientos disponibles.");
            }
        }
    }
}

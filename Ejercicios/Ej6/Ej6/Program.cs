using System;

namespace Ej6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Libro libro1 = new Libro("312", "Narnia", "autor1", 700);
            Libro libro2 = new Libro("392", "Harry Potter", "autor2", 800);

            libro1.MostrarInformacion();
            libro2.MostrarInformacion();

            if (libro1.NumPaginas > libro2.NumPaginas)
            {
                Console.WriteLine("libro " + libro1.Titulo + " tiene mas paginas");
            }
            else if (libro1.NumPaginas < libro2.NumPaginas)
            {
                Console.WriteLine("libro " + libro2.Titulo + " tiene mas paginass");
            }
            else
            {
                Console.WriteLine("Ambos tienen la misma cantidad de hojas");
            }
            Console.ReadKey();
        }

        public class Libro
        {
            public string ISBN { get; set; }
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public int NumPaginas { get; set; }

            public Libro(string ISBN, string Titulo, string Autor, int NumPaginas)
            {
                this.ISBN = ISBN;
                this.Titulo = Titulo;
                this.Autor = Autor;
                this.NumPaginas = NumPaginas;
            }

            public void MostrarInformacion()
            {
                Console.WriteLine("El libro con ISBN " + ISBN + " creado por " + Autor + " tiene " + NumPaginas + " paginas.");
            }
        }
    }
}

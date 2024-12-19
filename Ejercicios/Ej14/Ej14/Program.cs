using System;

namespace ej14
{
    class Program
    {
        static void Main(string[] args)
        {
            Producto[] productos = new Producto[]
            {
                new Perecedero("Leche", 900, 1),
                new Perecedero("Yogurt", 1500, 3),
                new NoPerecedero("Avena", 1200, "Envase"),
                new NoPerecedero("Aceite", 3000, "Envase"),
            };

            foreach (var producto in productos)
            {
                if (producto is Perecedero perecedero)
                {
                    Console.WriteLine(perecedero.Nombre + " Precio total de 5 unidades: " + perecedero.Calcular(5) + " Pesos");
                    Console.WriteLine("Días en el que va a vencer: " + perecedero.DiasQueVence);
                }
                else if (producto is NoPerecedero noPerecedero)
                {
                    Console.WriteLine(noPerecedero.Nombre + " Precio total de 5 unidades: " + noPerecedero.Calcular(5) + " Pesos");
                    Console.WriteLine("Tipo: " + noPerecedero.Tipo);
                }
            }

            Console.ReadKey();
        }
    }

    public class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public Producto(string nombre, double precio)
        {
            Nombre = nombre;
            Precio = precio;
        }

        public virtual double Calcular(int cantidad)
        {
            return Precio * cantidad;
        }
    }

    public class Perecedero : Producto
    {
        public int DiasQueVence { get; set; }

        public Perecedero(string nombre, double precio, int diasQueVence) : base(nombre, precio)
        {
            DiasQueVence = diasQueVence;
        }

        public override double Calcular(int cantidad)
        {
            double precioFinal = Precio * cantidad;

            if (DiasQueVence == 1)
            {
                precioFinal -= precioFinal * 0.75;
            }
            else if (DiasQueVence == 2)
            {
                precioFinal -= precioFinal * 0.60;
            }
            else if (DiasQueVence == 3)
            {
                precioFinal -= precioFinal * 0.50;
            }

            return precioFinal;
        }
    }

    public class NoPerecedero : Producto
    {
        public string Tipo { get; set; }

        public NoPerecedero(string nombre, double precio, string tipo): base(nombre, precio)
        {
            Tipo = tipo;
        }

        public override double Calcular(int cantidad)
        {
            return base.Calcular(cantidad);
        }
    }
}

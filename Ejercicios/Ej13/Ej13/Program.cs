using System;


namespace Ejer13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repartidor repartidor1 = new Repartidor("joaco", 23, 232, "zona 3");
            Comercial comercial1 = new Comercial("jatniel", 31, 400, 300);

            repartidor1.PLUSrepartidor();
            comercial1.PLUScomercial();

            Console.WriteLine("El salario de " + repartidor1.Nombre + " es " + repartidor1.Salario);
            Console.WriteLine("El salario de " + comercial1.Nombre + " es " + comercial1.Salario);
            Console.ReadKey();
        }

        public abstract class Empleado
        {
            public string Nombre { get; set; }
            public int Edad { get; set; }
            public int Salario { get; set; }
            public const int PLUS = 300;

            public Empleado(string nombre, int edad, int salario)
            {
                Nombre = nombre;
                Edad = edad;
                Salario = salario;
            }
        }

        public class Repartidor : Empleado
        {
            string zona { get; set; }

            public Repartidor(string Nombre, int Edad, int Salario, string zona) : base(Nombre, Edad, Salario)
            {
                this.zona = zona;

            }

            public void PLUSrepartidor()
            {
                if (Edad < 25 && zona == "zona 3")
                {
                    Salario += PLUS;
                }
            }

        }

        public class Comercial : Empleado
        {
            double comision { get; set; }

            public Comercial(string Nombre, int Edad, int Salario, double comision) : base(Nombre, Edad, Salario)
            {
                this.comision = comision;
            }

            public void PLUScomercial()
            {
                if (Edad > 30 && comision > 200)
                {
                    Salario += PLUS;
                }
            }
        }
    }
}

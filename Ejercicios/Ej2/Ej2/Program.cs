using System;

namespace Ej2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nombre: ");
            string Nombre = Console.ReadLine();
            Console.WriteLine("Edad: ");
            int Edad = int.Parse(Console.ReadLine());
            Console.WriteLine("Sexo H o M: ");
            char Sexo = char.Parse(Console.ReadLine());
            Console.WriteLine("Peso: ");
            double Peso = double.Parse(Console.ReadLine());
            Console.WriteLine("Altura: ");
            double Altura = double.Parse(Console.ReadLine());

            Persona a = new Persona(Nombre, Edad, Sexo, Peso, Altura);
            Persona b = new Persona(Nombre, Edad, Sexo);
            Persona c = new Persona();

            Console.WriteLine("El IMC es: " + a.calcularIMC());
            Console.WriteLine("El IMC es: " + b.calcularIMC());
            Console.WriteLine("El IMC es: " + c.calcularIMC());

            Console.WriteLine("Su edad es mayor?" + a.EsMayorDeEdad());
            Console.WriteLine("Su edad es mayor?" + b.EsMayorDeEdad());
            Console.WriteLine("Su edad es mayor?" + c.EsMayorDeEdad());

            a.MostrarDetalles();
            b.MostrarDetalles();
            c.MostrarDetalles();

            Console.ReadKey();
        }
    }

    public class Persona
    {
        private string Nombre { get; set; } = "";
        private int Edad { get; set; } = 0;
        private int DNI { get; }
        private char Sexo { get; set; } = 'H';
        private double Peso { get; set; } = 0;
        private double Altura { get; set; } = 0;

        public void MostrarDetalles()
        {
            Console.WriteLine(Nombre + Edad + DNI + Sexo + Peso + Altura);
        }

        public Persona()
        {

        }

        public Persona(string nombre, int edad, char sexo)
        {
            Nombre = nombre;
            Edad = edad;
            Sexo = sexo;
        }
        public void MostrarDetalles(string nombre, int edad, char sexo)
        {
            Console.WriteLine(nombre + edad + sexo);
        }

        public Persona(string nombre, int edad, char sexo, double peso, double altura)
        {
            Nombre = nombre;
            Edad = edad;
            Sexo = sexo;
            DNI = generarDNI();
            Peso = peso;
            Altura = altura;
        }

        public void MostrarDetalles(string nombre, int edad, char sexo, double peso, double altura)
        {
            Console.WriteLine(Nombre + Edad + Sexo + Peso + Altura);
        }

        public double calcularIMC()
        {
            double PesoIdeal = Peso / (Altura * Altura);
            if (PesoIdeal > 20)
            {
                return -1;
            }
            else if (PesoIdeal >= 20 && PesoIdeal <= 25)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public bool EsMayorDeEdad()
        {
            if (Edad >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void comprobarSexo(char sexo)
        {
            if (sexo == 'M')
            {
                Console.WriteLine("Mujer");
            }
            else
            {
                Console.WriteLine("Hombre");
            }
        }
        private int generarDNI()
        {

            Random rnd = new Random();

            return rnd.Next(10000000, 99999999);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Raices a = new Raices(2, 9, 10);
            a.ObtenerRaices();
            Console.ReadKey();

        }
        public class Raices
        {
            public double a;
            public double b;
            public double c;

            public Raices(double a, double b, double c)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
            public void ObtenerRaices()
            {
                if (tieneRaices())
                {
                    double raices = GetDiscriminante();
                    double raiz1 = (-b + Math.Sqrt(raices)) / (2 * a);
                    double raiz2 = (-b - Math.Sqrt(raices)) / (2 * a);
                    Console.WriteLine("Las dos raices son: " + raiz1 + " y " + raiz2);
                }
                else
                {
                    Console.WriteLine("No tiene raices");
                }
            }

            public void ObtenerRaiz()
            {
                if (tieneRaiz())
                {
                    double raiz = -b / (2 * a); Console.WriteLine("La unica raíz es: " + raiz);
                }
                else
                {
                    Console.WriteLine("No tiene raices");
                }
            }

            public double GetDiscriminante()
            {
                return (b * b) - (4 * a * c);
            }

            public bool tieneRaices()
            {
                return GetDiscriminante() >= 0;
            }

            public bool tieneRaiz()
            {
                return GetDiscriminante() == 0;
            }
        }
    }
}

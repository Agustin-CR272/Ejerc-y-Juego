using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            
        }
    }

    public class Cuenta
    {
        public double total { get; set; }
        public string titular { get; set; }
        public double cantidad { get; set; }

        public Cuenta(string titular, double cantidad)
        {
            this.titular = titular;
            this.cantidad = cantidad;
        }

        public void ingresar()
        {
            Console.WriteLine("Ingrese el monto:");
            double cantidad = double.Parse(Console.ReadLine());
            total = cantidad;
            Console.WriteLine("Ingresado correctamente.");
            Console.WriteLine("Su nuevo saldo total es " + total);
            Console.ReadKey();
        }

        public void Retirar()
        {
            Console.WriteLine("Ingrese la cantidad a retirar:");
            double retirar = double.Parse(Console.ReadLine());
            if ((total - retirar) < 0)
            {
                Console.WriteLine("No tiene saldo suficiente");
                Console.WriteLine("Su saldo disponible es de " + total);
            }
            else
            {
                total = total - retirar;
                Console.WriteLine("Su nuevo saldo es de " + total);
            }



        }
    }

}

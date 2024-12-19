using System;

namespace ej3
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cuantas contraseñas ");
            int cantidad = int.Parse(Console.ReadLine());

            Console.WriteLine("longitud de la contraseña?");
            int longitud = int.Parse(Console.ReadLine());

            for (int i = 0; i < cantidad; i++)
            {
                Password password = new Password(longitud);
                Console.WriteLine("Contraseña: " + password.getContraseña() + " - Fuerte: " + password.esFuerte());
            }

            Console.ReadKey();
        }
    }

    public class Password
    {
        private int longitud;
        private string contraseña;
        private static Random random = new Random();

        public Password()
        {
            longitud = 8;
            generarPassword();
        }

        public Password(int longitud)
        {
            this.longitud = longitud;
            generarPassword();
        }

        public void generarPassword()
        {
            string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            contraseña = "";

            for (int i = 0; i < longitud; i++)
            {
                contraseña += caracteres[random.Next(caracteres.Length)];
            }
        }

        public bool esFuerte()
        {
            int mayusculas = 0;
            int minusculas = 0;
            int numeros = 0;

            foreach (char c in contraseña)
            {
                if (c >= 'A' && c <= 'Z')
                    mayusculas++;
                else if (c >= 'a' && c <= 'z')
                    minusculas++;
                else if (c >= '0' && c <= '9')
                    numeros++;
            }

            return mayusculas > 2 && minusculas > 1 && numeros > 5;
        }

        public string getContraseña()
        {
            return contraseña;
        }

        public int getLongitud()
        {
            return longitud;
        }

        public void setLongitud(int longitud)
        {
            this.longitud = longitud;
            generarPassword();
        }
    }
}

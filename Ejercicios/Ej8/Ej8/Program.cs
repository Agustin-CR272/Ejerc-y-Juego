using System;
using System.Collections.Generic;


namespace Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Profesor profesor = new Profesor("Carlos", 40, 'M', "Matemática");
            Aula aula = new Aula("Matemáticas", profesor);

            aula.AgregarEstudiante(new Estudiante("Maria", 14, 'F', 6.5));
            aula.AgregarEstudiante(new Estudiante("Tobias", 18, 'M', 4.0));
            aula.AgregarEstudiante(new Estudiante("Matias", 17, 'M', 7.0));
            aula.AgregarEstudiante(new Estudiante("Martin", 18, 'M', 9.0));
            aula.AgregarEstudiante(new Estudiante("Juan", 17, 'M', 4.0));

            Console.Write("Ingresa el nombre del estudiante: ");
            string nombreBusqueda = Console.ReadLine();
            Estudiante estudianteEncontrado = aula.BuscarEstudiante(nombreBusqueda);
            if (estudianteEncontrado != null)
            {
                estudianteEncontrado.MostrarDetalles();
            }
            else
            {
                Console.WriteLine("No se encontro el estudiante.");
            }

            Console.Write("Ingresa el nombre del estudiante para eliminarlo: ");
            string nombreEliminar = Console.ReadLine();
            Estudiante estudianteEliminar = aula.BuscarEstudiante(nombreEliminar);
            if (estudianteEliminar != null)
            {
                aula.EliminarEstudiante(estudianteEliminar);
            }
            else
            {
                Console.WriteLine("No se encontro el estudiante.");
            }
            Console.WriteLine("Estudiantes que aprobaron:");
            aula.MostrarAprobados();
        }
    }
    public class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public char Sexo { get; set; }

        public Persona(string nombre, int edad, char sexo)
        {
            Nombre = nombre;
            Edad = edad;
            Sexo = sexo;
        }
    }

    public class Estudiante : Persona
    {
        public double Nota { get; set; }

        public Estudiante(string nombre, int edad, char sexo, double nota)
            : base(nombre, edad, sexo)
        {
            Nota = nota;
        }

        public void MostrarDetalles()
        {
            Console.WriteLine(Nombre + " Edad: " + Edad + " Genero: " + Sexo + " Calificación: " + Nota);
        }
    }

    public class Profesor : Persona
    {
        public string Materia { get; set; }

        public Profesor(string nombre, int edad, char sexo, string materia)
            : base(nombre, edad, sexo)
        {
            Materia = materia;
        }
    }

    public class Aula
    {
        public string Materia { get; set; }
        public Profesor Profesor { get; set; }
        public List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

        public Aula(string materia, Profesor profesor)
        {
            Materia = materia;
            Profesor = profesor;
        }

        public void AgregarEstudiante(Estudiante estudiante)
        {
            Estudiantes.Add(estudiante);
        }

        public Estudiante BuscarEstudiante(string nombre)
        {
            foreach (Estudiante e in Estudiantes)
            {
                if (e.Nombre == nombre)
                    return e;
            }
            return null;
        }

        public void EliminarEstudiante(Estudiante estudiante)
        {
            if (estudiante != null)
            {
                Estudiantes.Remove(estudiante);
                Console.WriteLine("Se eliminó a " + estudiante.Nombre);
            }
            else
            {
                Console.WriteLine("No se encontró el estudiante.");
            }
        }

        public void MostrarAprobados()
        {
            int aprobados = 0;
            foreach (Estudiante e in Estudiantes)
            {
                if (e.Nota >= 5)
                {
                    aprobados++;
                    e.MostrarDetalles();
                }
            }
            Console.WriteLine("Total aprobados:" + aprobados);
        }
    }
}

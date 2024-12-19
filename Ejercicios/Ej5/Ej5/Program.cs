using System;

namespace ej5
{
    class Program
    {
        static void Main(string[] args)
        {
            Serie[] series = new Serie[5];
            Videojuego[] videojuegos = new Videojuego[5];

            series[0] = new Serie("Breaking Bad", 3, true, "Accion y drogas", "Joaquin");
            series[1] = new Serie("Un Show Mas", "Jatniel");
            series[2] = new Serie("Stranger Things", "Lautaro");
            series[3] = new Serie("El zorro", "Juan");
            series[4] = new Serie("Los Simpson", "Agustin");

            videojuegos[0] = new Videojuego("The Last of Us", 15);
            videojuegos[1] = new Videojuego("God of War", 20);
            videojuegos[2] = new Videojuego("Warzone", 12);
            videojuegos[3] = new Videojuego("Cyberpunk 2077", 25);
            videojuegos[4] = new Videojuego("GTA 5", 65);

            series[0].entregar();
            series[2].entregar();
            videojuegos[1].entregar();
            videojuegos[3].entregar();

            int seriesEntregadas = 0;
            int videojuegosEntregados = 0;

            foreach (var serie in series)
            {
                if (serie.esEntregado())
                {
                    seriesEntregadas++;
                }
            }

            foreach (var videojuego in videojuegos)
            {
                if (videojuego.esEntregado())
                {
                    videojuegosEntregados++;
                }
            }

            Console.WriteLine("Series entregadas: " + seriesEntregadas);
            Console.WriteLine("Videojuegos entregados: " + videojuegosEntregados);

            Videojuego maxHoras = videojuegos[0];
            foreach (var videojuego in videojuegos)
            {
                if (videojuego.horasEstimadasGet() > maxHoras.horasEstimadasGet())
                {
                    maxHoras = videojuego;
                }
            }

            Serie maxTemporadas = series[0];
            foreach (var serie in series)
            {
                if (serie.numeroTemporadaGet() > maxTemporadas.numeroTemporadaGet())
                {
                    maxTemporadas = serie;
                }
            }

            Console.WriteLine("Videojuego con más horas estimadas:");
            Console.WriteLine(maxHoras);
            Console.WriteLine("Serie con más temporadas: ");
            Console.WriteLine(maxTemporadas);
        }
    }

    interface Entregable
    {
        void entregar();
        void devolver();
        bool esEntregado();
        int compareTo(Object a);

    }


    public class Serie : Entregable
    {
        string Titulo;
        int Numero_Temporadas;
        bool Entregado;
        string Genero;
        string Creador;

        public Serie()
        {
            this.Titulo = "";
            this.Numero_Temporadas = 3;
            this.Entregado = false;
            this.Genero = "";
            this.Creador = "";
        }

        public Serie(string Titulo, string Creador)
        {
            this.Titulo = Titulo;
            this.Numero_Temporadas = 3;
            this.Entregado = false;
            this.Genero = "";
            this.Creador = Creador;
        }

        public Serie(string titulo, int numero_Temporadas, bool entregado, string genero, string creador)
        {
            Titulo = titulo;
            Numero_Temporadas = numero_Temporadas;
            Entregado = false;
            Genero = genero;
            Creador = creador;
        }

        public String tituloGet()
        { return Titulo; }
        public int numeroTemporadaGet()
        { return Numero_Temporadas; }
        public String generoGet()
        { return Genero; }
        public String CreadorGet()
        { return Creador; }

        public void tituloSet(String Titulo) { this.Titulo = Titulo; }
        public void numeroTémporadasSet(int Numero_Temporadas) { this.Numero_Temporadas = Numero_Temporadas; }
        public void generoSet(String Genero) { this.Genero = Genero; }
        public void creadorSet(String Creador) { this.Creador = Creador; }

        public void entregar()
        { Entregado = true; }
        public void devolver()
        { Entregado = false; }
        public bool esEntregado()
        { return Entregado; }
        public int compareTo(object a)
        {
            if (a is Serie)
            {
                return Numero_Temporadas.CompareTo(((Serie)a).Numero_Temporadas);
            }
            return 0;
        }
        public void MostrarSerie()
        {
                Console.WriteLine(Titulo + " -- Temporadas: " + Numero_Temporadas);
        }
    }

    public class Videojuego
    {
        string titulo;
        int horas_estimadas;
        bool entregado;
        string genero;
        string compañia;

        public Videojuego()
        {
            this.titulo = ".";
            this.horas_estimadas = 10;
            this.entregado = false;
            this.genero = ".";
            this.compañia = ".";
        }

        public Videojuego(string titulo, int horas_estimadas)
        {
            this.titulo = titulo;
            this.horas_estimadas = horas_estimadas;
            this.entregado = false;
            this.genero = ".";
            this.compañia = ".";
        }

        public Videojuego(string Titulo, int Horas_estimadas, bool Entregado, string Genero, string Compañia)
        {
            titulo = Titulo;
            horas_estimadas = Horas_estimadas;
            entregado = false;
            genero = Genero;
            compañia = Compañia;
        }

        public String tituloGet()
        { return titulo; }
        public int horasEstimadasGet()
        { return horas_estimadas; }
        public String generoGet()
        { return genero; }
        public String compañiaGet()
        { return compañia; }

        public void tituloSet(String titulo)
        { this.titulo = titulo; }
        public void horasEstimadasSet(int horas_estimadas)
        { this.horas_estimadas = horas_estimadas; }
        public void generoSet(String genero)
        { this.genero = genero; }
        public void compañiaSet(String compañia)
        { this.compañia = compañia; }

        public void entregar()
        { entregado = true; }
        public void devolver()
        { entregado = false; }
        public bool esEntregado()
        { return entregado; }

        public int compareTo(object a)
        {
            if (a is Videojuego)
            {
                return horas_estimadas.CompareTo(((Videojuego)a).horas_estimadas);
            }
            return 0;
        }

        public void MostrarVideojuego()
        {
            Console.WriteLine(titulo + "-- horas: " + horas_estimadas);
        }
    }
}

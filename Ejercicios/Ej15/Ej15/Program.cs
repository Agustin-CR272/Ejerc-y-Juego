using System;

namespace Ej15
{ 
class Program
{
    static void Main(string[] args)
    {
        Almacen almacen = new Almacen(3, 4);

        Bebida agua = new AguaMineral("1", 1.5, 0.8, "AguaPura", "Manantial Azul");
        Bebida bebidaAzucarada = new BebidaAzucarada("2", 2.0, 1.5, "Coca-Cola", 10.5, true);
        Bebida otraBebidaAzucarada = new BebidaAzucarada("3", 1.0, 1.0, "Fanta", 11.0, false);

        almacen.AgregarProducto(agua);
        almacen.AgregarProducto(bebidaAzucarada);
        almacen.AgregarProducto(otraBebidaAzucarada);
        almacen.MostrarInformacion();

        Console.WriteLine("Precio total del almacen: $" + almacen.CalcularPrecioTotal());

        Console.WriteLine("Precio total de la marca Coca-Cola: $" + almacen.CalcularPrecioMarca("Coca-Cola"));

        Console.WriteLine("Precio total de la estantería 1: $" + almacen.CalcularPrecioEstanteria(1));

        almacen.EliminarProducto("2");

        Console.WriteLine("\nInformación después de eliminar al producto:");
        almacen.MostrarInformacion();
        Console.ReadKey();
    }
}

public class Bebida
{
    public string Id { get; set; }
    public double Litros { get; set; }
    public double Precio { get; set; }
    public string Marca { get; set; }

    public Bebida(string id, double litros, double precio, string marca)
    {
        Id = id;
        Litros = litros;
        Precio = precio;
        Marca = marca;
    }

    public virtual double CalcularPrecio()
    {
        return Precio * Litros;
    }

    public virtual string MostrarInformacion()
    {
        return ("ID: " + Id + ", marca: " + Marca + ", litros: " + Litros + ", precio: $" + Precio);
    }
}

public class AguaMineral : Bebida
{
    public string Origen { get; set; }

    public AguaMineral(string id, double litros, double precio, string marca, string origen) : base(id, litros, precio, marca)
    {
        Origen = origen;
    }

    public override string MostrarInformacion()
    {
        return (base.MostrarInformacion() + ", Origen: " + Origen);
    }
}

public class BebidaAzucarada : Bebida
{
    public double PorcentajeAzucar { get; set; }
    public bool TienePromocion { get; set; }

    public BebidaAzucarada(string id, double litros, double precio, string marca, double porcentajeAzucar, bool tienePromocion) : base(id, litros, precio, marca)
    {
        PorcentajeAzucar = porcentajeAzucar;
        TienePromocion = tienePromocion;
    }

    public override double CalcularPrecio()
    {
        if (TienePromocion)
        {
            return base.CalcularPrecio() * 0.9;
        }
        return base.CalcularPrecio();
    }

        public override string MostrarInformacion()
        {
            string promocion;
            if (TienePromocion)
            {
                promocion = "Sí";
            }
            else
            {
                promocion = "No";
            }
            return base.MostrarInformacion() + ", Azúcar: " + PorcentajeAzucar + "%, Promoción: " + promocion;
        }
    }

    public class Almacen
{
    private Bebida[,] estanteria;
    private int filas;
    private int columnas;

    public Almacen(int filas, int columnas)
    {
        this.filas = filas;
        this.columnas = columnas;
        estanteria = new Bebida[filas, columnas];
    }

    public bool AgregarProducto(Bebida bebida)
    {
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                if (estanteria[i, j] == null)
                {
                    estanteria[i, j] = bebida;
                    return true;
                }
            }
        }
        return false;
    }

    public bool EliminarProducto(string id)
    {
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                if (estanteria[i, j] != null && estanteria[i, j].Id == id)
                {
                    estanteria[i, j] = null;
                    return true;
                }
            }
        }
        return false;
    }

    public double CalcularPrecioTotal()
    {
        double total = 0;
        foreach (var bebida in estanteria)
        {
            if (bebida != null)
            {
                total += bebida.CalcularPrecio();
            }
        }
        return total;
    }

    public double CalcularPrecioMarca(string marca)
    {
        double total = 0;
        foreach (var bebida in estanteria)
        {
            if (bebida != null && bebida.Marca == marca)
            {
                total += bebida.CalcularPrecio();
            }
        }
        return total;
    }

    public double CalcularPrecioEstanteria(int columna)
    {
            if (columna < 0 || columna >= columnas)
            {
                Console.WriteLine("Estanteria invalidada");
                return 0;
            }
        double total = 0;
        for (int i = 0; i < filas; i++)
        {
            if (estanteria[i, columna] != null)
            {
                total += estanteria[i, columna].CalcularPrecio();
            }
        }
        return total;
    }

    public void MostrarInformacion()
    {
        foreach (var bebida in estanteria)
        {
            if (bebida != null)
            {
                Console.WriteLine(bebida.MostrarInformacion());
            }
        }
    }
}
}
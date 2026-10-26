using System;
using System.Collections.Generic;
using System.IO;

class CuentaBancaria
{
    private string titular;
    private int saldo;

    public CuentaBancaria(string titular, int saldoInicial)
    {
        this.titular = titular;
        this.saldo = saldoInicial;
    }

    public int Saldo
    {
        get { return saldo; }
    }

    public string Titular
    {
        get { return titular; }
    }

    public void Depositar(int monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("El deposito debe ser mayor a 0");
            return;
        }
        saldo += monto;
        Console.WriteLine("Deposito de " + monto + " Bs. Saldo: " + saldo + " Bs");
    }

    public void Retirar(int monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("El retiro debe ser mayor a 0");
            return;
        }
        if (monto > saldo)
        {
            Console.WriteLine("Saldo insuficiente. Saldo: " + saldo + " Bs");
            return;
        }
        saldo -= monto;
        Console.WriteLine("Retiro de " + monto + " Bs. Saldo: " + saldo + " Bs");
    }

    public void MostrarResumen()
    {
        Console.WriteLine("Cuenta de " + titular + " | Saldo final: " + saldo + " Bs");
    }
}

class Libro
{
    private string titulo;
    private bool disponible;

    public Libro(string titulo)
    {
        this.titulo = titulo;
        this.disponible = true;
    }

    public string Titulo
    {
        get { return titulo; }
    }

    public bool Disponible
    {
        get { return disponible; }
    }

    public bool Prestar()
    {
        if (!disponible)
        {
            return false;
        }
        disponible = false;
        return true;
    }
}

class Contacto
{
    private string nombre;
    private string telefono;

    public Contacto(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
    }

    public string ALinea()
    {
        return nombre + ";" + telefono;
    }
}

class Videojuego
{
    private string titulo;
    private int precio;
    private int stock;

    public Videojuego(string titulo, int precio, int stock)
    {
        this.titulo = titulo;
        Precio = precio; 
        this.stock = stock;
    }

    public string Titulo
    {
        get { return titulo; }
    }

    public int Stock
    {
        get { return stock; }
    }

    public int Precio
    {
        get { return precio; }
        set
        {

            if (value < 0) throw new ArgumentOutOfRangeException("El precio no puede ser negativo");
            precio = value;
        }
    }

    public void Comprar(int cantidad)
    {
        stock += cantidad;
        Console.WriteLine("Se añadieron " + cantidad + " unidades de " + titulo + " al inventario.");
    }

    public void Vender(int cantidad)
    {
        if (cantidad > stock)
        {
            Console.WriteLine("No hay copias suficientes de " + titulo);
            return;
        }
        stock -= cantidad;
        Console.WriteLine("Vendido: " + cantidad + " unidades de " + titulo);
    }

    public string ALinea()
    {
        return titulo + ";" + precio + ";" + stock;
    }
}

class Program
{
    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine();
            Console.WriteLine("===== TAREA 7: CLASES Y ARCHIVOS =====");
            Console.WriteLine("Estudiante: Josias Gabriel Vargas Merida");
            Console.WriteLine("1. Cuenta bancaria");
            Console.WriteLine("2. Prestamo de libros");
            Console.WriteLine("3. Agenda de contactos con archivo");
            Console.WriteLine("4. Mi propia clase");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opcion: ");
            try
            {
                opcion = int.Parse(Console.ReadLine());
            }
            catch (Exception)   // si escribe letras, la opcion no vale
            {
                opcion = -1;
            }

            switch (opcion)
            {
                case 1: Ejercicio1(); break;
                case 2: Ejercicio2(); break;
                case 3: Ejercicio3(); break;
                case 4: Ejercicio4(); break;
                case 0: Console.WriteLine("Hasta luego"); break;
                default: Console.WriteLine("Opcion no valida"); break;
            }
        } while (opcion != 0);
    }

    // Ejercicio 1: Cuenta bancaria
    static void Ejercicio1()
    {
        Console.Write("Ingrese el titular: ");
        string titular = Console.ReadLine();
        Console.Write("Ingrese el saldo inicial: ");
        int saldoInicial = int.Parse(Console.ReadLine());

        CuentaBancaria cuenta = new CuentaBancaria(titular, saldoInicial);

        Console.Write("Ingrese monto a depositar: ");
        int deposito = int.Parse(Console.ReadLine());
        cuenta.Depositar(deposito);

        Console.Write("Ingrese monto a retirar: ");
        int retiro = int.Parse(Console.ReadLine());
        cuenta.Retirar(retiro);

        cuenta.MostrarResumen();
    }

    // Ejercicio 2: Prestamo de libros
    static void Ejercicio2()
    {
        List<Libro> biblioteca = new List<Libro>();
        biblioteca.Add(new Libro("El Principito"));
        biblioteca.Add(new Libro("Don Quijote"));
        biblioteca.Add(new Libro("Rayuela"));

        for (int i = 0; i < 2; i++)
        {
            Console.Write("Ingrese el titulo del libro " + (i + 1) + ": ");
            string buscado = Console.ReadLine();

            Libro encontrado = null;
            foreach (Libro l in biblioteca)
            {
                if (l.Titulo.ToLower() == buscado.ToLower())
                {
                    encontrado = l;
                    break;
                }
            }

            if (encontrado == null)
            {
                Console.WriteLine("No existe el libro " + buscado);
            }
            else
            {
                if (encontrado.Prestar())
                {
                    Console.WriteLine("Prestado: " + encontrado.Titulo);
                }
                else
                {
                    Console.WriteLine(encontrado.Titulo + " ya esta prestado");
                }
            }
        }

        Console.WriteLine("Estado de la biblioteca:");
        foreach (Libro l in biblioteca)
        {
            string estado = l.Disponible ? "Disponible" : "Prestado";
            Console.WriteLine(l.Titulo + " - " + estado);
        }
    }

    // Ejercicio 3: Agenda de contactos con archivo
    static void Ejercicio3()
    {
        Console.Write("Cantidad de contactos: ");
        int cantidad = int.Parse(Console.ReadLine());

        List<Contacto> contactos = new List<Contacto>();

        for (int i = 0; i < cantidad; i++)
        {
            Console.Write("Nombre " + (i + 1) + ": ");
            string nombre = Console.ReadLine();
            Console.Write("Telefono " + (i + 1) + ": ");
            string telefono = Console.ReadLine();

            contactos.Add(new Contacto(nombre, telefono));
        }

        List<string> lineas = new List<string>();
        foreach (Contacto c in contactos)
        {
            lineas.Add(c.ALinea());
        }

        File.WriteAllLines("contactos.txt", lineas);
        Console.WriteLine("Contactos guardados: " + cantidad);

        Console.WriteLine("Leyendo contactos.txt:");
        string[] archivoLineas = File.ReadAllLines("contactos.txt");
        foreach (string linea in archivoLineas)
        {
            string[] partes = linea.Split(';');
            if (partes.Length == 2)
            {
                Console.WriteLine(partes[0] + " - Tel: " + partes[1]);
            }
        }
    }

    // Ejercicio 4: Mi propia clase
    static void Ejercicio4()
    {
        // escribe aqui tu codigo
    }
}


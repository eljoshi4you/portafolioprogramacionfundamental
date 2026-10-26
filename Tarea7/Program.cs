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
        Precio = precio; // Usa la propiedad para validar
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
            // Validación requerida por el ejercicio 4
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
            Console.WriteLine("Estudiante: Tu Nombre Completo");
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
        // escribe aqui tu codigo
    }

    // Ejercicio 3: Agenda de contactos con archivo
    static void Ejercicio3()
    {
        // escribe aqui tu codigo
    }

    // Ejercicio 4: Mi propia clase
    static void Ejercicio4()
    {
        // escribe aqui tu codigo
    }
}


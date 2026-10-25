using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

static class Validador
{
    public static int LeerEntero(string mensaje, int min, int max)
    {
        while (true)
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine();
            int numero;
            if (int.TryParse(texto, out numero) && numero >= min && numero <= max)
            {
                return numero;
            }
            Console.WriteLine("Dato invalido. Escribe un numero entre " + min + " y " + max);
        }
    }

    public static string LeerTexto(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(texto))
            {
                return texto.Trim();
            }
            Console.WriteLine("El texto no puede estar vacio");
        }
    }
    public static bool LeerSiNo(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine().Trim().ToLower();
            if (texto == "s")
            {
                return true;
            }
            if (texto == "n")
            {
                return false;
            }
            Console.WriteLine("Responde solo s o n");
        }
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
            Console.WriteLine("===== TAREA 5: VALIDACION =====");
            Console.WriteLine("Estudiante:Josias Gabriel Vargas Merida");
            Console.WriteLine("1. Registro de notas validado");
            Console.WriteLine("2. Carrito de compras");
            Console.WriteLine("3. Calculadora con historial");
            Console.WriteLine("4. Fila de la cafeteria");
            Console.WriteLine("0. Salir");
            opcion = Validador.LeerEntero("Elige una opcion: ", 0, 4);

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

    // Ejercicio 1: Registro de notas validado
    static void Ejercicio1()
    {
        
            int suma = 0;
            int aprobados = 0;
            int mayor = -1; 

            int n = Validador.LeerEntero("",1, 10);

            for (int i = 0; i < n; i++)
            {
               
                int nota = Validador.LeerEntero("",0, 100);

                
                suma += nota;

                
                if (nota >= 51)
                {
                    aprobados++;
                }

                if (nota > mayor)
                {
                    mayor = nota;
                }
            }

            Console.WriteLine($"Suma de notas: {suma}");
            Console.WriteLine($"Aprobados: {aprobados} de {n}");
            Console.WriteLine($"Nota mas alta: {mayor}");
        
    }
            

    // Ejercicio 2: Carrito de compras
    static void Ejercicio2()
    {
        int total = 0;
        int productos = 0;
        bool otro;

        do
        {
            
            string nombre = Validador.LeerTexto("");
            int precio = Validador.LeerEntero("", 1, 1000);
            int cantidad = Validador.LeerEntero("", 1, 50);

            int subtotal = precio * cantidad;

            Console.WriteLine($"{nombre}: {cantidad} x {precio} = {subtotal} Bs");

            total += subtotal;
            productos++;
            
            otro = Validador.LeerSiNo("Agregar otro producto? (s/n) ");

        } while (otro);

        Console.WriteLine($"Productos distintos: {productos}");
        Console.WriteLine($"Total a pagar: {total} Bs");
    }


    static void Ejercicio3()
    {
        // escribe aqui tu codigo
    }

    // Ejercicio 4: Fila de la cafeteria
    static void Ejercicio4()
    {
        // escribe aqui tu codigo
    }
}


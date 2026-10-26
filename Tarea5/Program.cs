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

        Stack<int> resultados = new Stack<int>();
        int opcionSubmenu;

        do
        {
            Console.WriteLine("1. Sumar 2. Ver ultimo resultado 3. Borrar ultimo 4. Salir");
            opcionSubmenu = Validador.LeerEntero("Elige una opcion: ", 1, 4);

            switch (opcionSubmenu)
            {
                case 1: 
                    int a = Validador.LeerEntero("", -1000, 1000);
                    int b = Validador.LeerEntero("", -1000, 1000);
                    int r = a + b;

                    Console.WriteLine($"{a} + {b} = {r}");
                    resultados.Push(r); 
                    break;

                case 2: 
                    if (resultados.Count > 0)
                    {
                        Console.WriteLine($"Ultimo resultado: {resultados.Peek()}");
                    }
                    else
                    {
                        Console.WriteLine("No hay resultados");
                    }
                    break;

                case 3: 
                    if (resultados.Count > 0)
                    {
                        int borrado = resultados.Pop();
                        Console.WriteLine($"Se borro: {borrado}");
                    }
                    else
                    {
                        Console.WriteLine("No hay resultados para borrar");
                    }
                    break;

                case 4: 
                    Console.WriteLine($"Resultados guardados: {resultados.Count}");
                    break;
            }

        } while (opcionSubmenu != 4);
    }

    // Ejercicio 4: Fila de la cafeteria
    static void Ejercicio4()
    {
        Queue<string> fila = new Queue<string>();
        int fichas = 0;
        int atendidos = 0;
        int opcionSubmenu;

        do
        {
            Console.WriteLine("1. Sacar ficha 2. Atender 3. Ver fila 4. Salir");
            opcionSubmenu = Validador.LeerEntero("Elige una opcion: ", 1, 4);

            switch (opcionSubmenu)
            {
                case 1: 
                    string nombre = Validador.LeerTexto("");
                    fichas++; 
                    fila.Enqueue(nombre);
                    Console.WriteLine($"Ficha {fichas} para {nombre}");
                    break;

                case 2: 
                    if (fila.Count > 0)
                    {
                        string clienteAtendido = fila.Dequeue();
                        Console.WriteLine($"Atendiendo a {clienteAtendido}");
                        atendidos++;
                    }
                    else
                    {
                        Console.WriteLine("No hay nadie en la fila");
                    }
                    break;

                case 3: 
                    Console.WriteLine($"Personas en la fila: {fila.Count}");
                    break;

                case 4: 
                    Console.WriteLine($"Atendidos hoy: {atendidos}");
                    break;
            }

        } while (opcionSubmenu != 4);
    }
}


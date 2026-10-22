using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Program
{
    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine();
            Console.WriteLine("===== TAREA 4: EXCEPCIONES =====");
            Console.WriteLine("Estudiante:Josias Gabriel vargas Merida");
            Console.WriteLine("1. Division segura");
            Console.WriteLine("2. Consulta segura de notas");
            Console.WriteLine("3. Cola de atencion en el consultorio");
            Console.WriteLine("4. Registro de edad");
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

    // Ejercicio 1: Division segura
    static void Ejercicio1()
    {

        try
        {

            int a = int.Parse(Console.ReadLine());

            int b = int.Parse(Console.ReadLine());

            int resultado = a / b;
            Console.WriteLine($"Resultado: {resultado}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: debes escribir numeros enteros");

        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: no se puede dividir entre cero");
        }
        finally
        {
            Console.WriteLine("Operacion finalizada");
        }
    }

 // Ejercicio 2: Consulta segura de notas
    static void Ejercicio2()
    {
        // escribe aqui tu codigo
    }

    // Ejercicio 3: Cola de atencion en el consultorio
    static void Ejercicio3()
    {
        // escribe aqui tu codigo
    }

    // Ejercicio 4: Registro de edad
    static void Ejercicio4()
    {
        // escribe aqui tu codigo
    }
}


         
      


   
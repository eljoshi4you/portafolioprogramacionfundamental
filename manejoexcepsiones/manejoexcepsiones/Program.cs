try
{
    Console.WriteLine("cantidad de productos");
    int cantidad = int.Parse(Console.ReadLine());
    Console.WriteLine("el doble es: " + cantidad * 2);
}
catch
{
    Console.WriteLine("agarramos un error");
}
finally
{
    Console.WriteLine("aqui termino la prueba");
}

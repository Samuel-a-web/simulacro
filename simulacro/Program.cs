using System;
using System.Collections.Generic;
using System.IO;

// Apartado 2.1 - Trabajar con la lista
var lista = new List<Libro>();

lista.Add(new Libro("1984", "George Orwell", 1949, true));
lista.Add(new Libro("El Quijote", "Miguel de Cervantes", 1605, false));
lista.Add(new Libro("Animal Farm", "George Orwell", 1945, true));

Console.WriteLine("Todos los libros:");
foreach (var libro in lista)
{
    Console.WriteLine(libro.ToString());
}

Console.WriteLine();
Console.WriteLine("Libros cuyo autor contiene 'Orwell':");
foreach (var libro in lista)
{
    if (libro.getAutor().Contains("Orwell"))
    {
        Console.WriteLine(libro.ToString());
    }
}

// Apartado 2.2 - Fecha de registro
Console.WriteLine();
Console.WriteLine("Fecha actual: " + DateTime.Now.ToShortDateString());

// Apartado 2.3 - Guardar en fichero
string ruta = Path.Combine(AppContext.BaseDirectory, "libros.txt");
guardarLibros(lista, ruta);
Console.WriteLine($"Libros guardados en: {ruta}");

static void guardarLibros(List<Libro> lista, string ruta)
{
    using var sw = new StreamWriter(ruta, false);
    foreach (var libro in lista)
    {
        sw.WriteLine($"{libro.getTitulo()};{libro.getAutor()};{libro.getAnyo()};{libro.isDisponible()}");
    }
}

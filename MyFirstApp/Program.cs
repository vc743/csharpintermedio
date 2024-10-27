using System;
using System.Collections.Generic;
using System.Linq;

public class Producto
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int CantidadStock { get; set; }
}

public class Inventario
{
    private List<Producto> productos = new List<Producto>();

    // Crear nuevo producto
    public void CrearProducto(int id, string nombre, decimal precio, int cantidadStock)
    {
        productos.Add(new Producto { ID = id, Nombre = nombre, Precio = precio, CantidadStock = cantidadStock });
        Console.WriteLine("Producto añadido exitosamente.");
    }

    // Mostrar lista de productos
    public void MostrarProductos()
    {
        Console.WriteLine("Lista de Productos:");
        foreach (var producto in productos)
        {
            Console.WriteLine($"ID: {producto.ID}, Nombre: {producto.Nombre}, Precio: {producto.Precio}, Stock: {producto.CantidadStock}");
        }
    }

    private Producto BuscarProducto(Func<Producto, bool> filtro)
    {
        return productos.FirstOrDefault(filtro);
    }

    // Buscar producto por nombre
    public Producto BuscarProductoPorNombre(string nombre)
    {
        return BuscarProducto(p => p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
    }

    //Buscar producto por ID
    public Producto BuscarProductoPorID(int id)
    {
        return BuscarProducto(p => p.ID == id);
    }

    // Actualizar precio del producto
    public void ActualizarPrecioProducto(int id, decimal nuevoPrecio)
    {
        var producto = BuscarProductoPorID(id);

        if (producto == null)
        {
            Console.WriteLine("Producto no encontrado.");
            return;
        }

        producto.Precio = nuevoPrecio;
        Console.WriteLine($"El precio del producto con ID {id} ha sido actualizado a {nuevoPrecio:C}.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Inventario inventario = new Inventario();

        // Crear productos (simplificado)
        inventario.CrearProducto(1, "Laptop", 1500, 10);
        inventario.CrearProducto(2, "Mouse", 20, 100);

        // Mostrar productos
        inventario.MostrarProductos();

        // Buscar producto
        Console.WriteLine("Ingrese el nombre del producto a buscar:");
        string nombreProducto = Console.ReadLine();
        var producto = inventario.BuscarProductoPorNombre(nombreProducto);

        if (producto == null)
        {
            Console.WriteLine("Producto no encontrado.");
            return;
        }

        Console.WriteLine($"Producto encontrado: {producto.Nombre} - Precio: {producto.Precio:C}");

        // Actualizar precio
        Console.WriteLine("Ingrese el ID del producto a actualizar:");
        int idProducto = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingrese el nuevo precio:");
        decimal nuevoPrecio = Convert.ToDecimal(Console.ReadLine());
        inventario.ActualizarPrecioProducto(idProducto, nuevoPrecio);

        // Mostrar productos actualizados
        inventario.MostrarProductos();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp.Refactorizar
{
    public class Inventario
    {
        private List<Producto> productos = new List<Producto>();

        // Verifica si el producto existe
        private bool ProductoExiste(int id)
        {
            return productos.Any(p => p.ID == id);
        }

        // Verifica si hay productos en el inventario
        private bool HayProductosEnInvetario()
        {
            return productos.Any();
        }

        // Crear nuevo producto
        public void CrearProducto(int id, string nombre, decimal precio, int cantidadStock)
        {
            if (ProductoExiste(id))
            {
                Console.WriteLine("El producto ya existe.");
            }
            else
            {
                productos.Add(new Producto { ID = id, Nombre = nombre, Precio = precio, CantidadStock = cantidadStock });
                Console.WriteLine("Producto añadido exitosamente.");
            }
        }

        // Mostrar lista de productos
        public void MostrarProductos()
        {
            
            if (HayProductosEnInvetario())
            {
                Console.WriteLine("Lista de Productos:");
                foreach (var producto in productos)
                {
                    Console.WriteLine($"ID: {producto.ID}, Nombre: {producto.Nombre}, Precio: {producto.Precio}, Stock: {producto.CantidadStock}");
                }
            }
            else
            {
                Console.WriteLine("No hay productos en el inventario.");
            }

        }

        // Buscar producto por nombre
        public Producto BuscarProductoPorNombre(string nombre)
        {
            return productos.FirstOrDefault(p => p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
        }

        // Actualizar precio del producto
        public void ActualizarPrecioProducto(int id, decimal nuevoPrecio)
        {
            if (ProductoExiste(id))
            {
                var producto = productos.FirstOrDefault(p => p.ID == id);
                producto.Precio = nuevoPrecio;
                Console.WriteLine($"El precio del producto con ID {id} ha sido actualizado a {nuevoPrecio:C}.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }
    }
}

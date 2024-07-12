using System;
using Ejercicio2.Models;

namespace Ejercicio2.Servicios
{
	public class ProductoServicio
	{
        
      private readonly List<Producto> _productos;
      private int _nextId;
      
      public ProductoServicio()
      {
          _productos = new List<Producto>();
          _nextId = 1;
      }
      
      public List<Producto> ObtenerTodos()
      {
          return _productos;
      }
      
     
      public Producto ObtenerPorId(int id)
      {
          Producto productoEncontrado = null;

          foreach (Producto producto in _productos)
          {
              if (producto.Id == id)
              {
                  productoEncontrado = producto;
                  break;
              }
          }

          return productoEncontrado;
      }
        public void Agregar(Producto producto)
      {
          producto.Id = _nextId++;
          _productos.Add(producto);
      }
      
      public void Actualizar(int id, Producto producto)
      {
          var productoExistente = ObtenerPorId(id);
          if (productoExistente != null)
          {
              productoExistente.Nombre = producto.Nombre;
              productoExistente.Descripcion = producto.Descripcion;
              productoExistente.Precio = producto.Precio;
          }
      }
      
      public void Eliminar(int id)
      {
          var producto = ObtenerPorId(id);
          if (producto != null)
          {
              _productos.Remove(producto);
          }
      }
      
    }
}


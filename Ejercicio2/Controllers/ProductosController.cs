using System;
using Ejercicio2.Models;
using Ejercicio2.Servicios;
using Microsoft.AspNetCore.Mvc;


namespace Ejercicio2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductoServicio _productoServicio;

        public ProductosController(ProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Producto>> ObtenerProductos()
        {
            return _productoServicio.ObtenerTodos();
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> ObtenerProducto(int id)
        {
            var producto = _productoServicio.ObtenerPorId(id);
            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        [HttpPost]
        public ActionResult<Producto> CrearProducto(Producto producto)
        {
            _productoServicio.Agregar(producto);
            return CreatedAtAction(nameof(ObtenerProducto), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarProducto(int id, Producto producto)
        {
            var productoExistente = _productoServicio.ObtenerPorId(id);
            if (productoExistente == null)
            {
                return NotFound();
            }

            _productoServicio.Actualizar(id, producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarProducto(int id)
        {
            var productoExistente = _productoServicio.ObtenerPorId(id);
            if (productoExistente == null)
            {
                return NotFound();
            }

            _productoServicio.Eliminar(id);
            return NoContent();
        }
    }
}

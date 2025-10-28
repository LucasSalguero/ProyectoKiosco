using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoKiosco.BD.Datos;
using ProyectoKiosco.BD.Datos.Entity;
using ProyectoKiosco.Repositorio.Repositorios;
using ProyectoKiosco.Shared.DTO;

namespace ProyectoKiosco.Server.Controllers
{
    [ApiController]
    [Route("api/producto")]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IRepositorio<Producto> repositorio;

        public ProductoController(AppDbContext context, IRepositorio<Producto> repositorio)
        {
            this.context = context;
            this.repositorio = repositorio;
        }
        [HttpGet("listaproducto")] //api/producto/listaproducto
        public async Task<ActionResult<List<ProductoListadoDTO>>> GetProductoController()
        {
            var producto = await repositorio.Select();
            if (producto == null)
            {
                return NotFound("No se encontraron productos");
            }
            if (producto.Count == 0)
                {
                    return Ok("No existe producto");
                }
            return Ok(producto);
        }

        [HttpGet("{id:int}")] //api/producto/2
        public async Task<ActionResult<Producto>> GetByID(int id)
        {
            var producto = await repositorio.SelectById(id);
            if(producto is null)
            {
                return NotFound($"No existe el producto con id:{id}.");
            }

            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(ProductoDTO DTO)
        {
            try
            {
                var producto = new Producto
                {
                    CodigoProducto = DTO.CodigoProducto,
                    Nombre = DTO.Nombre,
                    Cantidad = DTO.Cantidad,
                    Descripcion = DTO.Descripcion,
                    Precio = DTO.Precio
                };
                await repositorio.Insert(producto);
                await context.SaveChangesAsync();
                return Ok(producto.Id);

            }
            catch (Exception e)
            {

                return BadRequest($"Error al crear producto: {e.Message}");
            }
        }


        [HttpPut("{id:int}")] //api/producto/2
        public async Task<ActionResult> Put(int id, Producto DTO)
        {
            var resultado = await repositorio.Update(id,DTO);
            if (!resultado)
            {
                return BadRequest("Datos no validos");
            }
            return Ok($"Producto con el id:{id} ha sido cambiado de precio correctamente.");

        }

        [HttpPut("{id:int}/cambiarPrecio")] //api/producto/2/cambiarPrecio
        public async Task<IActionResult> CambiarPrecio(int id, ProductoCambiarPrecioDTO dto)
        {
            // Validar que el id coincida con el del DTO
            if (id != dto.Id)
            {
                return BadRequest("El id de la URL no coincide con el del cuerpo de la solicitud.");
            }

            // Llamar al repositorio
            var resultado = await repositorio.UpdatePrecio(dto.Id, dto.NuevoPrecio);

            // Si el producto no existe
            if (!resultado)
            {
                return NotFound(new { mensaje = $"No existe el producto con id {dto.Id}." });
            }

            // Devuelve JSON en vez de solo texto
            return Ok(new
            {
                mensaje = $"El producto con id {dto.Id} ha sido actualizado correctamente.",
                id = dto.Id,
                nuevoPrecio = dto.NuevoPrecio
            });
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entidad = await context.Productos.FirstOrDefaultAsync(x  => x.Id == id); ;
            if (entidad is null)
            {
                return NotFound($"No existe el registro con el id: {id}.");
            }
            context.Productos.Remove(entidad);
            await context.SaveChangesAsync();
            return Ok($"Producto con el id: {id} eliminado correctamente");

        }

    }


}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoKiosco.BD.Datos;
using ProyectoKiosco.BD.Datos.Entity;
using ProyectoKiosco.Repositorio.Repositorios;

namespace ProyectoKiosco.Server.Controllers
{
    [ApiController]
    [Route("api/Producto")]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IRepositorio<Producto> repositorio;

        public ProductoController(AppDbContext context, IRepositorio<Producto> repositorio)
        {
            this.context = context;
            this.repositorio = repositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductoController()
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
        public async Task<ActionResult<int>> Post(Producto DTO)
        {
            try
            {
                await repositorio.Insert(DTO);
                await context.SaveChangesAsync();
                return Ok(DTO.Id);

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

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var producto = await context.Productos.FirstOrDefaultAsync(x  => x.Id == id); ;
            if (producto is null)
            {
                return NotFound($"No existe el registro con el id: {id}.");
            }
            context.Productos.Remove(producto);
            await context.SaveChangesAsync();
            return Ok($"Producto con el id: {id} eliminado correctamente");

        }

    }


}

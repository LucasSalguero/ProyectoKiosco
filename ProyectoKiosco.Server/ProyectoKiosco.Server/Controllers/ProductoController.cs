using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoKiosco.BD.Datos;
using ProyectoKiosco.BD.Datos.Entity;

namespace ProyectoKiosco.Server.Controllers
{
    [ApiController]
    [Route("api/ProductoController")]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext context;

        public ProductoController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductoController()
        {
            var producto = await context.Productos.ToListAsync();
            if (producto == null)
            {
                return NotFound("No se encontraron productos, verificar");
            }
            if (producto.Count == 0)
            {
                return Ok("No se encontraron productos cargados en este momento");
            }
            return Ok(producto);
        }
    }


}

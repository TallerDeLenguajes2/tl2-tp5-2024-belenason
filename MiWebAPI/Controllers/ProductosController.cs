using Microsoft.AspNetCore.Mvc;

namespace MiWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductosController : ControllerBase
{
    private readonly ILogger<ProductosController> _logger;

    private ProductoRepository repoProductos;

    public ProductosController(ILogger<ProductosController> logger)
    {
        _logger = logger;
        repoProductos = new ProductoRepository();
    }

    [HttpPost("api/Producto")]
    public IActionResult CrearProductos(Producto producto)
    {
        repoProductos.CrearProducto(producto);
        return Created();
    }

    [HttpGet("api/Producto")]
    public IActionResult ListarProductos()
    {
        return Ok(repoProductos.ListarProductos());
    }

    [HttpPut("/api/Producto/{Id}")]
    public IActionResult ModificarNombreProducto(int Id, Producto producto) //Está bien que permita modificar más q el nombre?
    {
        var ProductoAModificar = repoProductos.ListarProductos().Find(p => p.IdProducto == Id);
        if (ProductoAModificar == null)
        {
            return BadRequest("No se encuentra ningún producto con ese id");
        } else
        {
            repoProductos.ModificarProducto(Id, producto);
            return Ok();
        }
    }
}
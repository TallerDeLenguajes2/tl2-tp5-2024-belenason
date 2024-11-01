using Microsoft.AspNetCore.Mvc;

namespace MiWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PresupuestosController : ControllerBase
{
    private readonly ILogger<ProductosController> _logger;

    private PresupuestoRepository repoPrsupuestos;

    public PresupuestosController(ILogger<ProductosController> logger)
    {
        _logger = logger;
        repoPrsupuestos = new PresupuestoRepository();
    }

    [HttpPost("/api/Presupuesto")]
    public IActionResult CrearPresupuesto(Presupuesto presupuesto)
    {
        repoPrsupuestos.CrearPresupuesto(presupuesto);
        return Created();
    }

    [HttpPost("/api/Presupuesto/{id}/ProductoDetalle")]
    public IActionResult AgregarProdYCant(int idProducto, int Cant, int presupuestoId)
    {

        ProductoRepository repoProductos = new ProductoRepository();;
        if (repoPrsupuestos.ObtenerPresupuestoPorId(presupuestoId) == null || repoProductos.ObtenerProductoPorId(idProducto) == null)
        {
            return BadRequest("No se encuentra ningún presupuesto con ese id");
        } else
        {
            repoPrsupuestos.AgregarProductoCantidadPresupuesto(idProducto, Cant, presupuestoId);
            return Ok();
        }
    }

    [HttpGet("/api/Presupuesto")]
    public IActionResult ListarPresupuestos()
    {
        return Ok(repoPrsupuestos.ListarPresupuestos());
    }

    [HttpGet("api/Presupuestos/{id}")]
    public ActionResult<Presupuesto> GetPresupuestoPorId(int id)
    {
        return Ok(repoPrsupuestos.ObtenerPresupuestoPorId(id));
    }

    [HttpDelete]

    public IActionResult BorrarPresupuesto(int id)
    {
        repoPrsupuestos.EliminarpresupuestoPorId(id);
        return Ok();
    }
}
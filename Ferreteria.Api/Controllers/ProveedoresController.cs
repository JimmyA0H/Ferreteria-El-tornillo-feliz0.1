
using Ferreteria.Core.Entities;
using Ferreteria.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProveedoresController : ControllerBase
{
    private readonly IProveedorService _service;

    public ProveedoresController(IProveedorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Proveedor>>> Get()
    {
        var lista = await _service.ListarAsync();
        return Ok(lista);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Proveedor>> GetById(int id)
    {
        var proveedor = await _service.ObtenerAsync(id);
        if (proveedor is null) return NotFound();
        return Ok(proveedor);
    }

    [HttpPost]
    public async Task<ActionResult<Proveedor>> Post(Proveedor proveedor)
    {
        var creado = await _service.CrearAsync(proveedor);
        return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Proveedor>> Put(int id, Proveedor proveedor)
    {
        var actualizado = await _service.ActualizarAsync(id, proveedor);
        if (actualizado is null) return NotFound();
        return Ok(actualizado);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _service.EliminarAsync(id);
        if (!ok) return NotFound();
        return NoContent();
    }
}

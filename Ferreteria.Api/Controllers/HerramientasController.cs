
using Ferreteria.Core.Entities;
using Ferreteria.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HerramientasController : ControllerBase
{
    private readonly IHerramientaService _service;

    public HerramientasController(IHerramientaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Herramienta>>> Get()
    {
        var lista = await _service.ListarAsync();
        return Ok(lista);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Herramienta>> GetById(int id)
    {
        var herramienta = await _service.ObtenerAsync(id);
        if (herramienta is null) return NotFound();
        return Ok(herramienta);
    }

    [HttpGet("buscar")]
    public async Task<ActionResult<IEnumerable<Herramienta>>> Buscar([FromQuery] string q)
    {
        var lista = await _service.BuscarAsync(q);
        return Ok(lista);
    }

    [HttpPost]
    public async Task<ActionResult<Herramienta>> Post(Herramienta herramienta)
    {
        var creada = await _service.CrearAsync(herramienta);
        return CreatedAtAction(nameof(GetById), new { id = creada.Id }, creada);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Herramienta>> Put(int id, Herramienta herramienta)
    {
        var actualizada = await _service.ActualizarAsync(id, herramienta);
        if (actualizada is null) return NotFound();
        return Ok(actualizada);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _service.EliminarAsync(id);
        if (!ok) return NotFound();
        return NoContent();
    }
}

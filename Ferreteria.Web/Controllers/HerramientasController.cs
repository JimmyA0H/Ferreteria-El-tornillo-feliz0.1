using System.Net.Http.Json;
using Ferreteria.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Web.Controllers;

public class HerramientasController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HerramientasController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index(string? q)
    {
        var client = _httpClientFactory.CreateClient("FerreteriaApi");
        IEnumerable<HerramientaViewModel>? lista;

        if (!string.IsNullOrWhiteSpace(q))
        {
            lista = await client.GetFromJsonAsync<IEnumerable<HerramientaViewModel>>($"api/herramientas/buscar?q={q}");
        }
        else
        {
            lista = await client.GetFromJsonAsync<IEnumerable<HerramientaViewModel>>("api/herramientas");
        }

        return View(lista ?? new List<HerramientaViewModel>());
    }

    public IActionResult Crear()
    {
        return View(new HerramientaViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Crear(HerramientaViewModel modelo)
    {
        if (!ModelState.IsValid)
            return View(modelo);

        var client = _httpClientFactory.CreateClient("FerreteriaApi");
        var resp = await client.PostAsJsonAsync("api/herramientas", modelo);

        if (!resp.IsSuccessStatusCode)
        {
            var error = await resp.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, "ERROR API: " + error);
            return View(modelo);
        }

        return RedirectToAction(nameof(Index));
    }

    // ? EDITAR (GET)
    public async Task<IActionResult> Editar(int id)
    {
        var client = _httpClientFactory.CreateClient("FerreteriaApi");
        var herramienta = await client.GetFromJsonAsync<HerramientaViewModel>($"api/herramientas/{id}");

        if (herramienta == null)
            return NotFound();

        return View(herramienta);
    }

    // ? EDITAR (POST)
    [HttpPost]
    public async Task<IActionResult> Editar(int id, HerramientaViewModel modelo)
    {
        if (!ModelState.IsValid)
            return View(modelo);

        var client = _httpClientFactory.CreateClient("FerreteriaApi");
        var resp = await client.PutAsJsonAsync($"api/herramientas/{id}", modelo);

        if (!resp.IsSuccessStatusCode)
        {
            var error = await resp.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, "ERROR API: " + error);
            return View(modelo);
        }

        return RedirectToAction(nameof(Index));
    }

    // ? ELIMINAR
    public async Task<IActionResult> Eliminar(int id)
    {
        var client = _httpClientFactory.CreateClient("FerreteriaApi");
        var resp = await client.DeleteAsync($"api/herramientas/{id}");

        if (!resp.IsSuccessStatusCode)
            return BadRequest("No se pudo eliminar.");

        return RedirectToAction(nameof(Index));
    }
}

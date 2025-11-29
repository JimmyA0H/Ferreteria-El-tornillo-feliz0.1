
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
            ModelState.AddModelError(string.Empty, "Error al guardar la herramienta.");
            return View(modelo);
        }

        return RedirectToAction(nameof(Index));
    }
}

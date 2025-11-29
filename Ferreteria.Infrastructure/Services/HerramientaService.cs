
using Ferreteria.Core.Entities;
using Ferreteria.Core.Interfaces;

namespace Ferreteria.Infrastructure.Services;

public class HerramientaService : IHerramientaService
{
    private readonly IRepository<Herramienta> _repo;

    public HerramientaService(IRepository<Herramienta> repo)
    {
        _repo = repo;
    }

    public async Task<Herramienta> CrearAsync(Herramienta herramienta)
    {
        await _repo.AddAsync(herramienta);
        await _repo.SaveChangesAsync();
        return herramienta;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var herramienta = await _repo.GetByIdAsync(id, tracking: true);
        if (herramienta is null) return false;
        _repo.Remove(herramienta);
        await _repo.SaveChangesAsync();
        return true;
    }

    public Task<Herramienta?> BuscarAsync(int id)
    {
        return _repo.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Herramienta>> BuscarAsync(string texto)
    {
        texto = texto.ToLower();
        return await _repo.FindAsync(h => h.Nombre.ToLower().Contains(texto));
    }

    public async Task<Herramienta?> ActualizarAsync(int id, Herramienta herramienta)
    {
        var existente = await _repo.GetByIdAsync(id, tracking: true);
        if (existente is null) return null;

        existente.Nombre = herramienta.Nombre;
        existente.Descripcion = herramienta.Descripcion;
        existente.CategoriaId = herramienta.CategoriaId;
        existente.Stock = herramienta.Stock;
        existente.PrecioCompra = herramienta.PrecioCompra;
        existente.PrecioVenta = herramienta.PrecioVenta;
        existente.ActualizadoEn = DateTime.UtcNow;

        _repo.Update(existente);
        await _repo.SaveChangesAsync();
        return existente;
    }

    public Task<Herramienta?> ObtenerAsync(int id)
    {
        return _repo.GetByIdAsync(id);
    }

    public Task<IEnumerable<Herramienta>> ListarAsync()
    {
        return _repo.GetAllAsync();
    }
}

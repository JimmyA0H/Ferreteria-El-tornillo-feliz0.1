
using Ferreteria.Core.Entities;
using Ferreteria.Core.Interfaces;

namespace Ferreteria.Infrastructure.Services;

public class ProveedorService : IProveedorService
{
    private readonly IRepository<Proveedor> _repo;

    public ProveedorService(IRepository<Proveedor> repo)
    {
        _repo = repo;
    }

    public async Task<Proveedor> CrearAsync(Proveedor proveedor)
    {
        await _repo.AddAsync(proveedor);
        await _repo.SaveChangesAsync();
        return proveedor;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var prov = await _repo.GetByIdAsync(id, tracking: true);
        if (prov is null) return false;
        _repo.Remove(prov);
        await _repo.SaveChangesAsync();
        return true;
    }

    public Task<Proveedor?> ObtenerAsync(int id)
    {
        return _repo.GetByIdAsync(id);
    }

    public Task<IEnumerable<Proveedor>> ListarAsync()
    {
        return _repo.GetAllAsync();
    }

    public async Task<Proveedor?> ActualizarAsync(int id, Proveedor proveedor)
    {
        var existente = await _repo.GetByIdAsync(id, tracking: true);
        if (existente is null) return null;

        existente.Nombre = proveedor.Nombre;
        existente.Telefono = proveedor.Telefono;
        existente.Email = proveedor.Email;
        existente.Direccion = proveedor.Direccion;
        existente.Rnc = proveedor.Rnc;
        existente.ActualizadoEn = DateTime.UtcNow;

        _repo.Update(existente);
        await _repo.SaveChangesAsync();
        return existente;
    }
}

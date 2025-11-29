
using Ferreteria.Core.Entities;

namespace Ferreteria.Core.Interfaces;

public interface IProveedorService
{
    Task<IEnumerable<Proveedor>> ListarAsync();
    Task<Proveedor?> ObtenerAsync(int id);
    Task<Proveedor> CrearAsync(Proveedor proveedor);
    Task<Proveedor?> ActualizarAsync(int id, Proveedor proveedor);
    Task<bool> EliminarAsync(int id);
}

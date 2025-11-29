
using Ferreteria.Core.Entities;

namespace Ferreteria.Core.Interfaces;

public interface IHerramientaService
{
    Task<IEnumerable<Herramienta>> ListarAsync();
    Task<Herramienta?> ObtenerAsync(int id);
    Task<Herramienta> CrearAsync(Herramienta herramienta);
    Task<Herramienta?> ActualizarAsync(int id, Herramienta herramienta);
    Task<bool> EliminarAsync(int id);

    // Sobrecarga de método Buscar
    Task<IEnumerable<Herramienta>> BuscarAsync(string texto);
    Task<Herramienta?> BuscarAsync(int id);
}

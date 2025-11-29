using System;
using System.Collections.Generic;
using System.Linq;


namespace Ferreteria.Core.Entities;

public class Herramienta : EntidadBase
{
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
    public int Stock { get; set; }
    public decimal PrecioCompra { get; set; }
    public decimal PrecioVenta { get; set; }

    // Sobrecarga de constructores
    public Herramienta()
    {
    }

    public Herramienta(string nombre, decimal precioVenta)
    {
        Nombre = nombre;
        PrecioVenta = precioVenta;
    }

    public Herramienta(string nombre, decimal precioVenta, int stock)
        : this(nombre, precioVenta)
    {
        Stock = stock;
    }
}

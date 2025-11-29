using System;
using System.Collections.Generic;
using System.Linq;


namespace Ferreteria.Core.Entities;

public class Compra : EntidadBase
{
    public int ProveedorId { get; set; }
    public Proveedor? Proveedor { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public ICollection<CompraDetalle> Detalles { get; set; } = new List<CompraDetalle>();

    public decimal Total => Detalles.Sum(d => d.Cantidad * d.PrecioUnitario);
}

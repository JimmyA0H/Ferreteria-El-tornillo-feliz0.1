using System;
using System.Collections.Generic;
using System.Linq;


namespace Ferreteria.Core.Entities;

public class Venta : EntidadBase
{
    public DateTime Fecha { get; set; } = DateTime.Now;
    public string ClienteNombre { get; set; } = string.Empty;
    public ICollection<VentaDetalle> Detalles { get; set; } = new List<VentaDetalle>();

    public decimal Total => Detalles.Sum(d => d.Cantidad * d.PrecioUnitario);
}

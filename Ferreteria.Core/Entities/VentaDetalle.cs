using System;
using System.Collections.Generic;
using System.Linq;


namespace Ferreteria.Core.Entities;

public class VentaDetalle : EntidadBase
{
    public int VentaId { get; set; }
    public Venta? Venta { get; set; }

    public int HerramientaId { get; set; }
    public Herramienta? Herramienta { get; set; }

    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}

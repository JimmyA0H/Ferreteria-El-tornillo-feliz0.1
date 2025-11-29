using System;
using System.Collections.Generic;
using System.Linq;


namespace Ferreteria.Core.Entities;

public class CompraDetalle : EntidadBase
{
    public int CompraId { get; set; }
    public Compra? Compra { get; set; }

    public int HerramientaId { get; set; }
    public Herramienta? Herramienta { get; set; }

    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}

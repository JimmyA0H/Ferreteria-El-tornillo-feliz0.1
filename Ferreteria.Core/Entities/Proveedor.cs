using System;
using System.Collections.Generic;
using System.Linq;


namespace Ferreteria.Core.Entities;

public class Proveedor : Persona
{
    public string? Rnc { get; set; }
    public ICollection<Compra> Compras { get; set; } = new List<Compra>();
}

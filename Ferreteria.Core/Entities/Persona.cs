using System;
using System.Collections.Generic;
using System.Linq;


namespace Ferreteria.Core.Entities;

public abstract class Persona : EntidadBase
{
    public string Nombre { get; set; } = string.Empty;
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string? Direccion { get; set; }
}

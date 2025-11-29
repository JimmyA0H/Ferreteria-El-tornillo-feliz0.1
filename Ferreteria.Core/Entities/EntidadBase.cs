using System;
using System.Collections.Generic;
using System.Linq;


namespace Ferreteria.Core.Entities;

public abstract class EntidadBase
{
    public int Id { get; set; }
    public DateTime CreadoEn { get; set; } = DateTime.UtcNow;
    public DateTime? ActualizadoEn { get; set; }
}


using System.ComponentModel.DataAnnotations;

namespace Ferreteria.Web.Models;

public class HerramientaViewModel
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Nombre de la herramienta")]
    public string Nombre { get; set; } = string.Empty;

    [Display(Name = "Descripción")]
    public string? Descripcion { get; set; }

    [Display(Name = "Categoría Id")]
    public int CategoriaId { get; set; }

    [Display(Name = "Stock")]
    public int Stock { get; set; }

    [Display(Name = "Precio de compra")]
    public decimal PrecioCompra { get; set; }

    [Display(Name = "Precio de venta")]
    public decimal PrecioVenta { get; set; }
}

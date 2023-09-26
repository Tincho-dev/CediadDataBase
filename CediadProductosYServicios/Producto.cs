using CediadDataBase;
using System.ComponentModel.DataAnnotations;

namespace CediadProductosYServicios;

public class Producto
{
    [Key]
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public decimal PrecioDeCompra { get; set; }
    public string? Imagen { get; set; }
    public Categoria Categoria { get; set; }
}

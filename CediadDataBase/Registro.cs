using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CediadDataBase;

public class Registro
{
    [Key]
    public int Id { get; set; }
    public DateTime FechaDePago {  get; set; }
    public decimal Monto { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public Categoria Categoria { get; set; }
    public MetodoDePago MetodoDePago { get; set; }
}

public class Consumision : Registro
{
    public DateTime FechaDeCreacion { get; set; }
    [ForeignKey(name:"ConsumidorId")]
    public int ConsumidorId { get; set; }
    public virtual Persona Consumidor { get; set; }
}

public class Suscripcion : Registro
{
    public int Mes { get; set; }
    [ForeignKey(name: "ClienteId")]
    public int ClienteId { get; set; }
    public virtual Persona Cliente { get; set; }
}

public class Persona
{
    [Key]
    public int Id { get; set; }
    public string Telefono { get; set; } = string.Empty;
}

public enum MetodoDePago
{
    EFECTIVO = 1,
    TRANFERENCIA,
    DEUDA
}

public enum Categoria 
{ 
    ALQUILER = 1,
    ASADOR,
    BEBIDA,
    BEBIDA_PRIMA,
    CANCHA,
    COMIDA,
    COMIDA_PRIMA,
    CUOTA,
    DIFERENCIA_CAJA,
    EVENTO,
    MANTENIMIENTO,
    SUELDO,
    SERVICIO,
    VIATICO
}

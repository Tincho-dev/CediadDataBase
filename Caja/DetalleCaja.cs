using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caja;

public class DetalleCaja
{
    //not suported by ef core
    public int Id { get; set; }
    //public Dictionary<int,int> Billetes { get; set; } //valor, cantidad 
    //alternativa a diccionario
    //public int[] Billetes { get; set; } //valor, cantidad
    public DateTime Fecha { get; set; }
    public string BilletesJson { get; set; }

    [NotMapped] // EF Core ignorará esta propiedad
    public Dictionary<int, int> Billetes
    {
        get => JsonConvert.DeserializeObject<Dictionary<int, int>>(BilletesJson);
        set => BilletesJson = JsonConvert.SerializeObject(value);
    }
    public DetalleCaja(Moneda moneda)
    {
        if (moneda == Moneda.Peso)
        {
            Billetes = new Dictionary<int, int>
            {
                { 1000, 0 },
                { 500, 0 },
                { 200, 0 },
                { 100, 0 },
                { 50, 0 },
                { 20, 0 },
                { 10, 0 }
            };
        }
        else if (moneda == Moneda.Dolar)
        {
            Billetes = new Dictionary<int, int>
            {
                { 100, 0 },
                { 50, 0 },
                { 20, 0 },
                { 10, 0 },
                { 5, 0 },
                { 2, 0 },
                { 1, 0 }
            };
        }
        else
        {
            Billetes = new Dictionary<int, int>();
        }
    }

    public DetalleCaja()
    {
        Billetes = new Dictionary<int, int>
        {
            { 1000, 0 },
            { 500, 0 },
            { 200, 0 },
            { 100, 0 },
            { 50, 0 },
            { 20, 0 },
            { 10, 0 }
        };
    }
}

public enum Billete
{
    Mil,
    Quinientos,
    Doscientos,
    Cien,
    Cincuenta,
    Veinte,
    Diez
}

public enum Dolares
{
    Cien,
    Cincuenta,
    Veinte,
    Diez,
    Cinco,
    Dos,
    Uno
}

public enum Moneda
{
    Peso,
    Dolar
}


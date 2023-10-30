namespace Caja;

public class CajaService : ICajaService
{
    private readonly CajaContext _context;

    public CajaService(CajaContext context)
    {
        _context = context;
    }

    public async Task<DetalleCaja> GetDetalleCaja(DateTime date, Moneda moneda = Moneda.Peso)
    {
        var detalleCaja = _context.DetallesCaja.FirstOrDefault(x => x.Fecha == date);
        if(detalleCaja == null)
        {
            detalleCaja = new DetalleCaja(moneda);
            _context.DetallesCaja.Add(detalleCaja);
            await _context.SaveChangesAsync();
        }
        return detalleCaja;
    }

    public async Task SetDetalleCaja(DetalleCaja detalleCaja)
    {
        _context.DetallesCaja.Update(detalleCaja);
        await _context.SaveChangesAsync();
    }
}

public interface ICajaService
{
    Task<DetalleCaja> GetDetalleCaja(DateTime date, Moneda moneda = Moneda.Peso);
    Task SetDetalleCaja(DetalleCaja detalleCaja);
}

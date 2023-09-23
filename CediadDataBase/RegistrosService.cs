using Microsoft.EntityFrameworkCore;

namespace CediadDataBase;

public class RegistrosService
{
    private readonly RegistroContext _context;

    public RegistrosService(RegistroContext context)
    {
        _context = context;
    }

    public async Task<bool> AddRegistro(Registro registro)
    {
        if (registro == null) { return false; }
        if (_context.Registros.Any(r => r.Id == registro.Id))
            _context.Registros.Update(registro);
        else
            _context.Registros.Add(registro);
        try
        {
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<List<Registro>> GetRegistros()
    {
        return _context.Registros.ToList();
    }

    public async Task<List<Registro>> GetRegistros(DateTime date)
    {
        // Crear dos DateTime para representar el inicio y el final del día especificado
        DateTime inicioDia = date.Date; // Hora 00:00:00
        DateTime finDia = date.Date.AddDays(1).AddTicks(-1); // Hora 23:59:59

        return _context.Registros
            .Where(r => r.FechaDePago >= inicioDia && r.FechaDePago <= finDia)
            .ToList();
    }



    public Registro? GetRegistro()
    {
        return _context.Registros.FirstOrDefault();
    }
}

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

    public Registro? GetRegistro()
    {
        return _context.Registros.FirstOrDefault();
    }
}

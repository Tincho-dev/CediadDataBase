using Microsoft.EntityFrameworkCore;

namespace CediadDataBase;

public class RegistrosService
{
    private readonly RegistroContext _context;

	public RegistrosService(RegistroContext context)
	{
		_context = context;
	}
	public async Task<bool> AddRegistro(Registro registro) {
		try
		{
			_context.Registros.Add(registro);
            await _context.SaveChangesAsync();

            return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public async Task<List<Registro>> GetRegistros() { 
		return _context.Registros.ToList();
	}

    public Registro? GetRegistro()
	{
		return _context.Registros.FirstOrDefault();
	}
}

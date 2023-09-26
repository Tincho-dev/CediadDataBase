namespace CediadDataBase;

public class RegistroServiceMock : IRegistroService
{
    private readonly List<Registro> _registros;

    public RegistroServiceMock()
    {
        _registros = new List<Registro>()
            {
                new Registro()
                {
                    Id = 1,
                    FechaDePago = DateTime.Now,
                    Titulo = "Fiesta Juan",
                    Descripcion = "35 chicos y 20 adultos",
                    Monto = 10000,
                    Categoria = Categoria.FIESTA,
                    MetodoDePago = MetodoDePago.EFECTIVO,
                    Destino = Destino.DIARIA
                },
                new Registro()
                {
                    Id = 2,
                    FechaDePago = DateTime.Now,
                    Titulo = "Arqueo de caja",
                    Descripcion = "",
                    Monto = -10000,
                    Categoria = Categoria.ALQUILER,
                    MetodoDePago = MetodoDePago.EFECTIVO,
                    Destino = Destino.DIARIA
                },
                new Registro()
                {
                    Id = 3,
                    FechaDePago = DateTime.Now,
                    Titulo = "Arqueo caja",
                    Descripcion = "",
                    Monto = 10000,
                    Categoria = Categoria.ALQUILER,
                    MetodoDePago = MetodoDePago.EFECTIVO,
                    Destino = Destino.GENERAL
                },
            };
    }

    public Task<bool> AddRegistro(Registro registro)
    {
        _registros.Add(registro);   
        return Task.FromResult(true);
    }

    public Task<List<Registro>> GetRegistros()
    {
        return Task.FromResult(_registros);
    }

    public List<Registro> GetRegistros(Func<Registro, bool> predicate)
    {
        var registros = _registros.Where(predicate);
        return registros.ToList();
    }

    public List<Registro> GetRegistros(DateTime date)
    {
        DateTime inicioDia = date.Date; // Hora 00:00:00
        DateTime finDia = date.Date.AddDays(1).AddTicks(-1); // Hora 23:59:59

        return _registros
            .Where(r => r.FechaDePago >= inicioDia && r.FechaDePago <= finDia)
            .ToList();
    }
}

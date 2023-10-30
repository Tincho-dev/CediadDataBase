using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Caja;

public class CajaContext : DbContext
{
    public DbSet<DetalleCaja> DetallesCaja => Set<DetalleCaja>();
    public CajaContext(DbContextOptions<CajaContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}

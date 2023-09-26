using CediadProductosYServicios;
using Microsoft.EntityFrameworkCore;

namespace CediadDataBase;

public class ProductoContext : DbContext
{
    public ProductoContext(DbContextOptions<ProductoContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Producto> Productos => Set<Producto>();
}

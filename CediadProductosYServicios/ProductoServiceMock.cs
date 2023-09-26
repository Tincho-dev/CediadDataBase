using CediadDataBase;

namespace CediadProductosYServicios;

public class ProductoServiceMock : IProductoService
{
    private readonly List<Producto> _productos;

    public ProductoServiceMock()
    {
        _productos = new List<Producto>()
        {
                new Producto()
                {
                    Id = 1,
                    Nombre = "Coca Cola 2L",
                    Codigo = "COC2",
                    Precio = 800,
                    PrecioDeCompra = 500,
                    Cantidad = 10,
                    Categoria = Categoria.BEBIDA,
                    Descripcion = "Bebida gaseosa"
                },
                new Producto()
                {
                    Id = 2,
                    Nombre = "Papas fritas saborizadas",
                    Codigo = "TAFISAB",
                    Precio = 850,
                    PrecioDeCompra = 500,
                    Cantidad = 10,
                    Categoria = Categoria.COMIDA,
                    Descripcion = "Papas fritas"
                },
                new Producto()
                {
                    Id = 3,
                    Nombre = "Papas fritas",
                    Codigo = "TAFI100",
                    Precio = 800,
                    PrecioDeCompra = 425,
                    Cantidad = 10,
                    Categoria = Categoria.COMIDA,
                    Descripcion = "Papas fritas"
                },
            };
    }
    public Task<bool> AddProducto(Producto producto)
    {
        _productos.Add(producto);
        return Task.FromResult(true);
    }

    public Task<List<Producto>> GetProductos()
    {
        return Task.FromResult(_productos);
    }

    public List<Producto> GetProductos(Func<Producto, bool> predicate)
    {
        var productos = _productos.Where(predicate);
        return productos.ToList();
    }

    public Task<bool> RemoveProducto(int id)
    {
        var producto = _productos.FirstOrDefault(p => p.Id == id);
        if (producto == null) { return Task.FromResult(false); }
        _productos.Remove(producto);
        return Task.FromResult(true);
    }

    public Task<bool> RemoveProducto(Producto producto)
    {
        if (producto == null) { return Task.FromResult(false); }
        _productos.Remove(producto);
        return Task.FromResult(true);
    }

    public Task<bool> UpdateProducto(Producto producto)
    {
        var productoToUpdate = _productos.FirstOrDefault(p => p.Id == producto.Id);
        if (productoToUpdate == null) { return Task.FromResult(false); }
        productoToUpdate.Nombre = producto.Nombre;
        productoToUpdate.Precio = producto.Precio;
        productoToUpdate.PrecioDeCompra = producto.PrecioDeCompra;
        productoToUpdate.Cantidad = producto.Cantidad;
        productoToUpdate.Categoria = producto.Categoria;
        productoToUpdate.Descripcion = producto.Descripcion;
        return Task.FromResult(true);
    }

    public Task<bool> UpdateProducto(int id, Producto producto)
    {
        var productoToUpdate = _productos.FirstOrDefault(p => p.Id == id);
        if (productoToUpdate == null) { return Task.FromResult(false); }
        productoToUpdate.Nombre = producto.Nombre;
        productoToUpdate.Precio = producto.Precio;
        productoToUpdate.PrecioDeCompra = producto.PrecioDeCompra;
        productoToUpdate.Cantidad = producto.Cantidad;
        productoToUpdate.Categoria = producto.Categoria;
        productoToUpdate.Descripcion = producto.Descripcion;
        return Task.FromResult(true);
    }
}

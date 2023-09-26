
using CediadDataBase;
using Microsoft.EntityFrameworkCore;

namespace CediadProductosYServicios;

public class ProductoService
{
    private readonly ProductoContext _context;

    public ProductoService(ProductoContext context)
    {
        _context = context;
    }

    public async Task<bool> AddProducto(Producto producto)
    {
        if (producto == null) { return false; }
        if (_context.Productos.Any(p => p.Id == producto.Id))
            _context.Productos.Update(producto);
        else
            _context.Productos.Add(producto);
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

    public async Task<List<Producto>> GetProductos()
    {
        return await _context.Productos.ToListAsync();
    }

    public List<Producto> GetProductos(Func<Producto, bool> predicate)
    {
        var result = _context.Productos.Where(predicate);
        return result.ToList();
    }

    public async Task<bool> RemoveProducto(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) { return false; }
        _context.Productos.Remove(producto);
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

    public async Task<bool> RemoveProducto(Producto producto)
    {
        if (producto == null) { return false; }
        _context.Productos.Remove(producto);
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

    public async Task<bool> UpdateProducto(Producto producto)
    {
        if (producto == null) { return false; }
        _context.Productos.Update(producto);
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

    public async Task<bool> UpdateProducto(int id, Producto producto)
    {
        if (producto == null) { return false; }
        var productoToUpdate = await _context.Productos.FindAsync(id);
        if (productoToUpdate == null) { return false; }
        productoToUpdate.Nombre = producto.Nombre;
        productoToUpdate.Descripcion = producto.Descripcion;
        productoToUpdate.Precio = producto.Precio;
        productoToUpdate.Imagen = producto.Imagen;
        productoToUpdate.Categoria = producto.Categoria;
        _context.Productos.Update(productoToUpdate);
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

}

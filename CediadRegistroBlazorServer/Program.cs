using CediadDataBase;
using Caja;
using CediadProductosYServicios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<RegistroContext>(options =>
    options.UseSqlServer("Server=CEDIAD\\SQLEXPRESS02;Database=CediadRegistrosDb;Integrated Security=True;TrustServerCertificate=true;"));
builder.Services.AddScoped<IRegistroService, RegistroServiceMock>();
builder.Services.AddDbContext<ProductoContext>(options =>
    options.UseSqlServer("Server=CEDIAD\\SQLEXPRESS02;Database=CediadProductosDb;Integrated Security=True;TrustServerCertificate=true;"));
builder.Services.AddTransient<IProductoService, ProductoService>();
builder.Services.AddDbContext<CajaContext>(options =>
        options.UseSqlServer("Server=CEDIAD\\SQLEXPRESS02;Database=CediadCajasDb;Integrated Security=True;TrustServerCertificate=true;"));
builder.Services.AddTransient<ICajaService, CajaService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

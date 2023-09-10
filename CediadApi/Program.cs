using CediadDataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RegistroContext>(options =>
    options.UseSqlServer("Server=CEDIAD\\SQLEXPRESS02;Database=CediadDb;Integrated Security=True;TrustServerCertificate=true;"));
builder.Services.AddScoped<RegistrosService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    });
}

app.UseHttpsRedirection();

app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", () => "Hello World!");

    endpoints.MapGet("/registro", async context =>
    {
        var registrosService = context.RequestServices.GetRequiredService<RegistrosService>();
        var registro = registrosService.GetRegistro();
        await context.Response.WriteAsJsonAsync(registro);
    })
    .WithDisplayName("Obtener Registro"); // Nombre descriptivo

    endpoints.MapPost("/registro", async context =>
    {
        var registrosService = context.RequestServices.GetRequiredService<RegistrosService>();
        var registro = await context.Request.ReadFromJsonAsync<Registro>();
        bool success = await registrosService.AddRegistro(registro);
        context.Response.StatusCode = 204;
    })
    .WithDisplayName("Agregar Registro"); // Nombre descriptivo
});


//app.MapGet("/", (Func<string>)(() => "Hello World!"));

//app.MapGet("/registro",async  (http) =>
//{
//    var registrosService = http.RequestServices.GetRequiredService<RegistrosService>();
//    var registro = registrosService.GetRegistro();
//    await http.Response.WriteAsJsonAsync(registro);
//})
//.WithName("Registros");

//app.MapPost("/registro", async (http) =>
//{
//    var registrosService = http.RequestServices.GetRequiredService<RegistrosService>();
//    var registro = await http.Request.ReadFromJsonAsync<Registro>();
//    bool success = await registrosService.AddRegistro(registro);
//    http.Response.StatusCode = 204;
//}
//);

app.Run();
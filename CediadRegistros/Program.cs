using CediadDataBase;
using CediadRegistros;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddDbContext<RegistroContext>(options =>
    options.UseSqlServer("Server=CEDIAD\\SQLEXPRESS02;Database=CediadDb;Integrated Security=True;TrustServerCertificate=true;"));
builder.Services.AddScoped<RegistrosService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

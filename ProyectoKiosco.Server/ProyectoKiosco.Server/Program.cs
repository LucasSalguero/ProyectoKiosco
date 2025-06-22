using Microsoft.EntityFrameworkCore;
using ProyectoKiosco.BD.Datos;
using ProyectoKiosco.Server.Client.Pages;
using ProyectoKiosco.Server.Components;


// configura el constructor de la app
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ConnSqlServer")
                        ?? throw new InvalidOperationException(
                            "La conexion no existe");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Contruccion de la app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ProyectoKiosco.Server.Client._Imports).Assembly);

app.Run();

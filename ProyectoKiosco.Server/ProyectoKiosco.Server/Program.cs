using Microsoft.EntityFrameworkCore;
using ProyectoKiosco.BD.Datos;
using ProyectoKiosco.BD.Datos.Entity;
using ProyectoKiosco.Repositorio.Repositorios;
using ProyectoKiosco.Server.Client.Pages;
using ProyectoKiosco.Server.Components;


// configura el constructor de la app
var builder = WebApplication.CreateBuilder(args);
#region configurar el constructor de la aplicacion y los servicios

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();


// cadena de conexion con la base de datos
var connectionString = builder.Configuration.GetConnectionString("ConnSqlServer")
                        ?? throw new InvalidOperationException(
                            "La conexion no existe");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IRepositorio<Producto>, Repositorio<Producto>>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

#endregion
// Contruccion de la app
var app = builder.Build();
#region Construccion la aplicacion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
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

app.MapControllers();
#endregion
app.Run();

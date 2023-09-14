using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;

using ProyectoLogin.Servicios.Contrato;
using ProyectoLogin.Servicios.Implementacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DbpruebaContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));

});


builder.Services.AddScoped<IUsuarioService, UsuarioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

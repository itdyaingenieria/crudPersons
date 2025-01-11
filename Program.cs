using Prueba_YamaAndrade.Data;
using Microsoft.EntityFrameworkCore;
using Prueba_YamaAndrade.Services;  // Asegúrate de incluir el espacio de nombres correcto

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registrar DbContext para acceder a la base de datos
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DFYAConnection"));
});

// Registrar el servicio PersonaService
builder.Services.AddScoped<PersonaService>();

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
    pattern: "{controller=Persona}/{action=Listar}/{id?}");

app.Run();

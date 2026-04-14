using Microsoft.EntityFrameworkCore;
using WebApplicationAPP.Business;
using WebApplicationAPP.Bussines;
using WebApplicationAPP.Data;
using WebApplicationAPP.Repositories;
using WebApplicationAPP.Services;

var builder = global::Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

// DB
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("MysqlConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("MysqlConnection")
        )
    );
});

// CAJA
builder.Services.AddScoped<ICajaRepository, CajaRepository>();
builder.Services.AddScoped<CajaBussiness>();

// SINPE
builder.Services.AddScoped<ISinpeRepository, SinpeRepository>();
builder.Services.AddScoped<SinpeBusiness>();

// COMERCIO
builder.Services.AddScoped<IComercioRepository, ComercioRepository>();
builder.Services.AddScoped<ComercioBussines>();

// BITACORA
builder.Services.AddScoped<IBitacoraRepository, BitacoraRepository>();
builder.Services.AddScoped<IBitacoraService, BitacoraService>();

// REPORTES
builder.Services.AddScoped<IReporteRepository, ReporteRepository>();
builder.Services.AddScoped<ReporteBusiness>();

// USUARIOS 
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<UsuarioBusiness>();

builder.Services.AddScoped<IConfiguracionComercioRepository, ConfiguracionComercioRepository>();
builder.Services.AddScoped<ConfiguracionComercioBusiness>();

builder.Services.AddScoped<ICitaRepository, CitaRepository>();
builder.Services.AddScoped<CitaBusiness>();


builder.Services.AddScoped<IServicioRepository, ServicioRepository>();
builder.Services.AddScoped<ServicioBusiness>();



var app = builder.Build();

// ERRORES
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// RUTA
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();

using Microsoft.EntityFrameworkCore;
using WebApplicationAPP.Business;
using WebApplicationAPP.Bussines;
using WebApplicationAPP.Repositories;
using WebApplicationAPP.Services;
using Microsoft.AspNetCore.Identity;

var builder = global::Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("MysqlConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("MysqlConnection")
        )
    );
});


builder.Services.AddScoped<ICajaRepository, CajaRepository>();
builder.Services.AddScoped<CajaBussiness>();


builder.Services.AddScoped<ISinpeRepository, SinpeRepository>();
builder.Services.AddScoped<SinpeBusiness>();


builder.Services.AddScoped<IComercioRepository, ComercioRepository>();
builder.Services.AddScoped<ComercioBussines>();


builder.Services.AddScoped<IBitacoraRepository, BitacoraRepository>();
builder.Services.AddScoped<IBitacoraService, BitacoraService>();


builder.Services.AddScoped<IReporteRepository, ReporteRepository>();
builder.Services.AddScoped<ReporteBusiness>();


builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<UsuarioBusiness>();

builder.Services.AddScoped<IConfiguracionComercioRepository, ConfiguracionComercioRepository>();
builder.Services.AddScoped<ConfiguracionComercioBusiness>();

builder.Services.AddScoped<ICitaRepository, CitaRepository>();
builder.Services.AddScoped<CitaBusiness>();


builder.Services.AddScoped<IServicioRepository, ServicioRepository>();
builder.Services.AddScoped<ServicioBusiness>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = { "Administrador", "Cajero" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

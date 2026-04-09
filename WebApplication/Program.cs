using Microsoft.EntityFrameworkCore;
using WebApplicationAPP.Business;
using WebApplicationAPP.Bussines;
using WebApplicationAPP.Data;
using WebApplicationAPP.Repositories;
using WebApplicationAPP.Services;

var builder = global::Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

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

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers(); 


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();

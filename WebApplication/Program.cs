using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Repositories;
using WebApplication.Bussines;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MysqlConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MysqlConnection"))
    ));

builder.Services.AddScoped<ISinpeRepository, SinpeRepository>();
builder.Services.AddScoped<SinpeBussines>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

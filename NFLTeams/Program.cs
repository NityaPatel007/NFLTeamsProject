using Microsoft.EntityFrameworkCore;
using NFLTeams.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMemoryCache();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add EF Core DI
builder.Services.AddDbContext<TeamContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TeamContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "custom",
    pattern: "{controller}/{action}/conf-{activeConf}/div-{activeDiv}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using MyWeather.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager Configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllersWithViews();

var server = Configuration["DatabaseServer"] ?? "";
var port = Configuration["DatabasePort"] ?? "";
var user = Configuration["DatabaseUser"] ?? "";
var password = Configuration["DatabasePassword"] ?? "";
var database = Configuration["DatabaseName"] ?? "";

var connectionString = $"Server={server}, {port}; Initial Catalog={database}; User ID={user}; Password={password}";
builder.Services.AddDbContext<MasterContext>(options => 
    options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();

/*using (var scope = app.Services.CreateScope())
{
   var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
   dataContext.Database.Migrate();
}*/

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

app.UseAuthorization();

app.UseEndpoints(endpoints => 
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run("http://*:80");
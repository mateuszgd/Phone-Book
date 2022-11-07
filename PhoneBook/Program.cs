using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;
using PhoneBook.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PhoneBookDatabase");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PhoneBookContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();

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

app.UseAuthorization();

app.MapControllerRoute(name: "menu",
    pattern: "{department}",
    defaults: new {controller = "Employee", action = "Index" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();

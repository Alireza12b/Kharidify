using App.Domain.AppServices.DipendencyInjections;
using App.Domain.Core.Users.Entities;
using App.Domain.Services.DipendencyInjections;
using App.Endpoints.RazorPages.UI.ViewModels;
using App.Infra.Data.Repos.EF.DependencyInjections;
using App.Infra.Data.Repos.EF.Mapping;
using App.Infra.Data.SqlServer.EF.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc();

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(ProductsProfiles)));
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingUi)));


builder.Services.AddInfrastructure();
builder.Services.AddServices();
builder.Services.AddAppServices();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<KharidifyDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;

}).AddEntityFrameworkStores<KharidifyDbContext>();


var serviceProvider = builder.Services.BuildServiceProvider();
var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

if (!await roleManager.RoleExistsAsync("Customer"))
{
    await roleManager.CreateAsync(new IdentityRole<int>("Customer"));
}
if (!await roleManager.RoleExistsAsync("Seller"))
{
    await roleManager.CreateAsync(new IdentityRole<int>("Seller"));
}
if (!await roleManager.RoleExistsAsync("Admin"))
{
    await roleManager.CreateAsync(new IdentityRole<int>("Admin"));
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

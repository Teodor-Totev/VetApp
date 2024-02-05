using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using VetApp.Data;
using VetApp.Data.Models;
using VetApp.Services;
using VetApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("default");


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<VetAppDbContext>(options =>
	options.UseSqlServer(connectionString));

builder.Services.AddIdentity<VetUser, IdentityRole>(options =>
{
	options.Password.RequiredUniqueChars = 0;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireDigit = false;
	options.Password.RequireUppercase = false;
	options.Password.RequireLowercase = false;
	options.Password.RequiredLength = 4;
})
	.AddEntityFrameworkStores<VetAppDbContext>();

builder.Services.AddScoped<IAccountService, AccountService>();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

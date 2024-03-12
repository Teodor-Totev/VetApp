using Microsoft.AspNetCore.Mvc;
using VetApp.ModelBinders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddControllersWithViews(options =>
{
	options.ModelBinderProviders.Insert(0, new DoubleModelBinderProvider());
	options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseExceptionHandler("/Home/Error/500");
app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

await app.RunAsync();

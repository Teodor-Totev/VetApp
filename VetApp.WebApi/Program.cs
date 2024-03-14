namespace VetApp.WebApi
{
	using VetApp.Services.Interfaces;
	using VetApp.Services;
	using VetApp.Data;
	using Microsoft.EntityFrameworkCore;

	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			string connectionString = builder.Configuration.GetConnectionString("default");
			builder.Services.AddDbContext<VetAppDbContext>(options =>
				options.UseSqlServer(connectionString));

			builder.Services.AddScoped<IOwnerService, OwnerService>();

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddCors(setup =>
			{
				setup.AddPolicy("VetApp", policybuilder =>
				{
					policybuilder.WithOrigins("https://localhost:7045")
					.AllowAnyHeader()
					.AllowAnyMethod();
				});
			});

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.UseCors("VetApp");

			app.Run();
		}
	}
}

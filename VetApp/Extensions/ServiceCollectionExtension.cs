﻿namespace Microsoft.Extensions.DependencyInjection
{
	using Microsoft.EntityFrameworkCore;
	using VetApp.Data;
	using VetApp.Data.Models;

	public static class ServiceCollectionExtension
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			return services;
		}

		public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
		{
			string connectionString = config.GetConnectionString("default");
			services.AddDbContext<VetAppDbContext>(options =>
				options.UseSqlServer(connectionString));

			//services.AddDatabaseDeveloperPageExceptionFilter();

			return services;
		}

		public static IServiceCollection AddApplicationIdentity(this IServiceCollection services,
			IConfiguration config)
		{
			services
				.AddDefaultIdentity<ApplicationUser>(options =>
				{
					options.SignIn.RequireConfirmedAccount = false;
					options.Password.RequiredUniqueChars = 0;
					options.Password.RequireNonAlphanumeric = false;
					options.Password.RequireDigit = false;
					options.Password.RequireUppercase = false;
					options.Password.RequireLowercase = false;
					options.Password.RequiredLength = 4;
				})
				.AddEntityFrameworkStores<VetAppDbContext>();

			return services;
		}
	}
}
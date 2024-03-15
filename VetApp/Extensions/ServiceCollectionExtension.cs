﻿namespace Microsoft.Extensions.DependencyInjection
{
	using Microsoft.EntityFrameworkCore;
	using VetApp.Data;
	using VetApp.Data.Models;
	using VetApp.Services.Interfaces;
	using VetApp.Services;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Authentication.Cookies;

	public static class ServiceCollectionExtension
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IPatientService, PatientService>();
			services.AddScoped<IExaminationService, ExaminationService>();
			services.AddScoped<IStatusService, StatusService>();
			services.AddScoped<IOwnerService, OwnerService>();

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
				.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
				{
					options.SignIn.RequireConfirmedAccount = false;
					options.Password.RequiredUniqueChars = 0;
					options.Password.RequireNonAlphanumeric = false;
					options.Password.RequireDigit = false;
					options.Password.RequireUppercase = false;
					options.Password.RequireLowercase = false;
					options.Password.RequiredLength = 4;
				})
				.AddEntityFrameworkStores<VetAppDbContext>()
				.AddDefaultTokenProviders();

			services.AddAuthentication()
				.AddCookie(options =>
				{
					options.LoginPath = "/Account/Login";
					//options.AccessDeniedPath = "/Account/Login";
				});

			return services;
		}
	}
}

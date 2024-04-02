namespace Microsoft.Extensions.DependencyInjection
{
	using Microsoft.EntityFrameworkCore;
	using VetApp.Data;
	using VetApp.Data.Models;
	using VetApp.Services.Interfaces;
	using VetApp.Services;
	using Microsoft.AspNetCore.Identity;
	using static VetApp.Data.Common.AdminUser;

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
				.AddRoles<IdentityRole<Guid>>()
				.AddEntityFrameworkStores<VetAppDbContext>()
				.AddDefaultTokenProviders();

			services.AddAuthentication()
				.AddCookie(options =>
				{
					options.LoginPath = "/Account/Login";
					options.AccessDeniedPath = "/Account/Login";
				});

			var serviceProvider = services.BuildServiceProvider();
			SeedData(serviceProvider).Wait();

			return services;
		}

		private static async Task SeedData(IServiceProvider serviceProvider)
		{
			var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

			if (!await roleManager.RoleExistsAsync(AdminRoleName))
			{
				await roleManager.CreateAsync(new IdentityRole<Guid>(AdminRoleName));
			}

			var user = await userManager.FindByNameAsync(AdminUserName);

			if (user != null)
			{
				if (!await userManager.IsInRoleAsync(user, AdminRoleName))
				{
					await userManager.AddToRoleAsync(user, AdminRoleName);
				}
			}
		}
	}
}

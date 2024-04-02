namespace VetApp.Data.Configuration
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using VetApp.Data.Models;

    public class VetUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
			builder
				.HasData(SeedUsers());
		}

		private ApplicationUser[] SeedUsers()
		{
			ICollection<ApplicationUser> users = new HashSet<ApplicationUser>();

			var hasher = new PasswordHasher<ApplicationUser>();
			ApplicationUser user;

			user = new()
			{
				Id = Guid.Parse("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
				UserName = "r_raykov",
				NormalizedUserName = "R_RAYKOV",
				FirstName = "Radoslav",
				LastName = "Raykov",
				Address = "123 Main St Haskovo",
				Email = "r_raykov@gmail.com",
				NormalizedEmail = "R_RAYKOV@GMAIL.COM",
				SecurityStamp = Guid.NewGuid().ToString().ToUpper(),
				ConcurrencyStamp = Guid.NewGuid().ToString(),
				TwoFactorEnabled = false,
				EmailConfirmed = false,
				PhoneNumberConfirmed = false,
				AccessFailedCount = 0,
				LockoutEnabled = true,
				PasswordHash = hasher.HashPassword(null, "1234")
			};
			users.Add(user);

			user = new()
			{
				Id = Guid.Parse("8df82639-d79b-405e-af30-b245f2224fab"),
				UserName = "admin",
				NormalizedUserName = "ADMIN",
				FirstName = "Great",
				LastName = "Admin",
				Address = "123 Main St Plovdiv",
				Email = "admin@gmail.com",
				NormalizedEmail = "ADMIN@GMAIL.COM",
				SecurityStamp = Guid.NewGuid().ToString().ToUpper(),
				ConcurrencyStamp = Guid.NewGuid().ToString(),
				TwoFactorEnabled = false,
				EmailConfirmed = false,
				PhoneNumberConfirmed = false,
				AccessFailedCount = 0,
				LockoutEnabled = true,
				PasswordHash = hasher.HashPassword(null, "1234")
			};
			users.Add(user);

			return users.ToArray();
		}
	}
}

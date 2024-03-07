namespace VetApp.Data
{
    using System.Reflection;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using VetApp.Data.Configuration;
    using VetApp.Data.Models;

    public class VetAppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {

        public VetAppDbContext(DbContextOptions<VetAppDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Assembly configAssembly = Assembly.GetAssembly(typeof(VetAppDbContext)) ??
            //						  Assembly.GetExecutingAssembly();

            //builder.ApplyConfigurationsFromAssembly(configAssembly);

            SeedUser(builder);

            builder.ApplyConfiguration(new OwnerEntityConfiguration());
            builder.ApplyConfiguration(new PatientEntityConfiguration());
            builder.ApplyConfiguration(new StatusEntityConfiguration());
            builder.ApplyConfiguration(new ExaminationEntityConfiguration());

            builder.Entity<PatientUser>()
                .HasKey(pu => new { pu.DoctorId, pu.PatientId });

            base.OnModelCreating(builder);
        }

        private static void SeedUser(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
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
            });
        }

        public DbSet<Status> Statuses { get; set; } = null!;

        public DbSet<Owner> Owners { get; set; } = null!;

        public DbSet<Patient> Patients { get; set; } = null!;

        public DbSet<Examination> Examinations { get; set; } = null!;

        public DbSet<PatientUser> PatientsUsers { get; set; } = null!;
    }
}
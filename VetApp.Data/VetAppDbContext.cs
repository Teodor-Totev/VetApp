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
			Assembly configAssembly = Assembly.GetAssembly(typeof(VetAppDbContext)) ??
									  Assembly.GetExecutingAssembly();

			builder.ApplyConfigurationsFromAssembly(configAssembly);

            //builder.ApplyConfiguration(new OwnerEntityConfiguration());
            //builder.ApplyConfiguration(new PatientEntityConfiguration());
            //builder.ApplyConfiguration(new StatusEntityConfiguration());

            // User registration is required to examination seed
            //builder.ApplyConfiguration(new ExaminationEntityConfiguration());

            builder.Entity<PatientUser>()
				.HasKey(pu => new { pu.DoctorId, pu.PatientId });

			base.OnModelCreating(builder);
		}

		public DbSet<Status> Statuses { get; set; } = null!;

		public DbSet<Owner> Owners { get; set; } = null!;

		public DbSet<Patient> Patients { get; set; } = null!;

		public DbSet<Examination> Examinations { get; set; } = null!;

		public DbSet<PatientUser> PatientsUsers { get; set; } = null!;
	}
}
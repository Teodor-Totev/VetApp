namespace VetApp.Data
{
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
			builder.ApplyConfiguration(new OwnerEntityConfiguration());
			builder.ApplyConfiguration(new PatientEntityConfiguration());
			builder.ApplyConfiguration(new StatusEntityConfiguration());
			builder.ApplyConfiguration(new ExaminationEntityConfiguration());
			builder.ApplyConfiguration(new VetUserConfiguration());

			base.OnModelCreating(builder);
		}

		public DbSet<Status> Statuses { get; set; } = null!;

		public DbSet<Owner> Owners { get; set; } = null!;

		public DbSet<Patient> Patients { get; set; } = null!;

		public DbSet<Examination> Examinations { get; set; } = null!;

	}
}
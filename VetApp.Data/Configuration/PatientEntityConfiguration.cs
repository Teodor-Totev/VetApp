using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetApp.Data.Models;

namespace VetApp.Data.Configuration
{
	public class PatientEntityConfiguration : IEntityTypeConfiguration<Patient>
	{
		public void Configure(EntityTypeBuilder<Patient> builder)
		{
			builder
				.HasOne(p => p.Owner)
				.WithMany(o => o.Patients)
				.HasForeignKey(p => p.OwnerId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}

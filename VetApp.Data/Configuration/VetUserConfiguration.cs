using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetApp.Data.Models;

namespace VetApp.Data.Configuration
{
	public class VetUserConfiguration : IEntityTypeConfiguration<VetUser>
	{
		public void Configure(EntityTypeBuilder<VetUser> builder)
		{
			builder
				.Property(u => u.FirstName)
				.HasDefaultValue("Test");

			builder
				.Property(u => u.LastName)
				.HasDefaultValue("Test");
		}
	}
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetApp.Data.Models;

namespace VetApp.Data.Configuration
{
	public class OwnerEntityConfiguration : IEntityTypeConfiguration<Owner>
	{
		public void Configure(EntityTypeBuilder<Owner> builder)
		{
			
		}
	}
}

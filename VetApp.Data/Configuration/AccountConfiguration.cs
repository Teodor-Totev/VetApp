using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.Data.Models;

namespace VetApp.Data.Configuration
{
	public class AccountConfiguration : IEntityTypeConfiguration<VetUser>
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

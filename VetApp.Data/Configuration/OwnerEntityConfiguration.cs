using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetApp.Data.Models;

namespace VetApp.Data.Configuration
{
	public class OwnerEntityConfiguration : IEntityTypeConfiguration<Owner>
	{
		public void Configure(EntityTypeBuilder<Owner> builder)
		{
			builder
				.HasData(GenerateOwners());
		}

		private Owner[] GenerateOwners()
		{
			ICollection<Owner> owners = new HashSet<Owner>();

			Owner owner;
			 owner = new()
			{
				Id = Guid.Parse("e90872c9-5b9b-412c-a5a5-ee871bbe9299"),
				Address = "гр.Стара Загора",
				Name = "Иван",
				PhoneNumber = "+359876123123",
				PatientId = 1
			};
			owners.Add(owner);

			owner = new()
			{
				Id = Guid.Parse("10d3246c-45e8-4492-9f3e-a1f1d3c4e033"),
				Address = "гр.Димитровград",
				Name = "Марко",
				PhoneNumber = "+359878255255",
				PatientId = 2
			};
			owners.Add(owner);

			owner = new()
			{
				Id = Guid.Parse("6625a7bb-93ea-4bad-b228-a408be9725e9"),
				Address = "гр.Хасково",
				Name = "Пенка",
				PhoneNumber = "+359988989898",
				PatientId = 3
			};
			owners.Add(owner);

			return owners.ToArray();
		}
	}
}

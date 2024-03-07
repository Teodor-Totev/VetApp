namespace VetApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using VetApp.Data.Models;

    public class OwnerEntityConfiguration : IEntityTypeConfiguration<Owner>
	{
		public void Configure(EntityTypeBuilder<Owner> builder)
		{
			builder
				.Property(o => o.IsActive)
				.HasDefaultValue(true);

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
				Address = "ул. Света Параскева 10, София 1000",
				Name = "Ivan",
				PhoneNumber = "+359876123123",
			};
			owners.Add(owner);

			owner = new()
			{
				Id = Guid.Parse("10d3246c-45e8-4492-9f3e-a1f1d3c4e033"),
				Address = "бул. Цариградско шосе 24, Пловдив 4000",
				Name = "Milko",
				PhoneNumber = "+359878255255",
			};
			owners.Add(owner);

			owner = new()
			{
				Id = Guid.Parse("6625a7bb-93ea-4bad-b228-a408be9725e9"),
				Address = "жк. Лозенец, ул. Розова долина 7, Варна 9000",
				Name = "Dimo",
				PhoneNumber = "+359988989898",
			};
			owners.Add(owner);

            owner = new()
            {
                Id = Guid.Parse("2e8fb8ae-6d2e-46a9-af4a-0b14ab081476"),
                Address = "ул. Дунав 15, Велико Търново 5000",
                Name = "Mihaela",
                PhoneNumber = "+359878358235",
            };
            owners.Add(owner);

            return owners.ToArray();
		}
	}
}

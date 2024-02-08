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

			builder
				.HasData(GeneratePatients());
		}

		private Patient[] GeneratePatients()
		{
			ICollection<Patient> patients = new HashSet<Patient>();

			Patient patient;

			patient = new()
			{
				Id = 1,
				Name = "Ласи",
				Type = "Куче",
				Gender = "Male",
				Neutered = "No",
				OwnerId = Guid.Parse("e90872c9-5b9b-412c-a5a5-ee871bbe9299"),
			};
			patients.Add(patient);

			patient = new()
			{
				Id = 2,
				Name = "Том",
				Type = "Котка",
				Gender = "Male",
				Neutered = "Homeless",
				OwnerId = Guid.Parse("10d3246c-45e8-4492-9f3e-a1f1d3c4e033"),
			};
			patients.Add(patient);

			patient = new()
			{
				Id = 3,
				Name = "Джери",
				Type = "Хамстер",
				Gender = "Female",
				Neutered = "Yes",
				OwnerId = Guid.Parse("6625a7bb-93ea-4bad-b228-a408be9725e9"),
			};
			patients.Add(patient);

			return patients.ToArray();
		}
	}
}

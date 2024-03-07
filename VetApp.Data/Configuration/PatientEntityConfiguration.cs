namespace VetApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using VetApp.Data.Models;
    using VetApp.Data.Common.Enums.Patient;
    using System.Reflection.Emit;

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
                .Property(p => p.IsActive)
            .HasDefaultValue(true);

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
                Name = "Lasi",
                Type = "Dog",
                Gender = PatientGender.Male,
                Neutered = PatientNeutered.No,
                OwnerId = Guid.Parse("e90872c9-5b9b-412c-a5a5-ee871bbe9299"),
            };
            patients.Add(patient);

            patient = new()
            {
                Id = 2,
                Name = "Tom",
                Type = "Cat",
                Gender = PatientGender.Male,
                Neutered = PatientNeutered.Homeless,
                OwnerId = Guid.Parse("10d3246c-45e8-4492-9f3e-a1f1d3c4e033"),
            };
            patients.Add(patient);

            patient = new()
            {
                Id = 3,
                Name = "Djeri",
                Type = "Mouse",
                Gender = PatientGender.Female,
                Neutered = PatientNeutered.Yes,
                OwnerId = Guid.Parse("6625a7bb-93ea-4bad-b228-a408be9725e9"),
            };
            patients.Add(patient);

            patient = new()
            {
                Id = 4,
                Name = "Bella",
                Type = "Dog",
                Gender = PatientGender.Female,
                Neutered = PatientNeutered.No,
                OwnerId = Guid.Parse("2e8fb8ae-6d2e-46a9-af4a-0b14ab081476"),
            };
            patients.Add(patient);

            return patients.ToArray();
        }
    }
}

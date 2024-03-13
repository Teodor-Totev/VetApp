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
                Id = Guid.Parse("b19105c4-9a4e-4583-973a-642b8bc06916"),
                Name = "Frank",
                Type = "Dog",
                Gender = PatientGender.Male,
                Neutered = PatientNeutered.No,
                OwnerId = Guid.Parse("e90872c9-5b9b-412c-a5a5-ee871bbe9299"),
            };
            patients.Add(patient);

            patient = new()
            {
                Id = Guid.Parse("ad53d8a9-6ac2-4ab1-bf68-dfb4292e56ab"),
                Name = "Tom",
                Type = "Cat",
                Gender = PatientGender.Male,
                Neutered = PatientNeutered.Homeless,
                OwnerId = Guid.Parse("10d3246c-45e8-4492-9f3e-a1f1d3c4e033"),
            };
            patients.Add(patient);

            patient = new()
            {
                Id = Guid.Parse("53044ff9-b935-4b5a-a7e0-2203e21b05ea"),
                Name = "Jerry",
                Type = "Mouse",
                Gender = PatientGender.Female,
                Neutered = PatientNeutered.Yes,
                OwnerId = Guid.Parse("6625a7bb-93ea-4bad-b228-a408be9725e9"),
            };
            patients.Add(patient);

            patient = new()
            {
                Id = Guid.Parse("a917fe0d-e64e-40c5-8eeb-b17867ec09e1"),
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

namespace VetApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using VetApp.Data.Models;

    public class ExaminationEntityConfiguration : IEntityTypeConfiguration<Examination>
    {
        public ExaminationEntityConfiguration()
        {
            
        }
        public void Configure(EntityTypeBuilder<Examination> builder)
        {
            builder
            .HasData(GenerateExaminations());
        }

        private Examination[] GenerateExaminations()
        {
            ICollection<Examination> examinations = new HashSet<Examination>();


            Examination examination;
            examination = new()
            {
                Id = Guid.Parse("a6be4500-3245-4ecc-a9f5-5b2af8baff97"),
                Reason = "Primary",
                CreatedOn = DateTime.UtcNow,
                Weight = 12,
                DoctorId = Guid.Parse("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                PatientId = Guid.Parse("b19105c4-9a4e-4583-973a-642b8bc06916"),
                StatusId = 1
            };
            examinations.Add(examination);

            examination = new()
            {
                Id = Guid.Parse("917f60f0-485a-4cbc-a3d5-83bfc30015ed"),
                Reason = "Secondary",
                CreatedOn = DateTime.UtcNow,
                Weight = 10,
                DoctorId = Guid.Parse("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                PatientId = Guid.Parse("ad53d8a9-6ac2-4ab1-bf68-dfb4292e56ab"),
                StatusId = 3
            };
            examinations.Add(examination);

            examination = new()
            {
                Id = Guid.Parse("c84db966-6f32-44af-8026-d142b1ea15b9"),
                Reason = "Primary",
                CreatedOn = DateTime.UtcNow,
                Weight = 30,
                DoctorId = Guid.Parse("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                PatientId = Guid.Parse("53044ff9-b935-4b5a-a7e0-2203e21b05ea"),
                StatusId = 3
            };
            examinations.Add(examination);

            examination = new()
            {
                Id = Guid.Parse("b05fb0d0-9e05-4c00-a9e7-d3f0600e566b"),
                Reason = "Primary",
                CreatedOn = DateTime.UtcNow,
                Weight = 25,
                DoctorId = Guid.Parse("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                PatientId = Guid.Parse("a917fe0d-e64e-40c5-8eeb-b17867ec09e1"),
                StatusId = 4
            };
            examinations.Add(examination);


            return examinations.ToArray();
        }
    }
}

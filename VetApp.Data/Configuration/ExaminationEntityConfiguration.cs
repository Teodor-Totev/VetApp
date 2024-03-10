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
                Id = 1,
                Reason = "Primary",
                CreatedOn = DateTime.UtcNow,
                Weight = 12,
                DoctorId = Guid.Parse("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                PatientId = 1,
                StatusId = 1
            };
            examinations.Add(examination);

            examination = new()
            {
                Id = 2,
                Reason = "Secondary",
                CreatedOn = DateTime.UtcNow,
                Weight = 10,
                DoctorId = Guid.Parse("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                PatientId = 2,
                StatusId = 3
            };
            examinations.Add(examination);

            examination = new()
            {
                Id = 3,
                Reason = "Primary",
                CreatedOn = DateTime.UtcNow,
                Weight = 30,
                DoctorId = Guid.Parse("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                PatientId = 3,
                StatusId = 3
            };
            examinations.Add(examination);

            examination = new()
            {
                Id = 4,
                Reason = "Primary",
                CreatedOn = DateTime.UtcNow,
                Weight = 25,
                DoctorId = Guid.Parse("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                PatientId = 4,
                StatusId = 4
            };
            examinations.Add(examination);


            return examinations.ToArray();
        }
    }
}

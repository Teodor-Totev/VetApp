namespace VetApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using VetApp.Data.Models;

    public class ExaminationEntityConfiguration : IEntityTypeConfiguration<Examination>
	{
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
                DoctorId = Guid.Parse("67D4E605-D264-48D5-44C9-08DC28F5B9F5"),
				PatientId = 1,
			};
			examinations.Add(examination);

			examination = new()
			{
				Id = 2,
				DoctorId = Guid.Parse("67D4E605-D264-48D5-44C9-08DC28F5B9F5"),
				PatientId = 2,
			};
			examinations.Add(examination);

			examination = new()
			{
				Id = 3,
				DoctorId = Guid.Parse("67D4E605-D264-48D5-44C9-08DC28F5B9F5"),
				PatientId = 3,
			};
			examinations.Add(examination);

			return examinations.ToArray();
		}
	}
}

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
                User = "D-r Pesho Petrov",
                PatientId = 1,
			};
			examinations.Add(examination);

			examination = new()
			{
				Id = 2,
                User = "D-r Gosho Georgiev",
                PatientId = 2,
			};
			examinations.Add(examination);

			examination = new()
			{
				Id = 3,
				User = "D-r Dimitrichko Dimitrov",
				PatientId = 3,
			};
			examinations.Add(examination);

			return examinations.ToArray();
		}
	}
}

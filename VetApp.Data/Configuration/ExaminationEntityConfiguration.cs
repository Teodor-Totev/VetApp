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
					Reason = "Primary",
					CreatedOn = DateTime.UtcNow,
					Weight = 12,
					DoctorId = Guid.Parse("67D4E605-D264-48D5-44C9-08DC28F5B9F5"),
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
					DoctorId = Guid.Parse("67D4E605-D264-48D5-44C9-08DC28F5B9F5"),
					PatientId = 2,
					StatusId = 2
				};
				examinations.Add(examination);

				examination = new()
				{
					Id = 3,
					Reason = "Primary",
					CreatedOn = DateTime.UtcNow,
					Weight = 30,
					DoctorId = Guid.Parse("67D4E605-D264-48D5-44C9-08DC28F5B9F5"),
					PatientId = 3,
					StatusId = 3
				};
				examinations.Add(examination);
			

			return examinations.ToArray();
		}
	}
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.Data.Models;

namespace VetApp.Data.Configuration
{
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
				CreatedOn = DateTime.Now.AddDays(-20),
				Description = "Пълна кръвна картина",
				State = "Primary",
				PatientId = 1,
			};
			examinations.Add(examination);

			examination = new()
			{
				Id = 2,
				CreatedOn = DateTime.Now.AddMonths(-6),
				Description = "Изследване за паразити",
				State = "Secondary",
				PatientId = 2,
			};
			examinations.Add(examination);

			examination = new()
			{
				Id = 3,
				CreatedOn = DateTime.Now.AddYears(-1),
				Description = "Преглед за кожно заболяване",
				State = "Primary",
				PatientId = 3,
			};
			examinations.Add(examination);

			return examinations.ToArray();
		}
	}
}

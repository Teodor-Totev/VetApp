namespace VetApp.Data.Configuration
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using VetApp.Data.Models;

	public class StatusEntityConfiguration : IEntityTypeConfiguration<Status>
	{
		public void Configure(EntityTypeBuilder<Status> builder)
		{
			builder
				.HasData(GenerateStatuses());
		}

		private Status[] GenerateStatuses()
		{
			ICollection<Status> statuses = new HashSet<Status>();

			Status status;
			status = new()
			{
				Id = 1,
				Name = "In Progress",
			};
			statuses.Add(status);

			status = new()
			{
				Id = 2,
				Name = "Done",
			};
			statuses.Add(status);

			status = new()
			{
				Id = 3,
				Name = "Hospital",
			};
			statuses.Add(status);

			status = new()
			{
				Id = 4,
				Name = "New",
			};
			statuses.Add(status);

			return statuses.ToArray();
		}
	}
}

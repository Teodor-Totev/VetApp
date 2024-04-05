namespace VetApp.Tests.Mocks
{
	using Microsoft.EntityFrameworkCore;
	using VetApp.Data;

	public class DataBaseMock
	{
		public static VetAppDbContext Instance
		{
			get
			{
				var options = new DbContextOptionsBuilder<VetAppDbContext>()
				.UseInMemoryDatabase(databaseName: "VetAppInMemoryDb")
				.Options;

				return new VetAppDbContext(options);
			}
		}
	}
}

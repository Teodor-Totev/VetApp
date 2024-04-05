namespace VetApp.Tests.UnitTests
{
	using NUnit.Framework;
	using System;
	using VetApp.Data;
	using VetApp.Data.Common.Enums.Patient;
	using VetApp.Data.Models;
	using VetApp.Tests.Mocks;

	public class UnitTestsBase
	{
		protected VetAppDbContext context;

		[OneTimeSetUp]
		public void SetUpBase()
		{
			this.context = DataBaseMock.Instance;
			SeedDatabase();
		}

		public ApplicationUser Doctor { get; set; }

		public Examination Examination { get; set; }

		public Status Status { get; set; }

		public Patient Patient { get; set; }

		public Owner Owner { get; set; }

		private void SeedDatabase()
		{
			Examination = new Examination()
			{
				Id = Guid.Parse("a6be4500-3245-4ecc-a9f5-5b2af8baff97"),
				Weight = 12,
				Reason = "Primary",
				CreatedOn = DateTime.UtcNow.AddDays(-7),
				MedicalHistory = "With an unstable state",
				CurrentCondition = "CurrentCondition Is Very Good",
				SpecificCondition = "SpecificCondition is good also",
				Research = "Saome research if...",
				Diagnosis = "some diagnosis here",
				Surgery = "No surgery",
				Therapy = "No",
				Exit = "sumnitelen",
				StatusId = 1,
				DoctorId = Guid.Parse("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
				PatientId = Guid.Parse("b19105c4-9a4e-4583-973a-642b8bc06916"),
				IsActive = true,
			};
			context.Examinations.Add(Examination);
			Doctor = new ApplicationUser()
			{
				Id = Guid.Parse("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
				UserName = "r_raykov",
				FirstName = "Radoslav",
				LastName = "Raykov",
				Address = "123 Main St Haskovo",
				Email = "r_raykov@gmail.com",
			};
			context.Users.Add(Doctor);
			Status = new Status()
			{
				Id = 1,
				Name = "InProgress"
			};
			context.Statuses.Add(Status);
			Owner = new Owner()
			{
				Id = Guid.Parse("e90872c9-5b9b-412c-a5a5-ee871bbe9299"),
				Address = "ул. Света Параскева 10, София 1000",
				Name = "Ivan",
				PhoneNumber = "+359876123123",
				IsActive = true,
			};
			context.Owners.Add(Owner);
			Patient = new Patient()
			{
				Id = Guid.Parse("b19105c4-9a4e-4583-973a-642b8bc06916"),
				Name = "Frank",
				Type = "Dog",
				Gender = PatientGender.Male,
				Neutered = PatientNeutered.No,
				OwnerId = Guid.Parse("e90872c9-5b9b-412c-a5a5-ee871bbe9299"),
				IsActive = true,
			};
			context.Patients.Add(Patient);
			context.SaveChanges();
		}

		[OneTimeTearDown]
		public void TearDownBase()
			=> context.Dispose();
	}
}

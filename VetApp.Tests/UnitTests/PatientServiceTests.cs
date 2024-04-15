namespace VetApp.Tests.UnitTests
{
	using Microsoft.EntityFrameworkCore;
	using NUnit.Framework;
	using VetApp.Data.Models;
	using VetApp.Services;
	using VetApp.Services.Interfaces;
	using VetApp.Web.ViewModels.Patient;
	using Data.Common.Enums.Patient;

	[TestFixture]
	public class PatientServiceTests : UnitTestsBase
	{
		private IPatientService patientService;

		[OneTimeSetUp]
		public void SetUp()
		{
			patientService = new PatientService(context);
		}

		[Test]
		public async Task CreateAsync_ShouldCreatePatientAndReturnPatientId()
		{
			var model = new PatientFormModel
			{
				Name = "Frank",
				Type = "Dog",
				Gender = PatientGender.Male,
				BirthDate = DateTime.Parse("2015-10-08"),
				Neutered = PatientNeutered.Yes,
				Microchip = "123456789",
				Characteristics = "Friendly",
				ChronicIllnesses = "None",
				Owner = new OwnerViewModel
				{
					PhoneNumber = "1234567890",
					Address = "123 Main St",
					Name = "John Doe",
					Email = "johndoe@example.com"
				}
			};

			var doctor = new ApplicationUser
			{
				Id = Guid.NewGuid(),
				FirstName = "John",
				LastName = "Smith"
			};

			context.Users.Add(doctor);
			await context.SaveChangesAsync();

			var result = await patientService.CreateAsync(model, doctor.Id.ToString());


			var patient = await context.Patients.Include(p => p.Owner).FirstOrDefaultAsync(p => p.Id.ToString() == result);

			Assert.IsNotNull(patient);
			Assert.That(model.Name, Is.EqualTo(patient.Name));
			Assert.That(model.Type, Is.EqualTo(patient.Type));
			Assert.That(model.Gender, Is.EqualTo(patient.Gender));
			Assert.That(model.BirthDate, Is.EqualTo(patient.BirthDate));
			Assert.That(model.Neutered, Is.EqualTo(patient.Neutered));
			Assert.That(model.Microchip, Is.EqualTo(patient.Microchip));
			Assert.That(model.Characteristics, Is.EqualTo(patient.Characteristics));
			Assert.That(model.ChronicIllnesses, Is.EqualTo(patient.ChronicIllnesses));

			Assert.IsNotNull(patient.Owner);
			Assert.That(patient.Owner.PhoneNumber, Is.EqualTo(model.Owner.PhoneNumber));
			Assert.That(patient.Owner.Address, Is.EqualTo(model.Owner.Address));
			Assert.That(patient.Owner.Name, Is.EqualTo(model.Owner.Name));
			Assert.That(patient.Owner.Email, Is.EqualTo(model.Owner.Email));
		}

	}
}

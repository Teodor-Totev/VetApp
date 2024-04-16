namespace VetApp.Tests.UnitTests
{
	using Microsoft.EntityFrameworkCore;
	using NUnit.Framework;
	using VetApp.Data.Models;
	using VetApp.Services;
	using VetApp.Services.Interfaces;
	using VetApp.Web.ViewModels.Patient;
	using Data.Common.Enums.Patient;
	using VetApp.Web.ViewModels.Patient.Enums;

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
				Name = "Buddy",
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

			var result = await patientService.CreateAsync(model, Doctor.Id.ToString());

			Assert.IsNotNull(result);
			Assert.IsNotEmpty(result);

			var patient = await context.Patients
				.Include(p => p.Owner)
				.FirstOrDefaultAsync(p => p.Id.ToString() == result);

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

		[Test]
		public async Task AddPetAsync_ShouldAddPetAndReturnPetId()
		{
			var model = new AddPetViewModel
			{
				Name = "Buddy",
				Type = "Dog",
				Gender = PatientGender.Male,
				BirthDate = DateTime.Parse("2015-10-08"),
				Neutered = PatientNeutered.Yes,
				Microchip = "123456789",
				Characteristics = "Friendly",
				ChronicIllnesses = "None"
			};

			var ownerId = "e90872c9-5b9b-412c-a5a5-ee871bbe9299";  
			var doctorId = "b19105c4-9a4e-4583-973a-642b8bc06916";

			var owner = await context.Owners.FindAsync(Guid.Parse(ownerId));

			var result = await patientService.AddPetAsync(model, ownerId, doctorId);

			Assert.IsNotNull(result);
			Assert.IsNotEmpty(result);

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
			Assert.That(patient.Owner.Id.ToString(), Is.EqualTo(ownerId));
		}

		[Test]
		public async Task EditPatientAsync_ShouldUpdatePatientDetails()
		{
			var patientId = Patient.Id.ToString();

			var model = new PatientEditViewModel
			{
				Name = "Buddy",
				Type = "Dog",
				Gender = PatientGender.Male,
				Neutered = PatientNeutered.Yes,
				BirthDate = DateTime.Parse("2015-10-08"),
				Microchip = "123456789",
				Characteristics = "Friendly",
				ChronicIllnesses = "None"
			};

			await patientService.EditPatientAsync(model, patientId);

			var updatedPatient = await context.Patients.FindAsync(Guid.Parse(patientId));

			Assert.IsNotNull(updatedPatient);
			Assert.That(model.Name, Is.EqualTo(updatedPatient.Name));
			Assert.That(model.Type, Is.EqualTo(updatedPatient.Type));
			Assert.That(model.Gender, Is.EqualTo(updatedPatient.Gender));
			Assert.That(model.Neutered, Is.EqualTo(updatedPatient.Neutered));
			Assert.That(model.BirthDate, Is.EqualTo(updatedPatient.BirthDate));
			Assert.That(model.Microchip, Is.EqualTo(updatedPatient.Microchip));
			Assert.That(model.Characteristics, Is.EqualTo(updatedPatient.Characteristics));
			Assert.That(model.ChronicIllnesses, Is.EqualTo(updatedPatient.ChronicIllnesses));
		}

		[Test]
		public async Task PatientExistsAsync_ShouldReturnTrueForExistingPatient()
		{
			var existingPatientId = Patient.Id.ToString();

			var result = await patientService.PatientExistsAsync(existingPatientId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task PatientExistsAsync_ShouldReturnFalseForNonExistingPatient()
		{
			var nonExistingPatientId = "some-non-existing-id";

			var result = await patientService.PatientExistsAsync(nonExistingPatientId);

			Assert.IsFalse(result);
		}

		[Test]
		public async Task GetAllPatientsAsync_ShouldReturnAllActivePatients()
		{
			var queryModel = new AllPatientsQueryModel
			{
				CurrentPage = 1,
				PatientsPerPage = 10
			};

			var result = await patientService.GetAllPatientsAsync(queryModel);

			Assert.That(result.Patients.Count, Is.EqualTo(1)); 
			Assert.That(result.TotalPatientsCount, Is.EqualTo(1));
		}

		[Test]
		public async Task GetAllPatientsAsync_ShouldReturnFilteredPatients()
		{
			var queryModel = new AllPatientsQueryModel
			{
				CurrentPage = 1,
				PatientsPerPage = 10,
				SearchString = "Frank" 
			};

			var result = await patientService.GetAllPatientsAsync(queryModel);

			Assert.That(result.Patients.Count, Is.EqualTo(1)); 
			Assert.That(result.TotalPatientsCount, Is.EqualTo(1));
		}

		[Test]
		public async Task GetAllPatientsAsync_ShouldReturnPatientsOrderedByNameAscending()
		{
			var queryModel = new AllPatientsQueryModel
			{
				CurrentPage = 1,
				PatientsPerPage = 10,
				PatientSorting = PatientSorting.PatientNameAscending
			};

			var model = new Patient
			{
				Name = "Buddy",
				Type = "Dog",
				Gender = PatientGender.Male,
				BirthDate = DateTime.Parse("2015-10-08"),
				Neutered = PatientNeutered.Yes,
				Microchip = "123456789",
				Characteristics = "Friendly",
				ChronicIllnesses = "None",
				OwnerId = Owner.Id,
				IsActive = true
			};
			context.Patients.Add(model);
			await context.SaveChangesAsync();

			var result = await patientService.GetAllPatientsAsync(queryModel);

			Assert.That(result.TotalPatientsCount, Is.EqualTo(2));
			Assert.That(result.Patients.Skip(1).Take(1).First().Name, Is.EqualTo("Frank"));
		}
		
		[Test]
		public async Task GetAllPatientsAsync_ShouldReturnPatientsOrderedByNameDescending()
		{
			var queryModel = new AllPatientsQueryModel
			{
				CurrentPage = 1,
				PatientsPerPage = 10,
				PatientSorting = PatientSorting.PatientNameDescending
			};

			var model = new AddPetViewModel
			{
				Name = "Buddy",
				Type = "Dog",
				Gender = PatientGender.Male,
				BirthDate = DateTime.Parse("2015-10-08"),
				Neutered = PatientNeutered.Yes,
				Microchip = "123456789",
				Characteristics = "Friendly",
				ChronicIllnesses = "None"
			};

			patientService.AddPetAsync(model, Owner.Id.ToString(), Doctor.Id.ToString());

			var result = await patientService.GetAllPatientsAsync(queryModel);

			Assert.That(result.Patients.First().Name, Is.EqualTo("Frank"));  
			Assert.That(context.Patients.Count(), Is.EqualTo(2));
		}

		[Test]
		public async Task GetAllPatientsAsync_ShouldReturnPatientsOrderedByOwnerNameDescending()
		{
			var queryModel = new AllPatientsQueryModel
			{
				CurrentPage = 1,
				PatientsPerPage = 10,
				PatientSorting = PatientSorting.OwnerNameDescending
			};

			var result = await patientService.GetAllPatientsAsync(queryModel);

			Assert.That(result.Patients.First().OwnerName, Is.EqualTo("Ivan"));
		}

		[Test]
		public async Task GetAllPatientsAsync_ShouldReturnPatientsOrderedByOwnerNameAscending()
		{
			var queryModel = new AllPatientsQueryModel
			{
				CurrentPage = 1,
				PatientsPerPage = 10,
				PatientSorting = PatientSorting.OwnerNameAscending
			};

			var model = new Patient
			{
				Name = "Buddy",
				Type = "Dog",
				Gender = PatientGender.Male,
				BirthDate = DateTime.Parse("2015-10-08"),
				Neutered = PatientNeutered.Yes,
				Microchip = "123456789",
				Characteristics = "Friendly",
				ChronicIllnesses = "None",
				Owner = new Owner 
				{
					Address = "st. Main 12 5000 Tsarevo",
					Name = "Gosho",
					PhoneNumber = "+359123456789",
					IsActive = true,
				},
				OwnerId = Owner.Id,
				IsActive = true
			};
			context.Patients.Add(model);
			await context.SaveChangesAsync();

			var result = await patientService.GetAllPatientsAsync(queryModel);

			Assert.That(result.TotalPatientsCount, Is.EqualTo(2));
			Assert.That(result.Patients.First().OwnerName, Is.EqualTo("Gosho"));
		}

		[Test]
		public async Task GetAllPatientsForUserAsync_ShouldReturnFilteredAndSortedPatients()
		{
			var queryModel = new AllPatientsQueryModel
			{
				SearchString = "Frank",
				PatientSorting = PatientSorting.PatientNameAscending,
				CurrentPage = 1,
				PatientsPerPage = 10
			};

			var result = await patientService.GetAllPatientsForUserAsync(queryModel, Doctor.Id.ToString());

			Assert.IsNotNull(result);
			Assert.That(result.Patients.Count, Is.EqualTo(1));
			Assert.That(result.Patients.First().Name, Is.EqualTo("Frank"));
			Assert.That(result.Patients.First().OwnerName, Is.EqualTo("Ivan")); 
		}

		[Test]
		public async Task DoesPatientExistInOwnerCollection_ShouldReturnTrueIfPatientExists()
		{
			var patientName = "Frank";

			var result = await patientService.DoesPatientExistInOwnerCollection(Owner.Id.ToString(), patientName);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task GetOwnerPetsAsync_ShouldReturnCorrectNumberOfPetsAndOrderedByName()
		{
			var currentPgae = 1;

			var result = await patientService.GetOwnerPetsAsync(Owner.Id.ToString(), currentPgae);

			Assert.IsNotNull(result);
			Assert.That(result.Patients.Count(), Is.EqualTo(1));
			Assert.That(result.Patients.First().Name, Is.EqualTo("Frank"));
			Assert.That(result.TotalItems, Is.EqualTo(1));
		}

		[Test]
		public async Task GetPatientByIdAsync_ShouldReturnCorrectPatient()
		{
			var result = await patientService.GetPatientByIdAsync(Patient.Id.ToString());

			Assert.IsNotNull(result);
			Assert.That(result.Name, Is.EqualTo(Patient.Name));
			Assert.That(result.Type, Is.EqualTo(Patient.Type));
			Assert.That(result.OwnerName, Is.EqualTo(Owner.Name));
			Assert.That(result.OwnerId, Is.EqualTo(Owner.Id.ToString()));
			Assert.That(result.Gender, Is.EqualTo(PatientGender.Male));
			Assert.That(result.Neutered, Is.EqualTo(PatientNeutered.No));
		}

		[Test]
		public async Task GetPatientForEditByIdAsync_ShouldReturnCorrectPatientForEdit()
		{
			PatientEditViewModel result = await patientService.GetPatientForEditByIdAsync(Patient.Id.ToString());

			Assert.IsNotNull(result);
			Assert.That(result.Name, Is.EqualTo("Frank"));
			Assert.That(result.Type, Is.EqualTo("Dog"));
			Assert.That(result.Gender, Is.EqualTo(PatientGender.Male));
			Assert.That(result.Neutered, Is.EqualTo(PatientNeutered.No));
		}

	}
}

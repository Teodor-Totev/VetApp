namespace VetApp.Tests.UnitTests
{
	using Microsoft.EntityFrameworkCore;
	using NUnit.Framework;
	using VetApp.Data.Models;
	using VetApp.Services;
	using VetApp.Services.Interfaces;
	using VetApp.Web.ViewModels.Examination;
	using VetApp.Web.ViewModels.Examination.Enums;

	[TestFixture]
	public class ExaminationServiceTests : UnitTestsBase
	{
		private IExaminationService examinationService;

		[OneTimeSetUp]
		public void SetUp()
		{
			examinationService = new ExaminationService(context);
		}

		[Test]
		public async Task ExistsAsync_ShouldReturnTrue_WithValidExaminationId()
		{
			var id = Examination.Id.ToString();
			bool isExists = await examinationService.ExaminationExistsAsync(id);

			Assert.IsTrue(isExists == true);
		}

		[Test]
		public async Task GetExaminationAsync_ShouldReturnModel_WithValidExaminationId()
		{
			var examinationId = "a6be4500-3245-4ecc-a9f5-5b2af8baff97";

			var expected = await this.context.Examinations
				.Where(e => e.Id.ToString() == examinationId && e.IsActive == true)
				.Select(e => new ExaminationFormModel()
				{
					DoctorId = e.DoctorId.ToString(),
					Weight = e.Weight,
					Reason = e.Reason,
					CreatedOn = e.CreatedOn,
					MedicalHistory = e.MedicalHistory,
					CurrentCondition = e.CurrentCondition,
					SpecificCondition = e.SpecificCondition,
					Research = e.Research,
					Diagnosis = e.Diagnosis,
					Surgery = e.Surgery,
					Therapy = e.Therapy,
					Exit = e.Exit,
					StatusId = e.StatusId
				})
				.FirstAsync();

			var result = await examinationService.GetExaminationByIdAsync(examinationId);

			Assert.IsNotNull(result);
			Assert.That(result.DoctorId, Is.EqualTo(expected.DoctorId));
			Assert.That(result.Weight, Is.EqualTo(expected.Weight));
			Assert.That(result.Reason, Is.EqualTo(expected.Reason));
			Assert.That(result.CreatedOn, Is.EqualTo(expected.CreatedOn));
			Assert.That(result.MedicalHistory, Is.EqualTo(expected.MedicalHistory));
			Assert.That(result.CurrentCondition, Is.EqualTo(expected.CurrentCondition));
			Assert.That(result.SpecificCondition, Is.EqualTo(expected.SpecificCondition));
			Assert.That(result.Research, Is.EqualTo(expected.Research));
			Assert.That(result.Diagnosis, Is.EqualTo(expected.Diagnosis));
			Assert.That(result.Surgery, Is.EqualTo(expected.Surgery));
			Assert.That(result.Therapy, Is.EqualTo(expected.Therapy));
			Assert.That(result.Exit, Is.EqualTo(expected.Exit));
			Assert.That(result.StatusId, Is.EqualTo(expected.StatusId));
		}

		[Test]
		public async Task AddAsync_ShouldAddExaminationToPatientAndSaveChanges()
		{
			string patientId = Patient.Id.ToString();
			string doctorId = Doctor.Id.ToString();

			var model = new ExaminationFormModel
			{
				DoctorId = doctorId,
				CreatedOn = DateTime.Now,
				Weight = 70,
				Reason = "Reason",
				MedicalHistory = "MedicalHistory",
				CurrentCondition = "CurrentCondition",
				SpecificCondition = "SpecificCondition",
				Research = "Research",
				Diagnosis = "Diagnosis",
				Surgery = "Surgery",
				Therapy = "Therapy",
				Exit = "Exit",
				StatusId = 4,
			};

			await examinationService.AddAsync(model, patientId, doctorId);

			var addedExamination = context.Examinations.FirstOrDefault(e => e.Weight == model.Weight);

			Assert.IsNotNull(addedExamination);
			Assert.That(addedExamination.DoctorId, Is.EqualTo(Guid.Parse(model.DoctorId)));
			Assert.That(addedExamination.Weight, Is.EqualTo(model.Weight));
			Assert.That(addedExamination.Reason, Is.EqualTo(model.Reason));
			Assert.That(addedExamination.CreatedOn, Is.EqualTo(model.CreatedOn));
			Assert.That(addedExamination.MedicalHistory, Is.EqualTo(model.MedicalHistory));
			Assert.That(addedExamination.CurrentCondition, Is.EqualTo(model.CurrentCondition));
			Assert.That(addedExamination.SpecificCondition, Is.EqualTo(model.SpecificCondition));
			Assert.That(addedExamination.Research, Is.EqualTo(model.Research));
			Assert.That(addedExamination.Diagnosis, Is.EqualTo(model.Diagnosis));
			Assert.That(addedExamination.Surgery, Is.EqualTo(model.Surgery));
			Assert.That(addedExamination.Therapy, Is.EqualTo(model.Therapy));
			Assert.That(addedExamination.Exit, Is.EqualTo(model.Exit));
			Assert.That(addedExamination.StatusId, Is.EqualTo(model.StatusId));

			var patientWithExamination = context.Patients.FirstOrDefault(p => p.Id.ToString() == patientId);

			Assert.IsNotNull(patientWithExamination);
			Assert.That(patientWithExamination.Examinations.Count, Is.EqualTo(2));
			Assert.That(patientWithExamination.Examinations.Skip(1).First().Id, Is.EqualTo(addedExamination.Id));
		}

		[Test]
		public async Task EditExaminationAsync_ShouldUpdateExaminationAndSaveChanges()
		{
			var model = new ExaminationFormModel
			{
				Weight = 80,
				Reason = "Updated Reason",
				MedicalHistory = "Updated Medical History",
				CurrentCondition = "Updated Current Condition",
				SpecificCondition = "Updated Specific Condition",
				Research = "Updated Research",
				Diagnosis = "Updated Diagnosis",
				Surgery = "Updated Surgery",
				Therapy = "Updated Therapy",
				Exit = "Updated Exit",
				StatusId = 2,
				CreatedOn = DateTime.Now.AddDays(-1),
			};
			string examinationId = Examination.Id.ToString();

			await examinationService.EditExaminationAsync(model, examinationId);

			var updatedExamination = context.Examinations.Find(Guid.Parse(examinationId));

			Assert.IsNotNull(updatedExamination);
			Assert.That(updatedExamination.Weight, Is.EqualTo(model.Weight));
			Assert.That(updatedExamination.Reason, Is.EqualTo(model.Reason));
			Assert.That(updatedExamination.MedicalHistory, Is.EqualTo(model.MedicalHistory));
			Assert.That(updatedExamination.CurrentCondition, Is.EqualTo(model.CurrentCondition));
			Assert.That(updatedExamination.SpecificCondition, Is.EqualTo(model.SpecificCondition));
			Assert.That(updatedExamination.Research, Is.EqualTo(model.Research));
			Assert.That(updatedExamination.Diagnosis, Is.EqualTo(model.Diagnosis));
			Assert.That(updatedExamination.Surgery, Is.EqualTo(model.Surgery));
			Assert.That(updatedExamination.Therapy, Is.EqualTo(model.Therapy));
			Assert.That(updatedExamination.Exit, Is.EqualTo(model.Exit));
			Assert.That(updatedExamination.StatusId, Is.EqualTo(model.StatusId));
			Assert.That(updatedExamination.CreatedOn, Is.EqualTo(model.CreatedOn));
		}

		[Test]
		public async Task GetExaminationDetailsByIdAsync_ShouldReturnExaminationDetailsViewModel()
		{
			string examinationId = Examination.Id.ToString();

			var result = await examinationService.GetExaminationDetailsByIdAsync(examinationId);

			Assert.IsNotNull(result);
			Assert.That(result.Id, Is.EqualTo(examinationId));
			Assert.That(result.Weight, Is.EqualTo(Examination.Weight));
			Assert.That(result.Reason, Is.EqualTo(Examination.Reason));
			Assert.That(result.Diagnosis, Is.EqualTo(Examination.Diagnosis));
			Assert.That(result.CreatedOn, Is.EqualTo(Examination.CreatedOn));
			Assert.That(result.Surgery, Is.EqualTo(Examination.Surgery));
			Assert.That(result.DoctorName, Is.EqualTo($"{Doctor.FirstName} {Doctor.LastName}"));
			Assert.That(result.Therapy, Is.EqualTo(Examination.Therapy));
			Assert.That(result.StatusName, Is.EqualTo(Status.Name));
			Assert.That(result.SpecificCondition, Is.EqualTo(Examination.SpecificCondition));
			Assert.That(result.CurrentCondition, Is.EqualTo(Examination.CurrentCondition));
			Assert.That(result.Exit, Is.EqualTo(Examination.Exit));
			Assert.That(result.MedicalHistory, Is.EqualTo(Examination.MedicalHistory));
			Assert.That(result.Research, Is.EqualTo(Examination.Research));
		}

		[Test]
		public async Task GetExaminationForDeleteByIdAsync_ShouldReturnPreDeleteDetailsViewModel()
		{
			string examinationId = Examination.Id.ToString();

			PreDeleteDetailsViewModel result = 
				await examinationService.GetExaminationForDeleteByIdAsync(examinationId);

			Assert.IsNotNull(result);
			Assert.That(result.GetType(), Is.EqualTo(typeof(PreDeleteDetailsViewModel)));
			Assert.That(result.Id, Is.EqualTo(examinationId));
			Assert.That(result.StatusName, Is.EqualTo(Status.Name));
			Assert.That(result.PatientName, Is.EqualTo(Patient.Name));
			Assert.That(result.DoctorName, Is.EqualTo($"{Doctor.FirstName} {Doctor.LastName}"));
			Assert.That(result.CreatedOn, Is.EqualTo(Examination.CreatedOn));
			Assert.That(result.Reason, Is.EqualTo(Examination.Reason));
			Assert.That(result.Weight, Is.EqualTo(Examination.Weight));
		}

		[Test]
		public async Task DeleteExaminationByIdAsync_ShouldSetIsActiveToFalse()
		{
			string examinationId = Examination.Id.ToString();

			await examinationService.DeleteExaminationByIdAsync(examinationId);

			Examination deletedExamination = await context.Examinations
				.FirstOrDefaultAsync(e => e.Id.ToString() == examinationId);

			Assert.IsNotNull(deletedExamination);
			Assert.IsFalse(deletedExamination.IsActive);
		}

		[Test]
		public async Task GetPatientExaminationsByIdAsync_ShouldReturnCorrectExaminationsForPatient()
		{
			var currentPage = 1;

			var result = await examinationService.GetPatientExaminationsByIdAsync(Patient.Id.ToString(), currentPage);

			Assert.IsNotNull(result);
			Assert.That(result.TotalItems, Is.GreaterThanOrEqualTo(0)); 
			Assert.That(result.PatientExaminations, Is.Not.Null);
			Assert.That(result.PatientExaminations.Count(), Is.EqualTo(1)); 
			foreach (var examination in result.PatientExaminations)
			{
				Assert.IsNotNull(examination);
				Assert.IsNotNull(examination.Id);
				Assert.IsNotNull(examination.PatientId);
				Assert.IsNotNull(examination.DoctorName);
				Assert.IsNotNull(examination.StatusName);
				Assert.IsNotNull(examination.PatientName);
				Assert.IsNotNull(examination.Reason);
				Assert.IsNotNull(examination.CreatedOn);
			}
		}

		[Test]
		public async Task GetAllExaminationsAsync_ShouldReturnCorrectExaminationsAndOrderedByStatusName()
		{
			var model = new AllExaminationsQueryModel
			{
				CurrentPage = 1,
				ExaminationsPerPage = 10,
				ExaminationSorting = ExaminationSorting.StatusAscending,
				SearchString = "Primary" 
			};

			var result = await examinationService.GetAllExaminationsAsync(model);

			Assert.IsNotNull(result);
			Assert.GreaterOrEqual(result.Examinations.Count(), 1);
			Assert.That(result.Examinations.First().Reason, Does.Contain("Primary"));
			Assert.That(result.Examinations.OrderBy(e => e.StatusName).First().StatusName, Is.EqualTo("InProgress")); 
			Assert.GreaterOrEqual(result.TotalItems, 1); 
		}

	}
}

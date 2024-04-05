namespace VetApp.Tests.UnitTests
{
	using Microsoft.EntityFrameworkCore;
	using Moq;
	using NUnit.Framework;
	using VetApp.Data;
	using VetApp.Data.Models;
	using VetApp.Services;
	using VetApp.Services.Interfaces;
	using VetApp.Web.ViewModels.Examination;

	[TestFixture]
	public class ExaminationServiceTests : UnitTestsBase
	{
		private IExaminationService service;

		[OneTimeSetUp]
		public void SetUp()
		{
			service = new ExaminationService(context);
		}

		[Test]
		public async Task ExistsAsync_ShouldReturnTrue_WithValidExaminationId()
		{
			var id = "a6be4500-3245-4ecc-a9f5-5b2af8baff97";
			bool isExists = await service.ExaminationExistsAsync(id);

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

			var result = await service.GetExaminationByIdAsync(examinationId);

			Assert.IsNotNull(result);
			Assert.AreEqual(expected.DoctorId, result.DoctorId);
			Assert.AreEqual(expected.Weight, result.Weight);
			Assert.AreEqual(expected.Reason, result.Reason);
			Assert.AreEqual(expected.CreatedOn, result.CreatedOn);
			Assert.AreEqual(expected.MedicalHistory, result.MedicalHistory);
			Assert.AreEqual(expected.CurrentCondition, result.CurrentCondition);
			Assert.AreEqual(expected.SpecificCondition, result.SpecificCondition);
			Assert.AreEqual(expected.Research, result.Research);
			Assert.AreEqual(expected.Diagnosis, result.Diagnosis);
			Assert.AreEqual(expected.Surgery, result.Surgery);
			Assert.AreEqual(expected.Therapy, result.Therapy);
			Assert.AreEqual(expected.Exit, result.Exit);
			Assert.AreEqual(expected.StatusId, result.StatusId);
		}
	}
}

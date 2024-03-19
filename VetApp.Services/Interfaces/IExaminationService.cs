﻿namespace VetApp.Services.Interfaces
{
	using VetApp.Web.ViewModels.Examination;

    public interface IExaminationService
	{
		Task AddAsync(ExaminationFormModel model, string patientId, string doctorId);

		Task<IEnumerable<ExaminationViewModel>> GetPatientExaminationsByIdAsync(string patientId);

		Task<IEnumerable<ExaminationViewModel>> GetAllExaminationsAsync();


		Task<Dictionary<string, ExaminationDashboardViewModel[]>> GetExaminationsGroupedByStatus();

		Task<ExaminationFormModel> GetExaminationByIdAsync(string examinationId);

		Task EditExaminationAsync(ExaminationFormModel model, string examinationId);

		Task<ExaminationDetailsViewModel> GetExaminationDetailsByIdAsync(string examinationId);

		Task<bool> ExaminationExistsAsync(string examinationId);
	}
}

namespace VetApp.Services.Interfaces
{
	using VetApp.Services.Models.Examination;
	using VetApp.Web.ViewModels.Examination;

    public interface IExaminationService
	{
		Task AddAsync(ExaminationFormModel model, string patientId, string doctorId);

		Task<PatientExaminationsServiceModel> GetPatientExaminationsByIdAsync(string patientId, int currentPage);

		Task<IEnumerable<ExaminationViewModel>> GetAllExaminationsAsync();


		Task<Dictionary<string, ExaminationDashboardViewModel[]>> GetExaminationsGroupedByStatus();

		Task<ExaminationFormModel> GetExaminationByIdAsync(string examinationId);

		Task EditExaminationAsync(ExaminationFormModel model, string examinationId);

		Task<ExaminationDetailsViewModel> GetExaminationDetailsByIdAsync(string examinationId);

		Task<bool> ExaminationExistsAsync(string examinationId);

		Task<PreDeleteDetailsViewModel> GetExaminationForDeleteByIdAsync(string examinationId);

		Task DeleteExaminationByIdAsync(string examinationId);
	}
}

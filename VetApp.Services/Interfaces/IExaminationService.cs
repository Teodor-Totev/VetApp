namespace VetApp.Services.Interfaces
{
    using VetApp.Web.ViewModels.Examination;

    public interface IExaminationService
	{
		Task AddAsync(ExaminationFormModel model, string patientId, string doctorId);

		Task<IEnumerable<PatientExaminationsViewModel>> GetExaminationsForPatientByIdAsync(string patientId);

		Task<IEnumerable<AllExaminationsViewModel>> GetAllExaminationsAsync();


		Task<Dictionary<string, List<ExaminationDashboardViewModel>>> GetExaminationsGroupedByStatus();

		Task<ExaminationFormModel> GetExaminationByIdAsync(string examinationId);

		Task EditExaminationAsync(ExaminationFormModel model, string examinationId);

		Task<ExaminationViewModel> GetExaminationDetailsByIdAsync(string examinationId);
	}
}

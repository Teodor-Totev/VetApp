namespace VetApp.Services.Interfaces
{
    using VetApp.Web.ViewModels.Examination;

    public interface IExaminationService
	{
		Task AddAsync(ExaminationFormModel model, string patientId, string doctorId);

		Task<ICollection<ExaminationViewModel>> GetExaminationsForPatientByIdAsync(string patientId);

        Task<Dictionary<string, List<ExaminationDashboardViewModel>>> GetExaminationsGroupedByStatus();

		Task<ExaminationFormModel> GetExaminationByIdAsync(string examinationId);

		Task EditExaminationAsync(ExaminationFormModel model, string examinationId);

		Task<ExaminationViewModel> GetExaminationDetailsByIdAsync(string examinationId);
	}
}

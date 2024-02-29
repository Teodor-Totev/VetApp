namespace VetApp.Services.Interfaces
{
    using VetApp.Web.ViewModels.Examination;

    public interface IExaminationService
	{
		Task AddAsync(ExaminationFormModel model, int patientId, string doctorId);

		Task<ICollection<ExaminationViewModel>> GetPatientExaminationsAsync(int patientId);

        Task<Dictionary<string, List<ExaminationDashboardViewModel>>> GetExaminationsGroupedByStatus();

		Task<ExaminationFormModel> GetExaminationByIdAsync(int examinationId);

		Task EditExaminationAsync(ExaminationFormModel model, int examinationId);
	}
}

namespace VetApp.Services.Interfaces
{
    using VetApp.Web.ViewModels.Examination;

    public interface IExaminationService
	{
		Task AddAsync(ExaminationFM model, int patientId, string doctorId);

		Task<ICollection<ExaminationVM>> GetPatientExaminationsAsync(int patientId);

        Task<Dictionary<string, List<ExaminationDashboardVM>>> GetExaminationsGroupedByStatus();

		Task<ExaminationFM> GetExaminationByIdAsync(int examinationId);

		Task EditExaminationAsync(ExaminationFM model, int examinationId);
	}
}

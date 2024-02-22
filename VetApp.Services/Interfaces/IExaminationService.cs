namespace VetApp.Services.Interfaces
{
    using VetApp.Web.ViewModels.Examination;

    public interface IExaminationService
	{
		Task AddAsync(AddExaminationFM model, int patientId, string doctorId);

		Task<IEnumerable<ExaminationVM>> GetPatientExaminationsAsync(int patientId);
	}
}

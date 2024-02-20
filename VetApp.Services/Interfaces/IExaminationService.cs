namespace VetApp.Services.Interfaces
{
    using VetApp.Web.ViewModels.Examination;

    public interface IExaminationService
	{
		Task AddAsync(AddExaminationFM model, int patientId);

		Task<ICollection<PatientExaminationVM>> GetPatientExaminationsAsync(int patientId);

		
	}
}

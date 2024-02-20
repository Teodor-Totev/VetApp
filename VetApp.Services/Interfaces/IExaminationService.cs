namespace VetApp.Services.Interfaces
{
    using VetApp.Web.ViewModels.Examination;

    public interface IExaminationService
	{
		Task AddAsync(AddExaminationFM model );

		Task<ICollection<PatientExaminationVM>> GetPatientExaminationsAsync(int patientId);

		
	}
}

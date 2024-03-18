namespace VetApp.Web.ViewModels.Examination
{
	using VetApp.Web.ViewModels.Patient;

	public class AddAndEditExaminationViewModel
	{
		public PatientViewModel? Patient { get; set; }

		public ExaminationFormModel Examination { get; set; } = null!;
	}
}

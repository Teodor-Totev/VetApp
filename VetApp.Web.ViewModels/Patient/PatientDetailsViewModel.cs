namespace VetApp.Web.ViewModels.Patient
{
	using System.ComponentModel.DataAnnotations;
	using VetApp.Web.ViewModels.Examination;

	public class PatientDetailsViewModel
	{
        public PatientDetailsViewModel()
        {
            this.Examinations = new HashSet<ExaminationViewModel>();
        }

        public PatientViewModel Patient { get; set; } = null!;

        public IEnumerable<ExaminationViewModel> Examinations{ get; set; }
    }
}

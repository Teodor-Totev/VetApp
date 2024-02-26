namespace VetApp.Web.ViewModels.Patient
{
	using System.ComponentModel.DataAnnotations;
	using VetApp.Web.ViewModels.Examination;

	public class PatientDetailVM
	{
        public PatientDetailVM()
        {
            this.Examinations = new HashSet<ExaminationVM>();
        }

        public PatientVM Patient { get; set; } = null!;

        public ICollection<ExaminationVM> Examinations{ get; set; }
    }
}

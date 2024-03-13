namespace VetApp.Web.ViewModels.Examination
{
	public class PatientExaminationViewModel
    {
        public PatientExaminationViewModel()
        {
            this.Examinations = new HashSet<ExaminationViewModel>();
        }
        
        public string Id { get; set; }

        public IEnumerable<ExaminationViewModel> Examinations { get; set; }
    }
}

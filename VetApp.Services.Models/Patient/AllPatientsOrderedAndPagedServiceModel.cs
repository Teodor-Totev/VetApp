namespace VetApp.Services.Models.Patient
{
    using VetApp.Web.ViewModels.Patient;

    public class AllPatientsOrderedAndPagedServiceModel
    {
        public AllPatientsOrderedAndPagedServiceModel()
        {
            Patients = new HashSet<PatientViewModel>();
        }

        public int TotalPatientsCount { get; set; }

        public ICollection<PatientViewModel> Patients { get; set; }
    }
}

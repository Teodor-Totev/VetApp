namespace VetApp.Web.ViewModels.Owner
{
	using System.Collections.Generic;
	using VetApp.Web.ViewModels.Patient;

	public class OwnerDetailsViewModel
	{
        public OwnerDetailsViewModel()
        {
            this.Patients = new HashSet<PatientViewModel>();
        }

		public OwnerViewModel Owner { get; set; } = null!;

        public IEnumerable<PatientViewModel> Patients { get; set; }
    }
}

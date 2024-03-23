namespace VetApp.Services.Models.Patient
{
	using System.Collections.Generic;
	using VetApp.Web.ViewModels.Patient;

	public  class OwnerPetsServiceModel
	{
        public OwnerPetsServiceModel()
        {
            this.Patients = new HashSet<PatientViewModel>();
        }

        public IEnumerable<PatientViewModel> Patients { get; set; }

        public int TotalItems { get; set; }
    }
}

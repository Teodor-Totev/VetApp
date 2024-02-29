namespace VetApp.Web.ViewModels.Patient
{
	public class OwnerViewModel
	{
		public OwnerViewModel()
		{
			this.Patients = new HashSet<PatientViewModel>();
		}

		public int Id { get; set; }

        public string Address { get; set; } = null!;

		public string OwnerName { get; set; } = null!;

		public string PhoneNumber { get; set; } = null!;

		public IEnumerable<PatientViewModel> Patients { get; set; }
    }
}

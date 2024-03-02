namespace VetApp.Web.ViewModels.Patient
{
	using System.ComponentModel.DataAnnotations;

	public class OwnerViewModel
	{
		public OwnerViewModel()
		{
			this.Patients = new HashSet<PatientViewModel>();
		}

		public string Id { get; set; } = null!;

		public string Name { get; set; } = null!;

		public string Address { get; set; } = null!;

		public string PhoneNumber { get; set; } = null!;

		public string? Email { get; set; }

		public IEnumerable<PatientViewModel> Patients { get; set; }
    }
}

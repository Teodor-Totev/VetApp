namespace VetApp.Web.ViewModels.Patient
{
	using VetApp.Web.ViewModels.Owner;

	public class OwnerViewModel : OwnerFormModel
	{
		public OwnerViewModel()
		{
			this.Patients = new HashSet<PatientViewModel>();
		}

		public string Id { get; set; } = null!;

		public IEnumerable<PatientViewModel> Patients { get; set; }
    }
}

namespace VetApp.Web.ViewModels.Patient
{
	public class PatientViewModel : PatientFormModel
	{
		public string Id { get; set; } = null!;

		public string OwnerName { get; set; } = null!;

		public string OwnerId { get; set; } = null!;

		public string DoctorId { get; set; } = null!;
    }
}

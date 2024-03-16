namespace VetApp.Web.ViewModels.Patient
{
	using System.ComponentModel.DataAnnotations;
    using VetApp.Data.Common.Enums.Patient;

    public class PatientViewModel : PatientFormModel
	{
		public string Id { get; set; } = null!;

		public string OwnerName { get; set; } = null!;

		public string OwnerId { get; set; } = null!;

		public string DoctorId { get; set; } = null!;
    }
}

namespace VetApp.Web.ViewModels.Examination
{
	public class ExaminationDetailsViewModel : ExaminationFormModel
	{
		public string Id { get; set; } = null!;

		public string StatusName { get; set; } = null!;

		public string DoctorName { get; set; } = null!;
    }
}
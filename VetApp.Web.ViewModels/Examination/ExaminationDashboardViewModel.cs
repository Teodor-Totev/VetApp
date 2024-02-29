namespace VetApp.Web.ViewModels.Examination
{
	using VetApp.Web.ViewModels.Patient;
    using VetApp.Web.ViewModels.Status;

    public class ExaminationDashboardViewModel
	{
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string PatientName { get; set; } = null!;

        public string PatientType { get; set; } = null!;

        public string DoctorName { get; set; } = null!;
    }
}

namespace VetApp.Web.ViewModels.Patient
{
	using System.ComponentModel.DataAnnotations;

	using VetApp.Web.ViewModels.Patient.Enums;
	using static Web.Common.ViewModelValidationConstants.QueryModelConstants;


	public class AllPatientsQueryModel
	{
		public AllPatientsQueryModel()
		{
			this.CurrentPage = defaultPage;
			this.PatientsPerPage = entitiesPerPage;
			this.Patients = new HashSet<PatientViewModel>();
		}

		public string DoctorId { get; set; } = null!;

		[Display(Name = "Search by word")]
		public string? SearchString { get; set; }

		public int CurrentPage { get; set; }

		[Display(Name = "Show:")]
		public int PatientsPerPage { get; set; }

		public ICollection<PatientViewModel> Patients { get; set; }

		[Display(Name = "Sort by:")]
		[EnumDataType(typeof(PatientSorting))]
		public PatientSorting PatientSorting { get; set; }
	}
}
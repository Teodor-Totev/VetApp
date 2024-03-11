namespace VetApp.Web.ViewModels.Patient
{
	using System.Collections.Generic;
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

        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }

		[Display(Name = "Sort animals by:")]
        [EnumDataType(typeof(PatientSorting))]
        public PatientSorting PatientSorting{ get; set; }

        public int CurrentPage { get; set; }

		[Display(Name = "Show animals on page")]
		public int PatientsPerPage { get; set; }

        public int TotalPatients { get; set; }

        public ICollection<PatientViewModel> Patients { get; set; }
    }
}

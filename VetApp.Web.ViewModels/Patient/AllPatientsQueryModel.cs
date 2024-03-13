namespace VetApp.Web.ViewModels.Patient
{
	using System.ComponentModel.DataAnnotations;

	using VetApp.Web.ViewModels.Patient.Enums;

	public class AllPatientsQueryModel : MinePatientsQueryModel
	{
		[Display(Name = "Sort animals by:")]
		[EnumDataType(typeof(PatientSorting))]
		public PatientSorting PatientSorting { get; set; }
	}
}
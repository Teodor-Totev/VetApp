namespace VetApp.Services.Models.Examination
{
	using System.Collections.Generic;
	using VetApp.Web.ViewModels.Examination;

	public class PatientExaminationsServiceModel
	{
        public PatientExaminationsServiceModel()
        {
			this.PatientExaminations = new HashSet<ExaminationViewModel>();
        }
        public IEnumerable<ExaminationViewModel> PatientExaminations { get; set; }

        public int TotalItems { get; set; }
    }
}

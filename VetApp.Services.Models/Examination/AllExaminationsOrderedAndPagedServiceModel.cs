namespace VetApp.Services.Models.Examination
{
	using VetApp.Web.ViewModels.Examination;

	public class AllExaminationsOrderedAndPagedServiceModel
	{
        public AllExaminationsOrderedAndPagedServiceModel()
        {
            this.Examinations = new HashSet<ExaminationViewModel>();
        }

        public int TotalItems { get; set; }

        public IEnumerable<ExaminationViewModel> Examinations{ get; set; }
    }
}

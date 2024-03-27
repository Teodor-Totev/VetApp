namespace VetApp.Web.ViewModels.Examination
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using VetApp.Web.ViewModels.Examination.Enums;

	using static Web.Common.ViewModelValidationConstants.QueryModelConstants;

	public class AllExaminationsQueryModel
	{
		public AllExaminationsQueryModel()
		{
			this.CurrentPage = defaultPage;
			this.ExaminationsPerPage = 5;
			this.Examinations = new HashSet<ExaminationViewModel>();
		}

		public int CurrentPage { get; set; }

		[Display(Name = "Search by word")]
		public string? SearchString { get; set; }

		[Display(Name = "Show:")]
		public int ExaminationsPerPage { get; set; }

		[Display(Name = "Sort by:")]
		[EnumDataType(typeof(ExaminationSorting))]
		public ExaminationSorting ExaminationSorting { get; set; }

		public IEnumerable<ExaminationViewModel> Examinations { get; set; }
	}
}

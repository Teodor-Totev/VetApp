namespace VetApp.Web.ViewModels.Owner
{
	using System.ComponentModel.DataAnnotations;
	using VetApp.Web.ViewModels.Owner.Enums;
	using VetApp.Web.ViewModels.Patient;

	using static Web.Common.ViewModelValidationConstants.QueryModelConstants;

	public class AllOwnersQueryModel
	{
		public AllOwnersQueryModel()
		{
			this.CurrentPage = defaultPage;
			this.OwnersPerPage = entitiesPerPage;
			this.Owners = new HashSet<OwnerViewModel>();
		}

        public int CurrentPage { get; set; }

        [Display(Name = "Search by word")]
		public string? SearchString { get; set; }

		[Display(Name = "Show:")]
		public int OwnersPerPage { get; set; }

		[Display(Name = "Sort owners by:")]
		[EnumDataType(typeof(OwnerSorting))]
		public OwnerSorting OwnerSorting { get; set; }

		public IEnumerable<OwnerViewModel> Owners { get; set; }
	}
}

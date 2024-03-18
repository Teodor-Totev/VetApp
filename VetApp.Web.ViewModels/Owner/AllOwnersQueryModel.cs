namespace VetApp.Web.ViewModels.Owner
{
	using System.ComponentModel.DataAnnotations;
	using VetApp.Web.ViewModels.Owner.Enums;
	using VetApp.Web.ViewModels.Patient;

	public class AllOwnersQueryModel
	{
		public AllOwnersQueryModel()
		{
			this.CurrentPage = 1;
			this.OwnersPerPage = 3;
			this.Owners = new HashSet<OwnerViewModel>();
		}

		[Display(Name = "Search by word")]
		public string? SearchString { get; set; }

		[Display(Name = "Show owners on page")]
		public int OwnersPerPage { get; set; }

		public int CurrentPage { get; set; }

		public int TotalOwners { get; set; }

		public int TotalPages => (int)Math.Ceiling((double)TotalOwners / OwnersPerPage);

		[Display(Name = "Sort owners by:")]
		[EnumDataType(typeof(OwnerSorting))]
		public OwnerSorting OwnerSorting { get; set; }

		public bool HasPreviousPage => CurrentPage > 1;

		public bool HasNextPage => CurrentPage < TotalPages;

		public IEnumerable<OwnerViewModel> Owners { get; set; }
	}
}

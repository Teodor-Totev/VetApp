namespace VetApp.Web.ViewModels.Owner
{
	using System.ComponentModel.DataAnnotations;
	using VetApp.Web.ViewModels.Owner.Enums;
	using VetApp.Web.ViewModels.Patient;

	public class AllOwnersQueryModel
	{
        public AllOwnersQueryModel()
        {
            this.Owners = new HashSet<OwnerViewModel>();
        }

        public string? SearchString { get; set; }

        public int OwnersPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalOwners { get; set; }

		[Display(Name = "Sort owners by:")]
		[EnumDataType(typeof(OwnerSorting))]
		public OwnerSorting OwnerSorting { get; set; }

        public IEnumerable<OwnerViewModel> Owners { get; set; }
    }
}

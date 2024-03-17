namespace VetApp.Services.Models.Owner
{
	using VetApp.Web.ViewModels.Patient;

	public class AllOwnerOrderedAndPagedServiceModel
	{
        public AllOwnerOrderedAndPagedServiceModel()
        {
            this.Owners = new HashSet<OwnerViewModel>();
        }

        public int TotalOwnersCount { get; set; }

        public IEnumerable<OwnerViewModel> Owners { get; set; }
    }
}

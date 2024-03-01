namespace VetApp.Services.Interfaces
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using VetApp.Web.ViewModels.Status;

	public interface IStatusService
	{
		Task<ICollection<StatusViewModel>> GetStatusesAsync();
	}
}

namespace VetApp.Services
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;

	using VetApp.Data;
	using VetApp.Services.Interfaces;
	using VetApp.Web.ViewModels.Status;

	public class StatusService : IStatusService
	{
		private readonly VetAppDbContext context;

        public StatusService(VetAppDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<StatusViewModel>> AllStatusesAsync()
		{
			return await this.context.Statuses
				.Select(s => new StatusViewModel()
				{
					Id = s.Id,
					Name = s.Name
				})
				.ToArrayAsync();
		}
	}
}

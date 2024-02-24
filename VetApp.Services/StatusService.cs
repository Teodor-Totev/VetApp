namespace VetApp.Services
{
	using Microsoft.EntityFrameworkCore;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
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

        public async Task<ICollection<StatusVM>> GetStatusesAsync()
		{
			return await this.context.Statuses
				.Select(s => new StatusVM()
				{
					Id = s.Id,
					Name = s.Name
				})
				.ToArrayAsync();
		}
	}
}

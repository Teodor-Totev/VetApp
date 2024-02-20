namespace VetApp.Services
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using VetApp.Data;
    using VetApp.Data.Models;
    using VetApp.Services.Interfaces;
    using VetApp.Web.ViewModels.Examination;

    public class ExaminationService : IExaminationService
    {
        private readonly VetAppDbContext context;

        public ExaminationService(VetAppDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(AddExaminationFM model)
        {
            var e = new Examination()
            {
                User = model.User
            };

            await context.SaveChangesAsync();
        }

		public async Task<ICollection<PatientExaminationVM>> GetPatientExaminationsAsync(int patientId)
		{
			return await context.Examinations
				.Where(e => e.PatientId == patientId)
				.Select(e => new PatientExaminationVM
				{
					Id = e.Id,
					PatientId = e.PatientId,
					CreatedOn = e.CreatedOn,
					Doctor = e.User
				})
				.ToArrayAsync();
		}
	}
}

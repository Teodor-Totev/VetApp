namespace VetApp.Services
{
    using System.Threading.Tasks;
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
    }
}

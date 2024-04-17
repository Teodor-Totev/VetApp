namespace VetApp.Services
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using VetApp.Data;
    using VetApp.Data.Models;
    using VetApp.Services.Extensions.Examination;
    using VetApp.Services.Interfaces;
    using VetApp.Services.Models.Examination;
    using VetApp.Web.ViewModels.Examination;
    using Web.ViewModels.Examination.Enums;

    public class ExaminationService : IExaminationService
    {
        private readonly VetAppDbContext context;

        public ExaminationService(VetAppDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(ExaminationFormModel model, string patientId, string doctorId)
        {
            Patient patient = await context.Patients
                .FirstAsync(p => p.Id.ToString() == patientId && p.IsActive);

            Examination examination = model.ToExaminationEntity(patientId, doctorId);

            patient.Examinations.Add(examination);

            await context.Examinations.AddAsync(examination);
            await context.SaveChangesAsync();
        }

        public async Task<Dictionary<string, ExaminationDashboardViewModel[]>> GetExaminationsGroupedByStatus()
        {
            IEnumerable<Examination> examinations = await context.Examinations
                .Where(e => e.IsActive == true)
                .Include(e => e.Status)
                .Include(e => e.Patient)
                .Include(e => e.Doctor)
                .ToArrayAsync();

            var examinationsGroupedByStatus = examinations
                .GroupBy(e => e.Status.Name)
                .ToDictionary(g => g.Key, g => g
                .Select(e => e.ToExaminationDashboardViewModel())
                .ToArray());

            return examinationsGroupedByStatus;
        }

        public async Task<ExaminationFormModel> GetExaminationByIdAsync(string examinationId)
        {
            return await this.context.Examinations
                .Where(e => e.Id.ToString() == examinationId && e.IsActive == true)
                .Include(e => e.Doctor)
                .Include(e => e.Status)
                .Select(e => e.ToExaminationFormModel())
                .FirstAsync();
        }


        public async Task EditExaminationAsync(ExaminationFormModel model, string examinationId)
        {
            Examination targetExamination = await context.Examinations
                .FirstAsync(e => e.Id.ToString() == examinationId && e.IsActive == true);

            targetExamination.UpdateFromFormModel(model);

            await this.context.SaveChangesAsync();
        }

        public async Task<ExaminationDetailsViewModel> GetExaminationDetailsByIdAsync(string examinationId)
        {

            return await context.Examinations
                .Where(e => e.Id.ToString() == examinationId && e.IsActive == true)
                .Include(e => e.Status)
                .Include(e => e.Patient)
                .Include(e => e.Doctor)
                .Select(e => e.ToExaminationDetailsViewModel())
                .FirstAsync();
        }

        public async Task<PreDeleteDetailsViewModel> GetExaminationForDeleteByIdAsync(string examinationId)
        {
            Examination examination =
                await this.context.Examinations
                .Where(e => e.IsActive == true)
                .Include(e => e.Status)
                .Include(e => e.Patient)
                .Include(e => e.Doctor)
                .FirstAsync(e => e.Id.ToString() == examinationId);

            var preDeleteDetails = examination.ToPreDeleteDetailsViewModel();

            return preDeleteDetails;
        }

        public async Task DeleteExaminationByIdAsync(string examinationId)
        {
            Examination examinationToDelete =
                 await this.context.Examinations
                 .Where(e => e.IsActive == true)
                 .FirstAsync(e => e.Id.ToString() == examinationId);

            examinationToDelete.IsActive = false;

            await this.context.SaveChangesAsync();
        }

        public async Task<PatientExaminationsServiceModel> GetPatientExaminationsByIdAsync(string patientId, int currentPage)
        {
            var patientExamination = await this.context.Examinations
                .Include(e => e.Doctor)
                .Include(e => e.Status)
                .Include(e => e.Patient)
                .Where(e => e.PatientId.ToString() == patientId && e.IsActive == true)
                .OrderByDescending(e => e.CreatedOn)
                .Skip((currentPage - 1) * 4)
                .Take(4)
                .Select(e => e.ToViewModel())
                .ToArrayAsync();

            var totalCount = await this.context.Examinations
                .Where(e => e.PatientId.ToString() == patientId && e.IsActive == true)
                .CountAsync();

            return new PatientExaminationsServiceModel()
            {
                PatientExaminations = patientExamination,
                TotalItems = totalCount
            };
        }

        public async Task<AllExaminationsOrderedAndPagedServiceModel> GetAllExaminationsAsync(AllExaminationsQueryModel model)
        {
            IQueryable<Examination> queryModel = this.context.Examinations
                .Where(o => o.IsActive == true)
                .Include(e => e.Doctor)
                .Include(e => e.Status)
                .Include(e => e.Patient)
                .AsQueryable();

            if (!string.IsNullOrEmpty(model.SearchString))
            {
                string wildCard = $"%{model.SearchString.ToLower()}%";

                queryModel = queryModel
                    .Where(e => EF.Functions.Like(e.Reason, wildCard) ||
                                EF.Functions.Like(e.Status.Name, wildCard) ||
                                EF.Functions.Like(e.Doctor.FirstName!, wildCard) ||
                                EF.Functions.Like(e.Doctor.LastName!, wildCard));
            }

            queryModel = model.ExaminationSorting switch
            {
                ExaminationSorting.CreatedOnAscending =>
                    queryModel.OrderBy(e => e.CreatedOn),
                ExaminationSorting.CreatedOnDescending =>
                    queryModel.OrderByDescending(e => e.CreatedOn),
                ExaminationSorting.StatusAscending =>
                    queryModel.OrderBy(e => e.Status.Name),
                ExaminationSorting.StatusDescending =>
                    queryModel.OrderByDescending(e => e.Status.Name),
                ExaminationSorting.DoctorLastNameAscending =>
                    queryModel.OrderBy(e => e.Doctor.LastName),
                ExaminationSorting.DoctorLastNameDescending =>
                    queryModel.OrderByDescending(e => e.Doctor.LastName),
                _ => queryModel.OrderBy(e => e.Status.Name)

            };

            IEnumerable<ExaminationViewModel> examinations = await queryModel
                .Skip((model.CurrentPage - 1) * model.ExaminationsPerPage)
                .Take(model.ExaminationsPerPage)
                .Select(e => e.ToViewModel())
                .ToArrayAsync();

            return new AllExaminationsOrderedAndPagedServiceModel()
            {
                Examinations = examinations,
                TotalItems = await queryModel.CountAsync()
            };
        }

        public async Task<bool> ExaminationExistsAsync(string examinationId)
            => await this.context.Examinations.AnyAsync(e => e.Id.ToString() == examinationId && e.IsActive == true);
    }
}

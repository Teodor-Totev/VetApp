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

        public async Task AddAsync(AddExaminationFM model, int patientId, string doctorId)
        {
            var patient = await context.Patients
                .FindAsync(patientId);

            var doctor = await context.Users
                .FindAsync(Guid.Parse(doctorId));

            var e = new Examination()
            {
                DoctorId = Guid.Parse(doctorId),
                CreatedOn = model.CreatedOn,
                Weight = model.Weight,
                Reason = model.Reason,
                MedicalHistory = model.MedicalHistory,
                CurrentCondition = model.CurrentCondition,
                SpecificCondition = model.SpecificCondition,
                Research = model.Research,
                Diagnosis = model.Diagnosis,
                Surgery = model.Surgery,
                Therapy = model.Therapy,
                Exit = model.Exit,
                NextExamination = model.NextExamination,
                StatusId = model.StatusId,
                PatientId = patientId,
            };


            PatientUser ps = new PatientUser()
            {
                DoctorId = Guid.Parse(doctorId),
                PatientId = patientId
            };

            if (!context.PatientsUsers.Contains(ps))
            {
                await context.PatientsUsers.AddAsync(ps);
            }
            patient.Examinations.Add(e);

            await context.Examinations.AddAsync(e);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<ExaminationVM>> GetPatientExaminationsAsync(int patientId)
        {
            return await context.Examinations
                .Where(e => e.PatientId == patientId)
                .Select(e => new ExaminationVM
                {
                    Id = e.Id,
                    Weight = e.Weight,
                    Reason = e.Reason,
                    Diagnosis = e.Diagnosis,
                    CreatedOn = e.CreatedOn,
                    DoctorName = "Dr." + e.Doctor.FirstName + " " + e.Doctor.LastName,
                    Surgery = e.Surgery,
                    Therapy = e.Therapy
                })
                .ToArrayAsync();
        }

        public async Task<Dictionary<string, List<ExaminationDashboardVM>>> GetExaminationsGroupedByStatus()
        {

            var examinations = await context.Examinations
                .Include(e => e.Status)
                .Include(e => e.Patient)
                .Include(e => e.Doctor)
                .ToListAsync();

            var examinationsGroupedByStatus = examinations
                .GroupBy(e => e.Status.Name)
                .ToDictionary(g => g.Key, g => g.Select(e => new ExaminationDashboardVM
                {
                    Id = e.Id,
                    PatientId = e.PatientId,
                    PatientName = e.Patient.Name,
                    PatientType = e.Patient.Type,
                    DoctorName = "Dr." + e.Doctor.FirstName + " " + e.Doctor.LastName,
                }).ToList());

            return examinationsGroupedByStatus;
        }
    }
}

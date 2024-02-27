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

        public async Task AddAsync(ExaminationFM model, int patientId, string doctorId)
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
                .Where(e => e.PatientId == patientId && e.Status.Name == "Done")
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

		public async Task<ExaminationFM> GetExaminationByIdAsync(int examinationId)
		{
            ExaminationFM examination = await this.context.Examinations
                .Where(e => e.Id == examinationId)
                .Select(e => new ExaminationFM()
                {
                    Id = e.Id,
                    DoctorName = "Dr." + e.Doctor.FirstName + " " + e.Doctor.LastName,
					Weight = e.Weight,
					Reason = e.Reason,
					CreatedOn = e.CreatedOn,
					MedicalHistory = e.MedicalHistory,
					CurrentCondition = e.CurrentCondition,
					SpecificCondition = e.SpecificCondition,
					Research = e.Research,
					Diagnosis = e.Diagnosis,
					Surgery = e.Surgery,
					Therapy = e.Therapy,
					Exit = e.Exit,
					NextExamination = e.NextExamination,
					StatusId = e.StatusId,
                    PatientId = e.PatientId,
				})
                .FirstAsync();

            return examination;
		}

		public async Task EditExaminationAsync(ExaminationFM model, int examinationId)
		{
            Examination targetExamination = await context.Examinations.FindAsync(examinationId);

            if (targetExamination == null)
            {
                throw new InvalidOperationException("Examination does not exist");
            }

            targetExamination.Weight = model.Weight;
			targetExamination.Reason = model.Reason;
			targetExamination.MedicalHistory = model.MedicalHistory;
			targetExamination.CurrentCondition = model.CurrentCondition;
			targetExamination.SpecificCondition = model.SpecificCondition;
			targetExamination.Research = model.Research;
			targetExamination.Diagnosis = model.Diagnosis;
			targetExamination.Surgery = model.Surgery;
			targetExamination.Therapy = model.Therapy;
			targetExamination.Exit = model.Exit;
			targetExamination.NextExamination = model.NextExamination;
            targetExamination.StatusId = model.StatusId;

			await this.context.SaveChangesAsync();
		}
	}
}

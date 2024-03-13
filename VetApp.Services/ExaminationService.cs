namespace VetApp.Services
{
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;

	using VetApp.Data;
	using VetApp.Data.Models;
	using VetApp.Services.Interfaces;
	using VetApp.Web.ViewModels.Examination;
	using VetApp.Web.ViewModels.Patient;

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
                .FirstAsync(p => p.Id.ToString() == patientId);

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
                StatusId = model.StatusId,
                PatientId = Guid.Parse(patientId),
            };


            PatientUser ps = new PatientUser()
            {
                DoctorId = Guid.Parse(doctorId),
                PatientId = Guid.Parse(patientId)
            };

            if (!context.PatientsUsers.Contains(ps))
            {
                await context.PatientsUsers.AddAsync(ps);
            }
            patient.Examinations.Add(e);

            await context.Examinations.AddAsync(e);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<ExaminationViewModel>> GetExaminationsForPatientByIdAsync(string patientId)
        {
            return await context.Examinations
                .Where(e => e.PatientId.ToString() == patientId)
                .Select(e => new ExaminationViewModel
                {
                    Id = e.Id.ToString(),
                    Weight = e.Weight,
                    Reason = e.Reason,
                    Diagnosis = e.Diagnosis,
                    CreatedOn = e.CreatedOn,
                    DoctorName = "Dr." + e.Doctor.FirstName + " " + e.Doctor.LastName,
                    Surgery = e.Surgery,
                    Therapy = e.Therapy,
                    Status = e.Status.Name
                })
                .ToArrayAsync();
        }

        public async Task<Dictionary<string, List<ExaminationDashboardViewModel>>> GetExaminationsGroupedByStatus()
        {

            var examinations = await context.Examinations
                .Include(e => e.Status)
                .Include(e => e.Patient)
                .Include(e => e.Doctor)
                .ToListAsync();

            var examinationsGroupedByStatus = examinations
                .GroupBy(e => e.Status.Name)
                .ToDictionary(g => g.Key, g => g.Select(e => new ExaminationDashboardViewModel
                {
                    Id = e.Id.ToString(),
                    PatientId = e.PatientId.ToString(),
                    PatientName = e.Patient.Name,
                    PatientType = e.Patient.Type,
                    DoctorName = "Dr." + e.Doctor.FirstName + " " + e.Doctor.LastName,
                    CreatedOn = e.CreatedOn
                }).ToList());

            return examinationsGroupedByStatus;
        }

		public async Task<ExaminationFormModel> GetExaminationByIdAsync(string examinationId)
		{
            ExaminationFormModel examination = await this.context.Examinations
                .Where(e => e.Id.ToString() == examinationId)
                .Select(e => new ExaminationFormModel()
                {
                    Id = e.Id.ToString(),
                    DoctorId = e.DoctorId.ToString(),
                    PatientId = e.PatientId.ToString(),
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
					StatusId = e.StatusId,
				})
                .FirstAsync();

            return examination;
		}

		public async Task EditExaminationAsync(ExaminationFormModel model, string examinationId)
		{
            Examination targetExamination = await context.Examinations
                .FirstAsync(e => e.Id.ToString() == examinationId);

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
            targetExamination.StatusId = model.StatusId;
            targetExamination.CreatedOn = model.CreatedOn;

			await this.context.SaveChangesAsync();
		}

		public async Task<ExaminationViewModel> GetExaminationDetailsByIdAsync(string examinationId)
		{
			return await context.Examinations
				.Where(e => e.Id.ToString() == examinationId)
				.Select(e => new ExaminationViewModel
				{
					Id = e.Id.ToString(),
					Weight = e.Weight,
					Reason = e.Reason,
					Diagnosis = e.Diagnosis,
					CreatedOn = e.CreatedOn,
					DoctorName = "Dr." + e.Doctor.FirstName + " " + e.Doctor.LastName,
					Surgery = e.Surgery,
					Therapy = e.Therapy,
					Status = e.Status.Name,
                    SpecificCondition = e.SpecificCondition,
                    CurrentCondition = e.CurrentCondition,
                    Exit = e.Exit,
                    MedicalHistory = e.MedicalHistory,
                    Research = e.Research,
				})
				.FirstAsync();
		}
    }
}

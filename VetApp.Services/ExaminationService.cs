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

        public async Task AddAsync(AddExaminationFM model, int patientId)
        {
            var patient = await context.Patients
                .FindAsync(patientId);

            var e = new Examination()
            {
                Id = model.Id,
                User = model.User,
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
                PatientId = patientId,
            };

            patient.Examinations.Add(e);

            await context.Examinations.AddAsync(e);
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

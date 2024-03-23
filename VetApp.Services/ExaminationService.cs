﻿namespace VetApp.Services
{
	using Microsoft.EntityFrameworkCore;
	using System.Threading.Tasks;
	using VetApp.Data;
	using VetApp.Data.Models;
	using VetApp.Services.Extensions;
	using VetApp.Services.Interfaces;
	using VetApp.Services.Models.Examination;
	using VetApp.Web.ViewModels.Examination;

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

			Examination examination = new()
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
				.ToDictionary(g => g.Key, g => g.Select(e => new ExaminationDashboardViewModel
				{
					Id = e.Id.ToString(),
					PatientId = e.PatientId.ToString(),
					PatientName = e.Patient.Name,
					PatientType = e.Patient.Type,
					DoctorName = "Dr." + e.Doctor.FirstName + " " + e.Doctor.LastName,
					CreatedOn = e.CreatedOn
				}).ToArray());

			return examinationsGroupedByStatus;
		}

		public async Task<ExaminationFormModel> GetExaminationByIdAsync(string examinationId)
			=> await this.context.Examinations
				.Where(e => e.Id.ToString() == examinationId && e.IsActive == true)
				.Select(e => new ExaminationFormModel()
				{
					DoctorId = e.DoctorId.ToString(),
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
					StatusId = e.StatusId
				})
				.FirstAsync();


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

		public async Task<ExaminationDetailsViewModel> GetExaminationDetailsByIdAsync(string examinationId)
			=> await context.Examinations
				.Where(e => e.Id.ToString() == examinationId)
				.Select(e => new ExaminationDetailsViewModel
				{
					Id = e.Id.ToString(),
					Weight = e.Weight,
					Reason = e.Reason,
					Diagnosis = e.Diagnosis,
					CreatedOn = e.CreatedOn,
					Surgery = e.Surgery,
					DoctorName = e.Doctor.FirstName + " " + e.Doctor.LastName,
					Therapy = e.Therapy,
					StatusName = e.Status.Name,
					SpecificCondition = e.SpecificCondition,
					CurrentCondition = e.CurrentCondition,
					Exit = e.Exit,
					MedicalHistory = e.MedicalHistory,
					Research = e.Research,
				})
				.FirstAsync();

		public async Task<PreDeleteDetailsViewModel> GetExaminationForDeleteByIdAsync(string examinationId)
		{
			Examination examination =
				await this.context.Examinations
				.Where(e => e.IsActive == true)
				.Include(e => e.Status)
				.Include(e => e.Patient)
				.Include(e => e.Doctor)
				.FirstAsync(e => e.Id.ToString() == examinationId);

			return new PreDeleteDetailsViewModel()
			{
				Id = examination.Id.ToString(),
				StatusName = examination.Status.Name,
				PatientName = examination.Patient.Name,
				DoctorName = examination.Doctor.FirstName + " " +
							examination.Doctor.LastName,
				CreatedOn = examination.CreatedOn,
				Reason = examination.Reason,
				Weight = examination.Weight
			};
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
				.Where(e => e.PatientId.ToString() == patientId && e.IsActive == true)
				.OrderByDescending(e => e.CreatedOn)
				.Skip((currentPage - 1) * 2)
				.Take(2)
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

		public async Task<IEnumerable<ExaminationViewModel>> GetAllExaminationsAsync()
		{
			IEnumerable<ExaminationViewModel> examinations = await this.context.Examinations
				.Where(e => e.IsActive == true)
				.Include(e => e.Doctor)
				.Include(e => e.Status)
				.Select(e => e.ToViewModel())
				.ToArrayAsync();

			return examinations;
		}

		public async Task<bool> ExaminationExistsAsync(string examinationId)
			=> await this.context.Examinations.AnyAsync(e => e.Id.ToString() == examinationId && e.IsActive == true);
	}
}

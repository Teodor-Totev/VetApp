namespace VetApp.Services
{
	using Microsoft.EntityFrameworkCore;

	using Data;
	using Data.Models;
	using Interfaces;
	using Models.Patient;
	using Web.ViewModels.Patient;
	using Web.ViewModels.Patient.Enums;

	public class PatientService : IPatientService
	{
		private readonly VetAppDbContext context;

		public PatientService(VetAppDbContext context)
		{
			this.context = context;
		}

		public async Task<int> CreateAsync(PatientFormModel model)
		{
			var existingOwner = await context.Owners
				.FirstOrDefaultAsync(o => o.PhoneNumber == model.Owner.PhoneNumber &&
										  o.Name == model.Name);

			Owner newOwner = new Owner()
			{
				PhoneNumber = model.Owner.PhoneNumber,
				Address = model.Owner.Address,
				Name = model.Owner.Name,
				Email = model.Owner.Email,
			};

			Patient patient = new Patient()
			{
				Name = model.Name,
				Type = model.Type,
				Gender = model.Gender,
				BirthDate = model.BirthDate,
				Neutered = model.Neutered,
				Microchip = model.Microchip,
				Characteristics = model.Characteristics,
				ChronicIllnesses = model.ChronicIllnesses
			};

			if (existingOwner != null)
			{
				patient.OwnerId = existingOwner.Id;
				existingOwner.Patients.Add(patient);
			}
			else
			{
				patient.OwnerId = newOwner.Id;
				newOwner.Patients.Add(patient);
				await context.Owners.AddAsync(newOwner);
			}

			await context.Patients.AddAsync(patient);
			await context.SaveChangesAsync();

			return patient.Id;
		}

		public async Task EditPatientAsync(PatientEditViewModel model, int patientId)
		{
			Patient targetPatient = await context.Patients.FindAsync(patientId);

			targetPatient.Name = model.Name;
			targetPatient.Type = model.Type;
			targetPatient.Gender = model.Gender;
			targetPatient.Neutered = model.Neutered;
			targetPatient.BirthDate = model.BirthDate;
			targetPatient.Microchip = model.Microchip;
			targetPatient.Characteristics = model.Characteristics;
			targetPatient.ChronicIllnesses = model.ChronicIllnesses;

			await context.SaveChangesAsync();
		}

		public async Task<bool> PatientExistsAsync(int patientId)
			=> await context.Patients.AnyAsync(p => p.Id == patientId);

		public async Task<AllPatientsOrderedAndPagedServiceModel> GetAllPatientsAsync(AllPatientsQueryModel queryModel)
		{
			IQueryable<Patient> query = context.Patients
				.AsQueryable();

			if (!string.IsNullOrEmpty(queryModel.SearchString))
			{
				string wildCard = $"%{queryModel.SearchString.ToLower()}%";

				query = query
					.Where(p => EF.Functions.Like(p.Name, wildCard) ||
								EF.Functions.Like(p.Owner.Name, wildCard) ||
								p.PatientsUsers.Any(pu => EF.Functions.Like(pu.DoctorId.ToString(),wildCard)));
			}

			query = queryModel.PatientSorting switch
			{
				PatientSorting.PatientNameAscending => query
					.OrderBy(p => p.Name),
				PatientSorting.PatientNameDescending => query
					.OrderByDescending(p => p.Name),
				PatientSorting.OwnerNameAscending => query
					.OrderBy(p => p.Owner.Name),
				PatientSorting.OwnerNameDescending => query
					.OrderByDescending (p => p.Owner.Name),
				_ => query
					.OrderByDescending(p => p.Id)
			};

			ICollection<PatientViewModel> patients = await query
				.Skip((queryModel.CurrentPage - 1) * queryModel.PatientsPerPage)
				.Take(queryModel.PatientsPerPage)
				.Select(p => new PatientViewModel()
				{
					Id = p.Id,
					Name = p.Name,
					OwnerName = p.Owner.Name,
					Type = p.Type,
					Gender = p.Gender,
					BirthDate = p.BirthDate,
					Neutered = p.Neutered,
					OwnerId = p.OwnerId.ToString(),
				})
				.ToArrayAsync();

			var result = new AllPatientsOrderedAndPagedServiceModel()
			{
				TotalPatientsCount = query.Count(),
				Patients = patients
			};

			 return result;
		}

		public async Task<PatientViewModel> GetPatientByIdAsync(int patientId)
		{
			PatientViewModel patient = await context.Patients
				.Where(p => p.Id == patientId)
				.Select(p => new PatientViewModel()
				{
					Id = p.Id,
					Name = p.Name,
					Type = p.Type,
					Gender = p.Gender,
					BirthDate = p.BirthDate,
					Microchip = p.Microchip,
					Neutered = p.Neutered,
					ChronicIllnesses = p.ChronicIllnesses,
					Characteristics = p.Characteristics
				})
				.FirstAsync();

			return patient;
		}

		public async Task<PatientEditViewModel> GetPatientForEditByIdAsync(int patientId)
		{
			PatientEditViewModel patient = await context.Patients
				.Where(p => p.Id == patientId)
				.Select(p => new PatientEditViewModel()
				{
					Id = p.Id,
					Name = p.Name,
					Type = p.Type,
					Gender = p.Gender,
					BirthDate = p.BirthDate,
					Microchip = p.Microchip,
					Neutered = p.Neutered,
					ChronicIllnesses = p.ChronicIllnesses,
					Characteristics = p.Characteristics
				})
				.FirstAsync();

			return patient;
		}
	}
}

namespace VetApp.Services
{
	using System;

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

		public async Task<string> CreateAsync(PatientFormModel model, string doctorId)
		{
			Owner owner = new Owner()
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
				ChronicIllnesses = model.ChronicIllnesses,
				OwnerId = owner.Id,
			};


			PatientUser pu = new PatientUser()
			{
				Patient = patient,
				DoctorId = Guid.Parse(doctorId)
			};


			patient.PatientsUsers.Add(pu);
			owner.Patients.Add(patient);

			await context.Owners.AddAsync(owner);
			await context.Patients.AddAsync(patient);
			await context.SaveChangesAsync();

			return patient.Id.ToString();
		}

		public async Task<string> AddPetAsync(AddPetViewModel model, string ownerId, string doctorId)
		{
			Owner owner = await this.context.Owners.FirstAsync(o => o.Id.ToString() == ownerId);

			Patient patient = new Patient()
			{
				Name = model.Name,
				Type = model.Type,
				Gender = model.Gender,
				BirthDate = model.BirthDate,
				Neutered = model.Neutered,
				Microchip = model.Microchip,
				Characteristics = model.Characteristics,
				ChronicIllnesses = model.ChronicIllnesses,
				OwnerId = Guid.Parse(ownerId),
				Owner = owner,
			};

			var pu = new PatientUser()
			{
				Patient = patient,
				DoctorId = Guid.Parse(doctorId)
			};

			patient.PatientsUsers.Add(pu);
			owner!.Patients.Add(patient);
			await context.Patients.AddAsync(patient);
			await context.SaveChangesAsync();

			return patient.Id.ToString();
		}

		public async Task EditPatientAsync(PatientEditViewModel model, string patientId)
		{
			Patient targetPatient = await context.Patients
				.FirstAsync(p => p.Id.ToString() == patientId);

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

		public async Task<bool> PatientExistsAsync(string patientId)
			=> await context.Patients.AnyAsync(p => p.Id.ToString() == patientId);

		public async Task<AllPatientsOrderedAndPagedServiceModel> GetAllPatientsAsync(AllPatientsQueryModel queryModel)
		{
			IQueryable<Patient> query = context.Patients
				.AsQueryable();

			if (!string.IsNullOrEmpty(queryModel.SearchString))
			{
				string wildCard = $"%{queryModel.SearchString.ToLower()}%";

				query = query
					.Where(p => EF.Functions.Like(p.Name, wildCard) ||
								EF.Functions.Like(p.Type, wildCard) ||
								EF.Functions.Like(p.Owner.Name, wildCard));
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
					.OrderByDescending(p => p.Owner.Name),
				_ => query
					.OrderByDescending(p => p.Id)
			};

			ICollection<PatientViewModel> patients = await query
				.Skip((queryModel.CurrentPage - 1) * queryModel.PatientsPerPage)
				.Take(queryModel.PatientsPerPage)
				.Select(p => new PatientViewModel()
				{
					Id = p.Id.ToString(),
					Name = p.Name,
					OwnerName = p.Owner.Name,
					Type = p.Type,
					Gender = p.Gender,
					Neutered = p.Neutered,
					OwnerId = p.OwnerId.ToString()
				})
				.ToArrayAsync();

			var result = new AllPatientsOrderedAndPagedServiceModel()
			{
				TotalPatientsCount = await query.CountAsync(),
				Patients = patients
			};

			return result;
		}

		public async Task<PatientViewModel> GetPatientByIdAsync(string patientId)
		{
			PatientViewModel patient = await context.Patients
				.Where(p => p.Id.ToString() == patientId)
				.Select(p => new PatientViewModel()
				{
					Id = p.Id.ToString(),
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

		public async Task<PatientEditViewModel> GetPatientForEditByIdAsync(string patientId)
		{
			PatientEditViewModel patient = await context.Patients
				.Where(p => p.Id.ToString() == patientId)
				.Select(p => new PatientEditViewModel()
				{
					Id = p.Id.ToString(),
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

		public async Task<AllPatientsOrderedAndPagedServiceModel> GetAllPatientsForUserAsync(MinePatientsQueryModel queryModel, string doctorId)
		{
			IQueryable<PatientUser> query = context.PatientsUsers
				.AsQueryable();

			if (!string.IsNullOrEmpty(doctorId))
			{
				query = query
					.Where(pu => pu.DoctorId.ToString() == doctorId);
			}

			if (!string.IsNullOrEmpty(queryModel.SearchString))
			{
				string wildCard = $"%{queryModel.SearchString.ToLower()}%";

				query = query
					.Where(p => EF.Functions.Like(p.Patient.Name, wildCard) ||
								EF.Functions.Like(p.Patient.Type, wildCard) ||
								EF.Functions.Like(p.Patient.Owner.Name, wildCard));
			}

			ICollection<PatientViewModel> patients = await query
				.Skip((queryModel.CurrentPage - 1) * queryModel.PatientsPerPage)
				.Take(queryModel.PatientsPerPage)
				.Select(p => new PatientViewModel()
				{
					Id = p.Patient.Id.ToString(),
					Name = p.Patient.Name,
					OwnerName = p.Patient.Owner.Name,
					Type = p.Patient.Type,
					Gender = p.Patient.Gender,
					Neutered = p.Patient.Neutered,
					OwnerId = p.Patient.OwnerId.ToString()
				})
				.ToArrayAsync();

			var result = new AllPatientsOrderedAndPagedServiceModel()
			{
				TotalPatientsCount = await query.CountAsync(),
				Patients = patients
			};

			return result;
		}

		public async Task<bool> DoesPatientExistInOwnerCollection(string ownerId, string patientName)
		{
			Owner owner = await this.context.Owners
				.Include(o => o.Patients)
				.FirstAsync(o => o.Id.ToString() == ownerId);

			return owner.Patients.Any(p => p.Name == patientName);
		}
	}
}

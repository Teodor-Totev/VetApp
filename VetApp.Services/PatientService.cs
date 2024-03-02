namespace VetApp.Services
{
	using Microsoft.EntityFrameworkCore;

	using VetApp.Data;
	using VetApp.Data.Models;
	using VetApp.Services.Interfaces;
	using VetApp.Web.ViewModels.Patient;

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

		public async Task<ICollection<PatientViewModel>> GetAllPatientsAsync(string patientName, string ownerName, string doctorId)
		{
			IQueryable<Patient> query = context.Patients;

			if (!string.IsNullOrEmpty(patientName))
			{
				query = query.Where(p => p.Name == patientName);
			}

			if (!string.IsNullOrEmpty(ownerName))
			{
				query = query.Where(p => p.Owner.Name == ownerName);
			}

			if (!string.IsNullOrEmpty(doctorId))
			{
				query = query.Where(p => p.PatientsUsers.Any(pu => pu.DoctorId.ToString() == doctorId));
			}

			return await query
				.Select(p => new PatientViewModel()
				{
					Id = p.Id,
					Name = p.Name,
					Type = p.Type,
					Gender = p.Gender,
					BirthDate = p.BirthDate,
					Neutered = p.Neutered,
					OwnerId = p.OwnerId.ToString(),
				})
				.ToArrayAsync();
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
	}
}

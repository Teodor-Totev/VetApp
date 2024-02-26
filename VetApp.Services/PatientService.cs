using Microsoft.EntityFrameworkCore;
using VetApp.Data;
using VetApp.Data.Models;
using VetApp.Services.Interfaces;
using VetApp.Web.ViewModels.Patient;

namespace VetApp.Services
{
	public class PatientService : IPatientService
	{
		private readonly VetAppDbContext context;

		public PatientService(VetAppDbContext context)
		{
			this.context = context;
		}

		public async Task CreateAsync(CreateVM model, Patient patient)
		{
			var existingOwner = await context.Owners.FirstOrDefaultAsync(o => o.PhoneNumber == model.OwnerPhoneNumber && o.Name == model.Name);

			Owner newOwner = new Owner()
			{
				PhoneNumber = model.OwnerPhoneNumber,
				Address = model.OwnerAddress,
				Name = model.OwnerName,
				Email = model.OwnerEmail,
			};

			patient.Name = model.Name;
			patient.Type = model.Type;
			patient.Gender = model.Gender;
			patient.BirthDate = model.BirthDate;
			patient.Neutered = model.Neutered;
			patient.Microchip = model.Microchip;
			patient.Characteristics = model.Characteristics;
			patient.ChronicIllnesses = model.ChronicIllnesses;

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
		}

		public async Task<ICollection<PatientVM>> GetAllPatientsAsync()
		{
			return await context
				.Patients
				.Select(p => new PatientVM()
				{
					Id = p.Id,
					Name = p.Name,
					Type = p.Type,
					Gender = p.Gender,
					BirthDate = p.BirthDate,
					Neutered = p.Neutered,
				})
				.ToArrayAsync();
		}

		public async Task<PatientVM> GetPatientByIdAsync(int patientId)
		{
			PatientVM patient = await context.Patients
				.Where(p => p.Id == patientId)
				.Select(p => new PatientVM()
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



		public async Task<ICollection<PatientVM>> GetUserPatientsAsync(string doctorId)
		{
			return await context.Patients
				.Where(p => p.PatientsUsers.Any(pu => pu.DoctorId.ToString() == doctorId))
				.Select(p => new PatientVM()
				{
					Id = p.Id,
					Name = p.Name,
					Type = p.Type,
					Gender = p.Gender,
					BirthDate = p.BirthDate,
					Microchip = p.Microchip,
					Neutered = p.Neutered,
				})
				.ToArrayAsync();
		}

		
	}
}

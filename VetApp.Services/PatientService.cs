﻿using Microsoft.EntityFrameworkCore;
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
			var checkOwner = await context.Owners.FirstOrDefaultAsync(o => o.PhoneNumber == model.OwnerPhoneNumber);

			Owner owner = new Owner()
			{
				PhoneNumber = model.OwnerPhoneNumber,
				Address = model.OwnerAddress,
				Name = model.OwnerName,
				Email = model.OwnerEmail,
			};

			patient.OwnerId = owner.Id;
			if (checkOwner != null)
			{
				checkOwner.Patients.Add(patient);
			}
			else
			{
				owner.Patients.Add(patient);
				await context.Owners.AddAsync(owner);
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
					Microchip = p.Microchip,
					Neutered = p.Neutered,
					ChronicIllnesses = p.ChronicIllnesses,
					Characteristics = p.Characteristics
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

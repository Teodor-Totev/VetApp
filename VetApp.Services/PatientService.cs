using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VetApp.Data;
using VetApp.Data.Models;
using VetApp.Services.Interfaces;
using VetApp.Web.ViewModels.Patient;
using VetApp.Web.ViewModels.Patient.Enum;

namespace VetApp.Services
{
	public class PatientService : IPatientService
	{
		private readonly VetAppDbContext context;

		public PatientService(VetAppDbContext context)
		{
			this.context = context;
		}

		public async Task CreateAsync(CreateVM model, string userId)
		{
			Owner owner = new Owner()
			{
				PhoneNumber = model.OwnerPhoneNumber,
				Address = model.OwnerAddress,
				Name = model.OwnerName,
				Email = model.OwnerEmail,
			};

			Patient patient = new Patient()
			{
				Name = model.Name,
				Type = model.Type,
				Gender = model.Gender,
				BirthDate = model.BirthDate,
				Neutered = model.Neutered,
				MicroChip = model.MicroChip,
				Characteristics = model.Characteristics,
				ChronicIllnesses = model.ChronicIllnesses,
				Owner = owner
			};

			PatientUser ps = new PatientUser()
			{
				UserId = Guid.Parse(userId),
				PatientId = patient.Id
			};

			patient.PatientsUsers.Add(ps);

			await context.Owners.AddAsync(owner);
			await context.Patients.AddAsync(patient);
			await context.SaveChangesAsync();
		}

		public async Task<ICollection<AllPatientsVM>> GetAllPatientsAsync()
		{
			return await context
				.Patients
				.Select(p => new AllPatientsVM()
				{
					Id = p.Id,
					Name = p.Name,
					Type = p.Type,
					Gender = p.Gender,
					BirthDate = p.BirthDate,
					MicroChip = p.MicroChip,
					Neutered = p.Neutered,
					OwnerName = p.Owner.Name
				})
				.ToArrayAsync();

			//OwnerName = p.Owner.Name,
			//		Name = p.Name,
			//		Gender = p.Gender,
			//		BirthDate = p.BirthDate,
			//		Neutered = p.Neutered,
			//		MicroChip = p.MicroChip,
			//		Type = p.Type,
		}
	}
}

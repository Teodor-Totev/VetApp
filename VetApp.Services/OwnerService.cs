﻿namespace VetApp.Services
{
	using Microsoft.EntityFrameworkCore;

	using VetApp.Data;
	using VetApp.Services.Interfaces;
	using VetApp.Web.ViewModels.Owner;
	using VetApp.Web.ViewModels.Patient;

	public class OwnerService : IOwnerService
	{
		private readonly VetAppDbContext context;

		public OwnerService(VetAppDbContext context)
		{
			this.context = context;
		}

		public async Task<OwnerViewModel> GetOwnerByIdAsync(string ownerId)
		{
			return await context.Owners
				.Where(o => o.Id.ToString() == ownerId)
				.Select(o => new OwnerViewModel()
				{
					Id = o.Id.ToString(),
					Name = o.Name,
					Address = o.Address,
					PhoneNumber = o.PhoneNumber,
					Email = o.Email
				})
				.FirstAsync();
		}

		public async Task<ICollection<OwnerViewModel>> GetOwnersAsync(string phoneNumber)
		{
			if (phoneNumber != null)
			{
				return await context.Owners
				.Where(o => o.PhoneNumber.Contains(phoneNumber))
				.Select(o => new OwnerViewModel()
				{
					Id = o.Id.ToString(),
					Name = o.Name,
					Address = o.Address,
					PhoneNumber = o.PhoneNumber,
					Patients = context.Patients
					.Where(p => p.OwnerId == o.Id)
					.Select(p => new PatientViewModel()
					{
						Id = p.Id,
						Name = p.Name,
						Type = p.Type,
						Gender = p.Gender,
						Neutered = p.Neutered
					})
					.ToArray()
				})
				.ToArrayAsync();
			}

			return await context.Owners
				.Select(o => new OwnerViewModel()
				{
					Id = o.Id.ToString(),
					Name = o.Name,
					Address = o.Address,
					PhoneNumber = o.PhoneNumber,
					Patients = context.Patients
					.Where(p => p.OwnerId == o.Id)
					.Select(p => new PatientViewModel()
					{
						Id = p.Id,
						Name = p.Name,
						Type = p.Type,
						Gender = p.Gender,
						Neutered = p.Neutered
					})
					.ToArray()
				})
				.ToArrayAsync();
		}

		
	}
}

namespace VetApp.Services
{
	using Microsoft.EntityFrameworkCore;

	using VetApp.Data;
	using VetApp.Services.Interfaces;
	using VetApp.Web.ViewModels.Patient;

	public class OwnerService : IOwnerService
	{
		private readonly VetAppDbContext context;

		public OwnerService(VetAppDbContext context)
		{
			this.context = context;
		}

		public async Task<ICollection<OwnerPatient>> GetOwnersAsync(string phoneNumber)
		{
			if (phoneNumber != null)
			{
				return await context.Owners
				.Where(o => o.PhoneNumber.Contains(phoneNumber))
				.Select(o => new OwnerPatient()
				{
					OwnerName = o.Name,
					Address = o.Address,
					PhoneNumber = o.PhoneNumber,
					Patients = context.Patients
					.Where(p => p.OwnerId == o.Id)
					.Select(p => new PatientVM()
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
				.Select(o => new OwnerPatient()
				{
					OwnerName = o.Name,
					Address = o.Address,
					PhoneNumber = o.PhoneNumber,
					Patients = context.Patients
					.Where(p => p.OwnerId == o.Id)
					.Select(p => new PatientVM()
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

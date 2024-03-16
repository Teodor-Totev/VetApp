namespace VetApp.Services
{
	using Microsoft.EntityFrameworkCore;

	using VetApp.Data;
	using VetApp.Services.Interfaces;
	using VetApp.Services.Models.Owner;
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
			=> await context.Owners
				.Where(o => o.Id.ToString() == ownerId && o.IsActive == true)
				.Select(o => new OwnerViewModel()
				{
					Id = o.Id.ToString(),
					Name = o.Name,
					Address = o.Address,
					PhoneNumber = o.PhoneNumber,
					Email = o.Email
				})
				.FirstAsync();

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
						Id = p.Id.ToString(),
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
						Id = p.Id.ToString(),
						Name = p.Name,
						Type = p.Type,
						Gender = p.Gender,
						Neutered = p.Neutered
					})
					.ToArray()
				})
				.ToArrayAsync();
		}

		public async Task<bool> OwnerExistsAsync(string ownerId)
			=> await context.Owners.AnyAsync(o => o.Id.ToString() == ownerId);

		public async Task<bool> CheckOwnerExistsByNameAndPhoneNumberAsync(string name, string phoneNumber)
			=> await context.Owners.AnyAsync(o => o.Name == name && o.PhoneNumber == phoneNumber);

		public async Task<IEnumerable<AllExistingOwnersServiceModel>> GetAllExistingOwnersAsync()
			=> await context.Owners
						.Where(o => o.IsActive == true)
						.Select(o => new AllExistingOwnersServiceModel()
						{
							Id = o.Id.ToString(),
							Name = o.Name,
						})
						.ToArrayAsync();
	}
}

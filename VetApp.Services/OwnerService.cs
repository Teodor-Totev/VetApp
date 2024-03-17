namespace VetApp.Services
{
	using Microsoft.EntityFrameworkCore;

	using VetApp.Data;
	using VetApp.Data.Models;
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


		public async Task<ICollection<OwnerViewModel>> GetAllOwnersAsync(string phoneNumber)
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
					Email = o.Email,
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
					Email = o.Email,
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
		{
			return await context.Owners
				.Where(o => o.IsActive == true)
				.Select(o => new AllExistingOwnersServiceModel()
				{
					Id = o.Id.ToString(),
					Name = o.Name,
				})
				.ToArrayAsync();
		}

		public async Task<OwnerFormModel> GetOwnerForEditByIdAsync(string ownerId)
		{
			return await context.Owners
				.Where(o => o.Id.ToString() == ownerId && o.IsActive == true)
				.Select(o => new OwnerFormModel()
				{
					Name = o.Name,
					Address = o.Address,
					PhoneNumber = o.PhoneNumber,
					Email = o.Email
				})
				.FirstAsync();
		}

		public async Task EditOwnerAsync(OwnerFormModel model, string ownerId)
		{
			Owner ownerToEdit = await this.context.Owners
				.FirstAsync(o => o.Id.ToString() == ownerId);

			ownerToEdit.Name = model.Name;
			ownerToEdit.Address = model.Address;
			ownerToEdit.PhoneNumber = model.PhoneNumber;
			ownerToEdit.Email = model.Email;

			await this.context.SaveChangesAsync();
		}
	}
}

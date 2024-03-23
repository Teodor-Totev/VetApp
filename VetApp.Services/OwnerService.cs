namespace VetApp.Services
{
	using Microsoft.EntityFrameworkCore;
	using Web.ViewModels.Owner.Enums;
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


		public async Task<AllOwnersOrderedAndPagedServiceModel> GetAllOwnersAsync(AllOwnersQueryModel model)
		{
			IQueryable<Owner> query = context.Owners
				.Where(o => o.IsActive == true)
				.Include(o => o.Patients)
				.AsQueryable();

			if (!string.IsNullOrEmpty(model.SearchString))
			{
				string wildCard = $"%{model.SearchString.ToLower()}%";

				query = query
					.Where(o => EF.Functions.Like(o.Name, wildCard) ||
								EF.Functions.Like(o.PhoneNumber, wildCard) ||
								EF.Functions.Like(o.Address, wildCard));
			}

			switch (model.OwnerSorting)
			{
				case OwnerSorting.OwnerName:
					query = query.OrderBy(o => o.Name);
					break;
				case OwnerSorting.OwnerNameDescending:
					query = query.OrderByDescending(o => o.Name);
					break;
				case OwnerSorting.AnimalsCount:
					query = query
						.OrderBy(o => o.Patients.Count())
						.ThenBy(o => o.Name);
					break;
				case OwnerSorting.AnimalsCountDescending:
					query = query
						.OrderByDescending(o => o.Patients.Count())
						.ThenBy(o => o.Name);
					break;
				default:
					query = query.OrderBy(o => o.Name);
					break;
			}

			var owners = await query
				.Skip((model.CurrentPage - 1) * model.OwnersPerPage)
				.Take(model.OwnersPerPage)
				.Select(o => new OwnerViewModel()
				{
					Id = o.Id.ToString(),
					Name = o.Name,
					Address = o.Address,
					PhoneNumber = o.PhoneNumber,
					Email = o.Email,
				})
				.ToArrayAsync();

			return new AllOwnersOrderedAndPagedServiceModel()
			{
				TotalOwnersCount = await query.CountAsync(),
				Owners = owners
			};
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

		public async Task<OwnerViewModel> GetOwnerByIdAsync(string ownerId)
		{
			return await this.context.Owners
				.Where(o => o.Id.ToString() == ownerId && o.IsActive == true)
				.Select(o => new OwnerViewModel()
				{
					Id = o.Id.ToString(),
					Name = o.Name,
					Address = o.Address,
					PhoneNumber = o.PhoneNumber,
					Email = o.Email
				})
				.FirstAsync ();
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

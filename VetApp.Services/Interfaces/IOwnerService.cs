﻿namespace VetApp.Services.Interfaces
{
	using VetApp.Web.ViewModels.Owner;
	using VetApp.Web.ViewModels.Patient;

	public interface IOwnerService
	{
		Task<ICollection<OwnerViewModel>> GetOwnersAsync(string phoneNumber);

		Task<OwnerViewModel> GetOwnerByIdAsync(string ownerId);
	}
}

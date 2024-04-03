namespace VetApp.Services.Extensions.Owner
{
	using VetApp.Data.Models;
	using VetApp.Web.ViewModels.Patient;

	public static class OwnerExatensions
	{
		public static OwnerViewModel ToViewModel(this Owner owner)
		{
			return new OwnerViewModel()
			{
				Id = owner.Id.ToString(),
				Name = owner.Name,
				Email = owner.Email,
				Address = owner.Address,
				PhoneNumber = owner.PhoneNumber,
			};
		}
	}
}

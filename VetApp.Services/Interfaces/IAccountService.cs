using VetApp.Web.ViewModels.Account;

namespace VetApp.Services.Interfaces
{
	public interface IAccountService
	{
		Task<string> GetUserFullNameByEmail(string email);
	}
}

using Microsoft.EntityFrameworkCore;
using VetApp.Data;
using VetApp.Data.Models;
using VetApp.Services.Interfaces;

namespace VetApp.Services
{
	public class AccountService : IAccountService
	{
		private readonly VetAppDbContext context;

		public AccountService(VetAppDbContext context)
		{
			this.context = context;
		}

		public async Task<string> GetUserFullNameByEmail(string email)
		{
			VetUser? user = await context.Users
				.FirstOrDefaultAsync(u => u.UserName == email);

			if (user == null)
			{
				return string.Empty;
			}

			return $"{user.FirstName} {user.LastName}";
		}
	}
}

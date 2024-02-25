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

		public async Task<string> GetUserFullNameByUsername(string username)
		{
			ApplicationUser? user = await context.Users
				.FirstOrDefaultAsync(u => u.UserName == username);

			if (user == null)
			{
				return string.Empty;
			}

			return $"Dr. {user.FirstName} {user.LastName}";
		}
	}
}

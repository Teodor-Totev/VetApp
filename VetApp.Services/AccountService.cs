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

		public async Task<string> GetUserFullNameByUsernameAsync(string username)
		{
			ApplicationUser? user = await context.Users
				.FirstOrDefaultAsync(u => u.UserName == username);

			if (user == null)
			{
				return string.Empty;
			}

			return $"{user.FirstName} {user.LastName}";
		}

		public async Task<bool> UserExistsAsync(string id)
			=> await this.context.Users.AnyAsync(u => u.Id.ToString() == id);
    }
}

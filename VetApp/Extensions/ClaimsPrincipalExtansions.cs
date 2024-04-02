namespace VetApp.Extensions
{
	using System.Security.Claims;
	using static VetApp.Data.Common.AdminUser;

	public static class ClaimsPrincipalExtansions
	{
		public static string Id(this ClaimsPrincipal user)
			=> user.FindFirstValue(ClaimTypes.NameIdentifier);

		public static bool IsAdmin(this ClaimsPrincipal user)
			=> user.IsInRole(AdminRoleName);
	}
}

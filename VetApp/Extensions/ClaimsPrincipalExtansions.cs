namespace VetApp.Extensions
{
	using System.Security.Claims;

	public static class ClaimsPrincipalExtansions
	{
		public static string Id(this ClaimsPrincipal user)
			=> user.FindFirstValue(ClaimTypes.NameIdentifier);
	}
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace VetApp.Controllers
{
	[Authorize]
	public class BaseController : Controller
	{
        internal string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}

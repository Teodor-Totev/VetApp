using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VetApp.Controllers
{
	[Authorize]
	public class BaseController : Controller
	{
    }
}

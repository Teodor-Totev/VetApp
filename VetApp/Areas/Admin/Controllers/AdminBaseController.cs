namespace VetApp.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using static VetApp.Data.Common.AdminUser;

	[Area(AdminAreaName)]
	[Authorize(Roles = AdminRoleName)]
	public class AdminBaseController : Controller
	{
        
    }
}

﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VetApp.Web.ViewModels.Home;

namespace VetApp.Controllers
{
	public class HomeController : BaseController
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Examination");
            }
            else
            {
                return View();
            }
        }

		public IActionResult GetWeight(double weight)
		{
			return Ok(new { weight });
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

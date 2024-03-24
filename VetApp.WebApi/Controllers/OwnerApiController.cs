namespace VetApp.WebApi.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using VetApp.Services.Interfaces;
	using VetApp.Web.ViewModels.Patient;

	[Route("api/owner")]
	[ApiController]
	public class OwnerApiController : ControllerBase
	{
		private readonly IOwnerService ownerService;

        public OwnerApiController(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }

		[HttpGet]
		[Produces("application/json")]
		[ProducesResponseType(typeof(IEnumerable<OwnerViewModel>), 200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetAllExistingOwners()
		{
			try
			{
				IEnumerable<OwnerViewModel> allExistingOwners = 
					await this.ownerService.GetAllExistingOwnersAsync();

				return Ok(allExistingOwners);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}
    }
}

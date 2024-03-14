namespace VetApp.WebApi.Controllers
{
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;
	using VetApp.Services.Interfaces;
	using VetApp.Services.Models.Owner;

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
		[ProducesResponseType(typeof(IEnumerable<AllExistingOwnersServiceModel>), 200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetAllExistingOwners()
		{
			try
			{
				IEnumerable<AllExistingOwnersServiceModel> allExistingOwners = 
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

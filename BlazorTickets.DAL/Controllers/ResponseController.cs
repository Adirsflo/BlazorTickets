using Microsoft.AspNetCore.Mvc;
using Shared.ViewModels;

namespace BlazorTickets.DAL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResponseController : ControllerBase
	{
		//private DbContext context; /*Fältvariabel för dependency injection databas*/
		public List<ResponseModel>? Responses { get; set; }

		[HttpGet]
		public ActionResult<List<ResponseModel>> Get()
		{
			//Responses = context.Responses.ToList(); // Hämta alla responses i databasen och lägg dessa i listan
			return Ok(Responses);
		}
		// Posta en ny respons
		[HttpPost]
		public ActionResult PostResponse(ResponseModel responseModel)
		{
			if (responseModel != null)
			{
				//context.Responses.Add(responseModel); /*Lägg till responsen*/
				//context.SaveChanges();
				return Ok();

			}
			return BadRequest();
		}

	}
}

using Microsoft.AspNetCore.Mvc;
using Shared.ViewModels;

namespace BlazorTickets.DAL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResponseController : ControllerBase
	{
		/*Fältvariabel för dependency injection databas*/
		//private DbContext context; 
		public List<ResponseModel>? Responses { get; set; }

		[HttpGet]
		public ActionResult<List<ResponseModel>> Get()
		{
			// Hämta alla responses i databasen och lägg dessa i listan
			//Responses = context.Responses.ToList(); 
			return Ok(Responses);
		}
		// Posta en ny respons
		[HttpPost]
		public ActionResult PostResponse(ResponseModel responseModel)
		{
			if (responseModel != null)
			{
				/*Lägg till responsen*/
				//context.Responses.Add(responseModel); 
				//context.SaveChanges();
				return Ok();

			}
			return BadRequest();
		}

	}
}

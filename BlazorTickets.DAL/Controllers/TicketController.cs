using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.ViewModels;

namespace BlazorTickets.DAL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TicketController : ControllerBase
	{
		public List<TicketModel>? Tickets { get; set; }

		/*Privat fältvariabel för dependency injection*/
		private readonly DbContext context;

		//Constructor för DI
		public TicketController(DbContext context)
		{
			this.context = context;
		}

		// Hämta alla tickets i en lista
		[HttpGet]
		public async Task<ActionResult<List<TicketModel>>> Get()
		{
			/*Hämta alla tickets i databasen och lägg in dem i listan, använd include kanske?*/
			//Tickets = await context.Tickets
			//.Include(t =>
			// {
			//	 t.Responses;
			// });
			//.ToList();
			return Ok(Tickets);
		}

		[HttpGet("{id:int}")]
		//public async Task<ActionResult<TicketModel>> GetSingleTicket(int id)
		//{
		//	//Hämta ticketen ur databasen
		//	//TicketModel? ticket = await context.Tickets
		//	//.Include(t =>
		//	// {
		//	//	 t.Responses;
		//	// });
		//	//FirstOrDefault(x => x.Id == id);

		//	//if (ticket != null)
		//	//{
		//	//	return Ok(ticket);
		//	//}
		//	//return NotFound();
		//}

		// Posta en ny ticket
		[HttpPost]
		public async Task<ActionResult<List<TicketModel>>> PostTicket(TicketModel model)
		{
			if (model != null)
			{
				/*Lägg till ticketen i databasen*/
				//context.Tickets.Add(model); 
				// await context.SaveChanges();
				return Ok();
			}
			return BadRequest();
		}

		//Ändra en existerande ticket
		[HttpPut("{id:int}")]
		public ActionResult UpdateTicket(int id, TicketModel model)
		{
			if (model != null)
			{
				/*Hämta den du ska edita*/
				//TicketModel ticketToEdit = context.Tickets.FirstOrDefault(x => x.id == id); 
				//ticketToEdit.Title = model.Title;
				//ticketToEdit.Description = model.Description;
				//ticketToEdit.IsResolved = model.IsResolved;
				//ticketToEdit.TicketTags = model.TicketTags;
				//context.SaveChanges();
				return Ok(model);
			}
			return BadRequest();
		}

		[HttpDelete("{id:int}")]
		public ActionResult DeleteTicket(int id)
		{
			if (id != null)
			{
				//TicketModel? model = context.Tickets.FirstOrDefault(x => x.id == id);
				//if(model != null)
				//{
				//context.Remove(Model);
				//context.SaveChanges();
				//return Ok();

				//}
				return NotFound();
			}
			return BadRequest();
		}
	}
}

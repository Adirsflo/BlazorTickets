using Microsoft.AspNetCore.Mvc;

namespace BlazorTickets.DAL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TicketController : ControllerBase
	{
		public List<TicketModel>? Tickets { get; set; }
		//private DbContext context; /*Privat fältvariabel för dependency injection*/

		// Hämta alla tickets i en lista
		[HttpGet]
		public ActionResult<List<TicketModel>> Get()
		{
			//Tickets = context.Tickets.ToList(); /*Hämta alla tickets i databasen och lägg in dem i listan*/
			return Ok(Tickets);
		}

		// Posta en ny ticket
		[HttpPost]
		public ActionResult PostTicket(TicketModel model)
		{
			if (model != null)
			{
				//context.Tickets.Add(model); /*Lägg till ticketen i databasen*/
				//context.SaveChanges();
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
				//TicketModel ticketToEdit = context.Tickets.FirstOrDefault(x => x.id == id); /*Hämta den du ska edita*/
				//ticketToEdit.Title = model.Title;
				//ticketToEdit.Description = model.Description;
				//ticketToEdit.IsResolved = model.IsResolved;
				//ticketToEdit.TicketTags = model.TicketTags;
				//context.Update(ticketToEdit);
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

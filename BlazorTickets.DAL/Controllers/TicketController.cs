using BlazorTickets.DAL.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.ViewModels;

namespace BlazorTickets.DAL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TicketController : ControllerBase
	{

		/*Privat fältvariabel för dependency injection*/
		private readonly AppDbContext _context;

		//Constructor för DI
		public TicketController(AppDbContext context)
		{
			_context = context;
		}

		// Hämta alla tickets i en lista
		[HttpGet]
		public async Task<ActionResult<List<TicketModel>>> GetAllTickets()
		{
			/*Hämta alla tickets i databasen och lägg in dem i listan, använd include kanske?*/
			List<TicketModel>? tickets = await _context.Tickets
			.Include(t => t.TicketTags)
			.Include(r => r.Responses)
			.ToListAsync();
			return Ok(tickets);
		}


		[HttpGet("{id:int}")]
		public async Task<ActionResult<TicketModel>> GetSingleTicket(int id)
		{
			//Hämta ticketen ur databasen
			TicketModel? ticket = await _context.Tickets
			.Include(t => t.Responses)
			.Include(r => r.TicketTags)
			.FirstOrDefaultAsync(x => x.Id == id);

			if (ticket != null)
			{
				return Ok(ticket);
			}
			return NotFound();
		}

		// Posta en ny ticket
		[HttpPost]
		public async Task<ActionResult<List<TicketModel>>> CreateTicket(TicketModel model)
		{
			model.Responses = null;

			if (model != null)
			{
				_context.Tickets.Add(model);
				await _context.SaveChangesAsync();
				return Ok(GetAllDbTickets());
			}
			return BadRequest();
		}

		//Ändra en existerande ticket
		[HttpPut("{id:int}")]
		public async Task<ActionResult<List<TicketModel>>> UpdateTicket(int id, TicketModel model)
		{
			var dbTicket = await _context.Tickets
				.Include(t => t.TicketTags)
				.Include(r => r.Responses)
				.FirstOrDefaultAsync(h => h.Id == id);
			if (dbTicket != null)
			{
				dbTicket.Title = model.Title;
				dbTicket.Description = model.Description;
				dbTicket.TicketTags = model.TicketTags;
				dbTicket.IsResolved = model.IsResolved;
				await _context.SaveChangesAsync();

				return base.Ok(GetAllDbTickets());

			}
			return NotFound("Sorry couldn't find that Ticket");
		}

		private List<TicketModel> GetAllDbTickets()
		{
			return _context.Tickets.Include(t => t.TicketTags).Include(r => r.Responses).ToList();
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

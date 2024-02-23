using BlazorTickets.DAL.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.ViewModels;

namespace BlazorTickets.DAL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResponseController : ControllerBase
	{
		/*Fältvariabel för dependency injection databas*/
		private AppDbContext _context;

		public ResponseController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<ResponseModel>>> GetAllResponses()
		{
			/*Hämta alla responses i databasen och lägg in dem i listan, använd include kanske?*/
			List<ResponseModel>? responses = await _context.Responses
			.Include(t => t.Ticket)
			.ToListAsync();
			return Ok(responses);
		}

		[HttpGet("{int:id")]
		public async Task<ActionResult<List<ResponseModel?>>> GetAllResponsesForSingleTicket(int ticketId)
		{
			TicketModel? ticket = await _context.Tickets
				.Include(t => t.Responses)
				.FirstOrDefaultAsync(h => h.Id == ticketId);
			if (ticket.Responses != null)
			{

				return Ok(ticket.Responses);
			}
			return NotFound("Couldn't find any responses, Have you checked if there are any?");
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<ResponseModel>> GetSingleResponse(int id)
		{
			ResponseModel? response = await _context.Responses
			.Include(t => t.Ticket)
			.FirstOrDefaultAsync(h => h.Id == id);
			return Ok(response);
		}

		// Posta en ny respons
		[HttpPost]
		public async Task<ActionResult> PostResponse(ResponseModel responseModel, TicketModel ticket)
		{
			// Kolla så att modellerna inte är null
			if (responseModel != null && ticket != null)
			{
				// Lägg till responset i ticketen
				ticket.Responses.Add(responseModel);

				// Hitta motsvarande ticket i databasen
				TicketModel? dbTicket = await _context.Tickets
					.Include(r => r.Responses)
					.FirstOrDefaultAsync(t => t.Id == ticket.Id);

				// Lägg till responsen i databas ticketen
				dbTicket.Responses = ticket.Responses;
				await _context.SaveChangesAsync();
				return Ok();
			}
			return BadRequest();
		}

	}
}

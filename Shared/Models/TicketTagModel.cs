using System.ComponentModel.DataAnnotations;

namespace Shared.ViewModels
{
	public class TicketTagModel
	{
		[Key]
		public int TicketId { get; set; }
		public TicketModel Ticket { get; set; } = null!;
		[Key]
		public int TagId { get; set; }
		public TagModel Tag { get; set; } // Sparas som ett heltal (int) i databasen(enumens value), går sedan att omvandla till det motsvarande namnet

	}
}

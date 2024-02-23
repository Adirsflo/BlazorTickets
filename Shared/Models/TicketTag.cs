namespace Shared.ViewModels
{
	public class TicketTag
	{
		public int TicketId { get; set; }
		public TicketModel Ticket { get; set; } = null!;
		public int TagId { get; set; }
		public TagModel Tag { get; set; } = null!; // Sparas som ett heltal (int) i databasen(enumens value), går sedan att omvandla till det motsvarande namnet

	}
}

namespace Shared.ViewModels
{
	public class TagModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public List<TicketTag> TicketTags { get; set; } = new List<TicketTag>();

	}
}

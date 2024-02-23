namespace Shared.ViewModels
{
	public class TagModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<TicketTagModel> TicketTags { get; set; } = new List<TicketTagModel>();

	}
}

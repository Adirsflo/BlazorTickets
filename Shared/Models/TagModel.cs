namespace Shared.ViewModels
{
	internal class TagModel
	{
		public int Id { get; set; }
		public string Name { get; set; } // Exempel: "CSharp", "JavaScript"
		public List<TicketTagModel> TicketTags { get; set; } = new List<TicketTagModel>();

	}
}

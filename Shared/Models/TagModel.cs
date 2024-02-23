using System.ComponentModel.DataAnnotations;

namespace Shared.ViewModels
{
	public class TagModel
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public List<TicketTagModel> TicketTags { get; set; } = new List<TicketTagModel>();

	}
}

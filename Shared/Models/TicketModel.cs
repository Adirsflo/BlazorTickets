using System.ComponentModel.DataAnnotations;

namespace Shared.ViewModels
{
	public class TicketModel
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		public string SubmittedBy { get; set; } = null!;// Användarnamn eller e-post
		public bool IsResolved { get; set; }
		public List<TicketTagModel>? TicketTags { get; set; } = new List<TicketTagModel>();
		public List<ResponseModel>? Responses { get; set; } = new List<ResponseModel>();

	}
}

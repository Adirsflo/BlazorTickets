namespace BlazorTickets.Models
{
	public class TicketViewModel
	{
		// TODO: Kolla igenom listan mer noggrant
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string SubmittedBy { get; set; } // Användarnamn eller e-post
		public bool IsResolved { get; set; }
		public List<TicketTag> TicketTags { get; set; } = new List<TicketTag>
		();
		public List<ResponseModel> Responses { get; set; } = new List<ResponseMod



		el>();
	}
}

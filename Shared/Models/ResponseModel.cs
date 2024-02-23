using System.ComponentModel.DataAnnotations;

namespace Shared.ViewModels
{
	public class ResponseModel
	{
		[Key]
		public int Id { get; set; }
		public string Response { get; set; }
		public string SubmittedBy { get; set; }
		[Key]
		public int TicketId { get; set; }
		public TicketModel Ticket { get; set; }
	}
}

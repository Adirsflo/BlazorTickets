﻿namespace Shared.ViewModels
{
	public class TicketModel
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		public string SubmittedBy { get; set; } = null!;
		public bool IsResolved { get; set; }
		public List<TicketTag>? TicketTags { get; set; } = new List<TicketTag>();
		public List<ResponseModel>? Responses { get; set; } = new List<ResponseModel>();

	}
}

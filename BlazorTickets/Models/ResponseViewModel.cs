﻿namespace BlazorTickets.Models
{
    public class ResponseViewModel
    {
        public int Id { get; set; }
        public string Response { get; set; }
        public string SubmittedBy { get; set; }
        public int TicketId { get; set; }
        public TicketViewModel Ticket { get; set; }
    }
}

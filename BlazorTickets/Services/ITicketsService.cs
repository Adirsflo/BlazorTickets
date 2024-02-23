using BlazorTickets.Models;

namespace BlazorTickets.Services
{
    public interface ITicketsService
    {
        public HttpClient Client { get; set; }

        public Task<List<TicketViewModel>> GetTickets();

        public Task PostTicket(TicketViewModel viewModel);
    }
}

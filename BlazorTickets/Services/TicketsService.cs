using BlazorTickets.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BlazorTickets.Services
{
    public class TicketsService : ITicketsService
    {
        public HttpClient Client { get; set; } = new()
        {
            BaseAddress = new Uri("https://localhost:7175/api/")
        };

        public async Task<List<TicketViewModel>> GetTickets()
        {
            var response = await Client.GetAsync("ticket");

            if (response.IsSuccessStatusCode)
            {
                string ticketsJson = await response.Content.ReadAsStringAsync();

                List<TicketViewModel>? tickets = JsonConvert.DeserializeObject<List<TicketViewModel>>(ticketsJson);

                if (tickets != null)
                {
                    return tickets;
                }

                throw new JsonException();
            }

            throw new HttpRequestException();
        }

        public async Task PostTicket(TicketViewModel viewModel)
        {
            await Client.PostAsJsonAsync("ticket", viewModel);
        }
    }
}

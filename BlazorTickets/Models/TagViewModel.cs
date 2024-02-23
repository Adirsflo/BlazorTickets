namespace BlazorTickets.Models
{
    public class TagViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } // Exempel: "CSharp", "JavaScript"
        public List<TicketViewTag> TicketTags { get; set; } = new List<TicketViewTag>();
    }
}

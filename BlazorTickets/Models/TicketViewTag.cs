namespace BlazorTickets.Models
{
    public class TicketViewTag
    {
        // TODO: Kolla igenom listan mer noggrant
        public int TicketId { get; set; }
        public TicketViewModel Ticket { get; set; }
        public int TagId { get; set; }
        public TagViewModel Tag { get; set; } // Sparas som ett heltal (int) i databasen(enumens value),
                                              // går sedan att omvandla till det motsvarande namnet
    }
}

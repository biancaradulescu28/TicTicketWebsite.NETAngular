namespace TicTicket.Models
{
    public class TicketTypeEvent
    {
        public int Id { get; set; }
        public int TicketTypeId { get; set; }
        public TicketTypes TicketTypes { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
       
    }
}

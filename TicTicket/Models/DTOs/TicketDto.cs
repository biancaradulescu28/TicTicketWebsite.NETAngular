namespace TicTicket.Models.DTOs
{
    public class TicketDto
    {
        public string? Seat { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        public int EventId { get; set; }//FK Event
        public Event? Event { get; set; }
    }
}

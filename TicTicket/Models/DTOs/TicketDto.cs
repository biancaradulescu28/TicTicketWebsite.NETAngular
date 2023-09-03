using Newtonsoft.Json;

namespace TicTicket.Models.DTOs
{
    public class TicketDto
    {
        [JsonIgnore]
        public TicketTypes? Type { get; set; } = new TicketTypes();
        public string? Seat { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        public int EventId { get; set; }//FK Event

    }
}

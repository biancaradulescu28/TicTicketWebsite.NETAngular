using Newtonsoft.Json;

namespace TicTicket.Models
{
    public class TicketTypes
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public int? EventId { get; set; }

        [JsonIgnore]
        public List<Event>? Event { get; set; }
    }
}

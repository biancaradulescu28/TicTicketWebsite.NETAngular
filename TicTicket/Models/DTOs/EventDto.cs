using Newtonsoft.Json;
using TicTicket.Models;

namespace TicTicket.Models.DTOs
{
    public class EventDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NrTickets { get; set; } = 0;
        public int NrTicketsAvailable { get; set; } = 0;
        public int AgeLimit { get; set; } = 0;//?
        public int AddressId { get; set; } = 1;

        [JsonIgnore]
        public List<TicketTypes> TicketTypes { get; set; } = new List<TicketTypes>();
    }
}

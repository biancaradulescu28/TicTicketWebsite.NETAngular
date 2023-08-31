using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace TicTicket.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set;}
        public int NrTickets { get; set; } = 0;
        public int NrTicketsAvailable { get; set; } = 0;
        public int AgeLimit { get; set; } = 0;//?
        public int AddressId { get; set; }//FK Address

        [JsonIgnore]
        public List<TicketTypes>? TicketTypes { get; set; }
        public Address? Address { get; set; }

    }
}

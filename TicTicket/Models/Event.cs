using System.Text.Json.Serialization;

namespace TicTicket.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set;}
        public int NrTickets { get; set; } = 0;
        public int NrTicketsAvailable { get; set; } = 0;
        public int AgeLimit { get; set; } = 0;//?
        public int AddressId { get; set; }//FK Address
        public Address? Address { get; set; }

        [JsonIgnore]
        public List<Ticket>? Tickets { get; set; }

    }
}

using TicTicket.Models;

namespace TicTicket.Models.DTOs
{
    public class EventDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string? EndDate { get; set; } = string.Empty;
        public int NrTickets { get; set; } = 0;
        public int NrTicketsAvailable { get; set; } = 0;
        public int AgeLimit { get; set; } = 0;//?
        public int AddressId { get; set; } = 1;
        public List<Ticket>? Tickets { get; set; }
    }
}

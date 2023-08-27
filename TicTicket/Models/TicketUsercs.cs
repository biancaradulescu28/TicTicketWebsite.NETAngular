using TicTicket.Models.Enums;

namespace TicTicket.Models
{
    public class TicketUsercs
    {
        public int TicketId { get; set; }
        public Ticket ticket { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }
        public Status status { get; set; }
    }
}

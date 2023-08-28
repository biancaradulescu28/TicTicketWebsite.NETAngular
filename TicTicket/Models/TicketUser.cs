using Newtonsoft.Json;

using TicTicket.Models.Enums;

namespace TicTicket.Models
{
    public class TicketUser
    {
        public int Id { get; set; }
        public int TicketsId { get; set; }
        public Ticket ticket { get; set; }
        public int UsersId { get; set; }
        public User user { get; set; }
        public Status status { get; set; }
    }
}

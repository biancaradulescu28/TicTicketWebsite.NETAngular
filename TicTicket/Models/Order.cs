using Newtonsoft.Json;

namespace TicTicket.Models
{
    public class Order
    {
        public int Id { get; set; }
        public double Price { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public int UserId { get; set; }//FK User

        public List<Ticket>? Tickets { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
        
    }
}

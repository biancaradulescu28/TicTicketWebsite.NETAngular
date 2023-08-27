using Newtonsoft.Json;

namespace TicTicket.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int Quantity { get; set; } = 0;
        public double Price { get; set; } = 0;
        public int UserId { get; set; }//FK User

        [JsonIgnore]
        public User? User { get; set; }

    }
}

using Newtonsoft.Json;

namespace TicTicket.Models.DTOs
{
    public class CartDto
    {
        public int Quantity { get; set; } = 0;
        public double Price { get; set; } = 0;
        public int UserId { get; set; }//FK User
    }
}

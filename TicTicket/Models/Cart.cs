namespace TicTicket.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int Status { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public double Price { get; set; } = 0;
        public int UserId { get; set; }//FK User
        public User? User { get; set; }

    }
}

namespace TicTicket.Models.DTOs
{
    public class OrderDto
    {
        public double Price { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public int UserId { get; set; }//FK User

        public List<Ticket>? Tickets { get; set; } = new List<Ticket>();
    }
}

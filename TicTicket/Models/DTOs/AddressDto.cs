namespace TicTicket.Models.DTOs
{
    public class AddressDto
    {
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int Number { get; set; } = 0;
    }
}

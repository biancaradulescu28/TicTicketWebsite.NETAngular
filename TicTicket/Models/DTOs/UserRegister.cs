namespace TicTicket.Models.DTOs
{
    public class UserRegister
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public string Password { get; set; } = string.Empty;
    }
}

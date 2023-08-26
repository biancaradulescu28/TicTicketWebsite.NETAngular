using System.Data;

namespace TicTicket.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public List<Order>? Orders { get; set; }
        public List<Ticket> Tickets { get; set; }

        //[JsonIgnore]//nu o sa ia in calcul si passwordHash
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        //public Role Role { get; set; }
    }
}

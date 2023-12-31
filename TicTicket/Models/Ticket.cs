﻿using Newtonsoft.Json;

namespace TicTicket.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public int? TicketTypesId { get; set; }

        [JsonIgnore]
        public TicketTypes? TicketTypes { get; set; }
        public string? Seat { get; set; } = string.Empty;
        public double Price { get; set; } = 0;

        public int EventId { get; set; }//FK Event

        [JsonIgnore]
        public Event? Event { get; set; }

        [JsonIgnore]
        public int? OrderId { get; set; }//FK Order
        [JsonIgnore]
        public Order? Order { get; set; }

        [JsonIgnore]
        public List<User>? Users { get; set; }
        //many to many cu user cat timp biletele sunt in cart
    }
}

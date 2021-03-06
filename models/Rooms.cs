using System.Collections.Generic;

namespace Models
{
    public class Room
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int Capacity { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}

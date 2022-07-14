using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ReservationGuest
    {
        public int Id { get; set; }

        public int ReservationId { get; set; }
        [Required(ErrorMessage = "Please fill information about the Reservation")]
        public Reservation Reservation { get; set; }

        public int ClientId { get; set; }
        [Required(ErrorMessage = "Please fill information about Client")]
        public Client Client { get; set; }
    }
}

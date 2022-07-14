using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide client name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide client email")]
        public string Email { get; set; }

        public ReservationGuest ReservationsData { get; set; }
    }
}

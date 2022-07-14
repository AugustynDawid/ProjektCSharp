using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide information about choosen room")]
        public Room Room { get; set; }

        public List<ReservationGuest> ReservationGuests { get; set; }

        [Required(ErrorMessage = "Please provide reservation start date")]
        public DateTime ReservationStart { get; set; }

        [Required(ErrorMessage = "Please provide reservation emd date")]
        public DateTime ReservationEnd { get; set; }
    }
}

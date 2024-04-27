using System.ComponentModel.DataAnnotations;

namespace Biuro_Wycieczek.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        public DateTime ReservationDate { get; set; }

        public int? TripsId { get; set; }
        public Trips? IdTrips { get; set; }

        public int? ClientsId { get; set; }
        public Client? IdClients { get; set; }
    }
}

using System.Collections.Generic;
using TourAgency.Models;

namespace TourAgency.ViewModelPages
{
    public class ReservationsViewModelPages
    {
        public IEnumerable<Reservation> Reservations { get; set; }
        public int TotalReservations { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
    }
}

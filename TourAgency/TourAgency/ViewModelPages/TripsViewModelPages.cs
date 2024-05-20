using TourAgency.Models;
using System.Collections.Generic;

namespace TourAgency.ViewModelPages
{
    public class TripsViewModelPages
    {
        public IEnumerable<Trips> Trips { get; set; }
        public int TotalTrips { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
    }
}

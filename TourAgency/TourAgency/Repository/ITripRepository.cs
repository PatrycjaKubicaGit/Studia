using System.Collections.Generic;
using TourAgency.Models;

namespace TourAgency.Repository
{
    public interface ITripRepository
    {
        IEnumerable<Trips> GetAllTrips();
        Trips GetTripById(int id);
        void InsertTrip(Trips trip);
        void UpdateTrip(Trips trip);
        void DeleteTrip(int id);
        void Save();
    }
}

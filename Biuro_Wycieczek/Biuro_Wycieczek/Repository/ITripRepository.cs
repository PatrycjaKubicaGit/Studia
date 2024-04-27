using System.Collections.Generic;
using Biuro_Wycieczek.Models;

namespace Biuro_Wycieczek.Repository
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

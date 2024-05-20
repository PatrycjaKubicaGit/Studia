using System.Collections.Generic;
using TourAgency.Models;

namespace TourAgency.Repository
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAllReservations();
        Reservation GetReservationById(int id);
        void InsertReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(int id);
        void Save();
    }
}

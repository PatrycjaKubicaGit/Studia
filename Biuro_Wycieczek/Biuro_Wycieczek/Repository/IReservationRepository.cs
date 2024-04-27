using System.Collections.Generic;
using Biuro_Wycieczek.Models;

namespace Biuro_Wycieczek.Repository
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

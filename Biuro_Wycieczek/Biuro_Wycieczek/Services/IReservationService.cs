using System.Collections.Generic;
using Biuro_Wycieczek.Models;

namespace Biuro_Wycieczek.Services
{
    public interface IReservationService
    {
        IEnumerable<Reservation> GetAllReservations();
        List<Trips> GetTrips();
        List<Client> GetClients();
        IEnumerable<Reservation> GetReservationPerPage(int page, int pageSize);
        int GetTotalNumberOfReservations();
        void AddReservation(Reservation model);
        Reservation GetReservationById(int ReservationId);
        void UpdateReservation(Reservation model);
        void DeleteReservation(int ReservationId);
    }
}

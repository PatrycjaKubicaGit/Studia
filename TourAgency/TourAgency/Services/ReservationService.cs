using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TourAgency.Models;
using TourAgency.Data;
using TourAgency.Repository;

namespace TourAgency.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(ApplicationDbContext context, IReservationRepository reservationRepository)
        {
            _context = context;
            _reservationRepository = reservationRepository;
        }
        public int GetTotalNumberOfReservations()
        {
            var reservations = _reservationRepository.GetAllReservations();
            return reservations.Count();
        }

        public IEnumerable<Reservation> GetReservationPerPage(int page, int pageSize)
        {
            var allRezerwacje = _reservationRepository.GetAllReservations();
            return allRezerwacje.Skip((page - 1) * pageSize).Take(pageSize);
        }


        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservationRepository.GetAllReservations();
        }

        public List<Trips> GetTrips()
        {
            return _context.Trips.ToList() ?? new List<Trips>();
        }

        public List<Client> GetClients()
        {
            return _context.Clients.ToList() ?? new List<Client>();
        }

        public void AddReservation(Reservation model)
        {
            if (model.ClientsId.HasValue)
            {
                model.IdClients = _context.Clients.Find(model.ClientsId);
            }

            if (model.TripsId.HasValue)
            {
                model.IdTrips = _context.Trips.Find(model.TripsId);
            }

            _reservationRepository.InsertReservation(model);
            _reservationRepository.Save();
        }

        public Reservation GetReservationById(int RezerwacjaId)
        {
            return _reservationRepository.GetReservationById(RezerwacjaId);
        }

        public void UpdateReservation(Reservation model)
        {
            if (model.ClientsId.HasValue)
            {
                model.IdClients = _context.Clients.Include(k => k.Reservations).FirstOrDefault(k => k.ClientId == model.ClientsId);
            }

            if (model.TripsId.HasValue)
            {
                model.IdTrips = _context.Trips.Include(w => w.Reservations).FirstOrDefault(w => w.TripsId == model.TripsId);
            }

            _reservationRepository.UpdateReservation(model);
            _reservationRepository.Save();
        }

        public void DeleteReservation(int IdRezerwacji)
        {
            _reservationRepository.DeleteReservation(IdRezerwacji);
            _reservationRepository.Save();
        }
    }
}

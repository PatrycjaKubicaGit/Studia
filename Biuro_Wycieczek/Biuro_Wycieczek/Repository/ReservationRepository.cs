using System;
using System.Collections.Generic;
using System.Linq;
using Biuro_Wycieczek.Data;
using Biuro_Wycieczek.Models;
using Microsoft.EntityFrameworkCore;

namespace Biuro_Wycieczek.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly BiuroContext _context;

        public ReservationRepository(BiuroContext context)
        {
            _context = context;
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _context.Reservations.ToList();
        }

        public Reservation GetReservationById(int id)
        {
            return _context.Reservations.FirstOrDefault(r => r.ReservationId == id);
        }

        public void InsertReservation(Reservation rezerwacja)
        {
            _context.Reservations.Add(rezerwacja);
        }

        public void UpdateReservation(Reservation rezerwacja)
        {
            _context.Entry(rezerwacja).State = EntityState.Modified;
        }

        public void DeleteReservation(int id)
        {
            var rezerwacja = _context.Reservations.Find(id);
            if (rezerwacja != null)
            {
                _context.Reservations.Remove(rezerwacja);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

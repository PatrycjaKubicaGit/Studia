using System;
using System.Collections.Generic;
using System.Linq;
using Biuro_Wycieczek.Data;
using Biuro_Wycieczek.Models;
using Biuro_Wycieczek.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Biuro_Wycieczek.Repository
{
    public class TripRepository : ITripRepository
    {
        private readonly BiuroContext _context;

        public TripRepository(BiuroContext context)
        {
            _context = context;
        }

        public IEnumerable<Trips> GetAllTrips()
        {
            return _context.Trips.ToList();
        }

        public Trips GetTripById(int id)
        {
            return _context.Trips.FirstOrDefault(w => w.TripsId == id);
        }

        public void InsertTrip(Trips wycieczka)
        {
            _context.Trips.Add(wycieczka);
        }

        public void UpdateTrip(Trips wycieczka)
        {
            _context.Entry(wycieczka).State = EntityState.Modified;
        }

        public void DeleteTrip(int id)
        {
            var wycieczka = _context.Trips.Find(id);
            if (wycieczka != null)
            {
                _context.Trips.Remove(wycieczka);
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

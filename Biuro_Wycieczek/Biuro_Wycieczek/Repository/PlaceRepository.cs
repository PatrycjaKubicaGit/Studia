using System;
using System.Collections.Generic;
using System.Linq;
using Biuro_Wycieczek.Data;
using Biuro_Wycieczek.Models;
using Microsoft.EntityFrameworkCore;

namespace Biuro_Wycieczek.Repository
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly BiuroContext _context;

        public PlaceRepository(BiuroContext context)
        {
            _context = context;
        }

        public IEnumerable<Place> GetAllPlaces()
        {
            return _context.Places.ToList();
        }

        public Place GetPlacesById(int id)
        {
            return _context.Places.FirstOrDefault(m => m.PlaceId == id);
        }

        public void InsertTrip(Place miejsce_Pobytu)
        {
            _context.Places.Add(miejsce_Pobytu);
        }

        public void UpdatePlace(Place miejsce_Pobytu)
        {
            _context.Entry(miejsce_Pobytu).State = EntityState.Modified;
        }

        public void DeletePlace(int id)
        {
            var miejsce_Pobytu = _context.Places.Find(id);
            if (miejsce_Pobytu != null)
            {
                _context.Places.Remove(miejsce_Pobytu);
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

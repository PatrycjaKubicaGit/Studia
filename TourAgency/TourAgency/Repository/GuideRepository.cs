using System;
using System.Collections.Generic;
using System.Linq;
using TourAgency.Data;
using TourAgency.Models;
using TourAgency.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace TourAgency.Repository
{
    public class GuideRepository : IGuideRepository
    {
        private readonly ApplicationDbContext _context;

        public GuideRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Guide> GetAllGuides()
        {
            return _context.Guides.ToList();
        }

        public Guide GetGuideById(int id)
        {
            return _context.Guides.FirstOrDefault(w => w.GuideId == id);
        }

        public void InsertGuide(Guide przewodnik)
        {
            _context.Guides.Add(przewodnik);
        }

        public void UpdateGuide(Guide przewodnik)
        {
            _context.Entry(przewodnik).State = EntityState.Modified;
        }

        public void DeleteGuide(int id)
        {
            var przewodnik = _context.Guides.Find(id);
            if (przewodnik != null)
            {
                _context.Guides.Remove(przewodnik);
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


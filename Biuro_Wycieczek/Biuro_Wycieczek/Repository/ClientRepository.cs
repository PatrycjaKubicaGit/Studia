using System;
using System.Collections.Generic;
using System.Linq;
using Biuro_Wycieczek.Data;
using Biuro_Wycieczek.Models;
using Biuro_Wycieczek.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Biuro_Wycieczek.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly BiuroContext _context;

        public ClientRepository(BiuroContext context)
        {
            _context = context;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }

        public Client GetClientsById(int id)
        {
            return _context.Clients.FirstOrDefault(k => k.ClientId == id);
        }

        public void InsertClient(Client klient)
        {
            _context.Clients.Add(klient);
        }

        public void UpdateClient(Client klient)
        {
            _context.Entry(klient).State = EntityState.Modified;
        }

        public void DeleteClient(int id)
        {
            var klient = _context.Clients.Find(id);
            if (klient != null)
            {
                _context.Clients.Remove(klient);
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

using System.Collections.Generic;
using TourAgency.Models;

namespace TourAgency.Repository
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClients();
        Client GetClientsById(int id);
        void InsertClient(Client klient);
        void UpdateClient(Client klient);
        void DeleteClient(int id);
        void Save();
    }
}

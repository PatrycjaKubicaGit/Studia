using System.Collections.Generic;
using TourAgency.Models;
using TourAgency.Repository;

namespace TourAgency.Services
{
    public interface IClientService
    {
        IEnumerable<Client> GetAllClients();
        IEnumerable<Client> GetClientsPerPage(int page, int pageSize);
        Client GetClientById(int ClientId);
        int GetTotalNumberOfClients();
        void InsertClient(Client model);
        void UpdateClient(Client model);
        void DeleteClient(int ClientId);
        void Save();
    }
}

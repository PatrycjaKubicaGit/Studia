using System.Collections.Generic;
using Biuro_Wycieczek.Models;
using Biuro_Wycieczek.Repository;

namespace Biuro_Wycieczek.Services
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

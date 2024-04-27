using System.Collections.Generic;
using Biuro_Wycieczek.Models;

namespace Biuro_Wycieczek.Repository
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

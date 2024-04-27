using System.Collections.Generic;
using Biuro_Wycieczek.Models;
using Biuro_Wycieczek.Repository;


namespace Biuro_Wycieczek.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public int GetTotalNumberOfClients()
        {
            var clients = _clientRepository.GetAllClients();
            return clients.Count();
        }

        public IEnumerable<Client> GetClientsPerPage(int page, int pageSize)
        {
            var allClients = _clientRepository.GetAllClients();
            return allClients.Skip((page - 1) * pageSize).Take(pageSize);
        }
        public ClientService(IClientRepository klientRepository)
        {
            _clientRepository = klientRepository;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _clientRepository.GetAllClients();
        }

        public Client GetClientById(int IdKlienta)
        {
            return _clientRepository.GetClientsById(IdKlienta);
        }

        public void InsertClient(Client model)
        {
            _clientRepository.InsertClient(model);
        }

        public void UpdateClient(Client model)
        {
            _clientRepository.UpdateClient(model);
        }

        public void DeleteClient(int IdKlienta)
        {
            _clientRepository.DeleteClient(IdKlienta);
        }

        public void Save()
        {
            _clientRepository.Save();
        }
    }
}

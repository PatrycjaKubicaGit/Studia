using Biuro_Wycieczek.Models;

namespace Biuro_Wycieczek.ViewModelPages
{
    public class ClientViewModelPages
    {
        public IEnumerable<Client> Clients { get; set; }
        public int TotalClients { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

    }

}

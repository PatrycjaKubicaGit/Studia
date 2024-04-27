using AutoMapper;
using Biuro_Wycieczek.Models;
using Biuro_Wycieczek.Services;
using Biuro_Wycieczek.ViewModelPages;
using Biuro_Wycieczek.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Biuro_Wycieczek.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            var clients = _clientService.GetClientsPerPage(page, pageSize);
            var totalClients = _clientService.GetTotalNumberOfClients();
            var clientsModels = _mapper.Map<IEnumerable<Client>>(clients);

            var viewModel = new ClientViewModelPages
            {
                Clients = clientsModels,
                TotalClients = totalClients,
                PageSize = pageSize,
                CurrentPage = page
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult AddClient()
        {
            return View(new ClientViewModel());
        }

        [HttpPost]
        public ActionResult AddClient(ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = _mapper.Map<Client>(model);
                _clientService.InsertClient(client);
                _clientService.Save();
                return RedirectToAction("Index", "Klient");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult EditClient(int ClientId)
        {
            Client client = _clientService.GetClientById(ClientId);
            var model = _mapper.Map<ClientViewModel>(client);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditClient(ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = _mapper.Map<Client>(model);
                _clientService.UpdateClient(client);
                _clientService.Save();
                return RedirectToAction("Index", "Klient");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteClient(int ClientId)
        {
            Client client = _clientService.GetClientById(ClientId);
            var model = _mapper.Map<ClientViewModel>(client);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int ClientId)
        {
            _clientService.DeleteClient(ClientId);
            _clientService.Save();
            return RedirectToAction("Index", "Klient");
        }

    }
}

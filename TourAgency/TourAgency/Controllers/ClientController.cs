using AutoMapper;
using TourAgency.Models;
using TourAgency.Services;
using TourAgency.ViewModelPages;
using TourAgency.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace TourAgency.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AddClient()
        {
            return View(new ClientViewModel());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddClient(ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = _mapper.Map<Client>(model);
                _clientService.InsertClient(client);
                _clientService.Save();
                return RedirectToAction("Index", "Client");
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditClient(int ClientId)
        {
            Client client = _clientService.GetClientById(ClientId);
            var model = _mapper.Map<ClientViewModel>(client);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditClient(ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = _mapper.Map<Client>(model);
                _clientService.UpdateClient(client);
                _clientService.Save();
                return RedirectToAction("Index", "Client");
            }
            else
            {
                return View(model);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult DeleteClient(int ClientId)
        {
            Client client = _clientService.GetClientById(ClientId);
            var model = _mapper.Map<ClientViewModel>(client);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int ClientId)
        {
            _clientService.DeleteClient(ClientId);
            _clientService.Save();
            return RedirectToAction("Index", "Client");
        }

    }
}

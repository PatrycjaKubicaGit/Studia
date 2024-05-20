using Microsoft.AspNetCore.Mvc;
using TourAgency.Models;
using TourAgency.Services;
using TourAgency.ViewModels;
using TourAgency.ViewModelPages;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace TourAgency.Controllers
{
    
    [Authorize(Roles = "Admin, Manager")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            var reservations = _reservationService.GetReservationPerPage(page, pageSize);
            var totalReservations = _reservationService.GetTotalNumberOfReservations();
            var reservationsModels = _mapper.Map<IEnumerable<Reservation>>(reservations);

            var viewModel = new ReservationsViewModelPages
            {
                Reservations = reservationsModels,
                TotalReservations = totalReservations,
                PageSize = pageSize,
                CurrentPage = page
            };
            ViewBag.Wycieczki = _mapper.Map<IEnumerable<TripViewModel>>(_reservationService.GetTrips() ?? new List<Trips>());
            ViewBag.Klienci = _mapper.Map<IEnumerable<ClientViewModel>>(_reservationService.GetClients() ?? new List<Client>());

            return View(viewModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AddReservation()
        {
            ViewBag.Wycieczki = _mapper.Map<IEnumerable<TripViewModel>>(_reservationService.GetTrips() ?? new List<Trips>());
            ViewBag.Klienci = _mapper.Map<IEnumerable<ClientViewModel>>(_reservationService.GetClients() ?? new List<Client>());
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddReservation(Reservation model)
        {
            if (ModelState.IsValid)
            {
                _reservationService.AddReservation(model);
                return RedirectToAction("Index", "Reservation");
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditReservation(int ReservationId)
        {
            Reservation model = _reservationService.GetReservationById(ReservationId);
            ViewBag.Wycieczki = _mapper.Map<IEnumerable<TripViewModel>>(_reservationService.GetTrips() ?? new List<Trips>());
            ViewBag.Klienci = _mapper.Map<IEnumerable<ClientViewModel>>(_reservationService.GetClients() ?? new List<Client>());
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditReservation(Reservation model)
        {
            if (ModelState.IsValid)
            {
                _reservationService.UpdateReservation(model);
                return RedirectToAction("Index", "Reservation");
            }
            else
            {
                return View(model);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult DeleteReservation(int ReservationId)
        {
            Reservation model = _reservationService.GetReservationById(ReservationId);
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int ReservationId)
        {
            _reservationService.DeleteReservation(ReservationId);
            return RedirectToAction("Index", "Reservation");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Biuro_Wycieczek.Models;
using Biuro_Wycieczek.Services;
using Biuro_Wycieczek.ViewModels;
using Biuro_Wycieczek.ViewModelPages;
using AutoMapper;

namespace Biuro_Wycieczek.Controllers
{
    public class TripController : Controller
    {
        private readonly ITripService _tripService;
        private readonly IMapper _mapper;

        public TripController(ITripService tripService, IMapper mapper)
        {
            _tripService = tripService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            var wycieczki = _tripService.GetTripsPerPage(page, pageSize);
            var totalWycieczki = _tripService.GetTotalNumberOfTrips();
            var wycieczkiModels = _mapper.Map<IEnumerable<Trips>>(wycieczki);

            var viewModel = new TripsViewModelPages
            {
                Trips = wycieczkiModels,
                TotalTrips = totalWycieczki,
                PageSize = pageSize,
                CurrentPage = page
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult AddTrip()
        {
            return View(new TripViewModel());
        }

        [HttpPost]
        public ActionResult AddTrip(TripViewModel model)
        {
            if (ModelState.IsValid)
            {
                var trip = _mapper.Map<Trips>(model);
                _tripService.InsertTrip(trip);
                _tripService.Save();
                return RedirectToAction("Index", "Wycieczka");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult EditTrip(int TripId)
        {
            Trips trip = _tripService.GetTripById(TripId);
            var model = _mapper.Map<TripViewModel>(trip);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditTrip(TripViewModel model)
        {
            if (ModelState.IsValid)
            {
                var trip = _mapper.Map<Trips>(model);
                _tripService.UpdateTrip(trip);
                _tripService.Save();
                return RedirectToAction("Index", "Wycieczka");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteTrip(int TripId)
        {
            Trips wycieczka = _tripService.GetTripById(TripId);
            var model = _mapper.Map<TripViewModel>(wycieczka);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int TripId)
        {
            _tripService.DeleteTrip(TripId);
            _tripService.Save();
            return RedirectToAction("Index", "Wycieczka");
        }
    }
}

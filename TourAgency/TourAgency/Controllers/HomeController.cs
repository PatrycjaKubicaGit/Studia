using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TourAgency.Models;
using TourAgency.ViewModels;
using TourAgency.Services;
using Microsoft.AspNetCore.Authorization;

namespace TourAgency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITripService _tripService;
        private readonly IReservationService _reservationService;
        private readonly IPlaceService _placeService;

        public HomeController(ILogger<HomeController> logger, ITripService tripService, IReservationService reservationService, IPlaceService placeService)
        {
            _logger = logger;
            _tripService = tripService;
            _reservationService = reservationService;
            _placeService = placeService;
        }

        public IActionResult Index()
        {
            
            var trips = _tripService.GetAllTrips();

            
            var tripViewModels = trips.Select(trip =>
            {
                
                var place = _placeService.GetPlaceById(trip.PlacesIdPlaceId);

                return new TripViewModel
                {
                    TripsId = trip.TripsId,
                    Country = trip.Country,
                    Description = trip.Description,
                    DayCount = trip.DayCount,
                    DepatureDate = trip.DepatureDate,
                    Cost = trip.Cost,
                    DepaturePlace = trip.DepaturePlace,
                    FoodModel = trip.FoodModel,
                    Transort = trip.Transort,
                    Place = new PlaceViewModel
                    {
                        PlaceId = place.PlaceId,
                        Name = place.Name,
                        Type = place.Type,
                        DistanceFromSea = place.DistanceFromSea,
                        Pool = place.Pool,
                        Carpark = place.Carpark,
                        City = place.City,
                        Street = place.Street,
                        LocalNumber = place.LocalNumber
                    }
                };
            }).ToList();

            return View(tripViewModels);
        }

        
        
        public IActionResult TripsDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = _tripService.GetTripById(id.Value);
            if (trip == null)
            {
                return NotFound();
            }
            var place = _placeService.GetPlaceById(trip.PlacesIdPlaceId);

            var tripViewModel = new TripViewModel
            {
                TripsId = trip.TripsId,
                Country = trip.Country,
                Description = trip.Description,
                DayCount = trip.DayCount,
                DepatureDate = trip.DepatureDate,
                Cost = trip.Cost,
                DepaturePlace = trip.DepaturePlace,
                FoodModel = trip.FoodModel,
                Transort = trip.Transort,
                Place = new PlaceViewModel
                {
                    PlaceId = place.PlaceId,
                    Name = place.Name,
                    Type = place.Type,
                    DistanceFromSea = place.DistanceFromSea,
                    Pool = place.Pool,
                    Carpark = place.Carpark,
                    City = place.City,
                    Street = place.Street,
                    LocalNumber = place.LocalNumber

                }
            };

            return View(tripViewModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            var trips = _tripService.GetAllTrips().Select(t => new TripViewModel
            {
                TripsId = t.TripsId,
                Country = t.Country,
                Description = t.Description,
                DayCount = t.DayCount,
                DepatureDate = t.DepatureDate,
                Cost = t.Cost,
                DepaturePlace = t.DepaturePlace,
                FoodModel = t.FoodModel,
                Transort = t.Transort,
                
            }).ToList();

            var tripCountsByCountry = trips
                .GroupBy(t => t.Country)
                .Select(group => new { Country = group.Key, Count = group.Count() })
                .ToList();

            ViewBag.TripCountsByCountry = tripCountsByCountry;

            var reservations = _reservationService.GetAllReservations().Select(r => new ReservationViewModel
            {
                ReservationId = r.ReservationId,
                ReservationDate = r.ReservationDate,
                ClientsId = r.ClientsId,
                TripsId = r.TripsId
            }).ToList();

            var reservationCountsByDate = reservations
                .GroupBy(r => r.ReservationDate.Date)
                .Select(group => new { Date = group.Key, Count = group.Count() })
                .OrderBy(x => x.Date)
                .ToList();

            ViewBag.ReservationCountsByDate = reservationCountsByDate;

            var tripDaysAndCosts = trips
                .Select(t => new { t.DayCount, t.Cost })
                .OrderBy(x => x.DayCount)
                .ToList();

            ViewBag.TripDaysAndCosts = tripDaysAndCosts;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

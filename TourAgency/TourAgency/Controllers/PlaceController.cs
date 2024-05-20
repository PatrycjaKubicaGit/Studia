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
    public class PlaceController : Controller
    {
        private readonly IPlaceService _placeService;
        private readonly IMapper _mapper;

        public PlaceController(IPlaceService placeService, IMapper mapper)
        {
            _placeService = placeService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            var places = _placeService.GetPlacesPerPage(page, pageSize);
            var totalPlaces = _placeService.GetTotalNumberOfPlaces();
            var placesModels = _mapper.Map<IEnumerable<Place>>(places);

            var viewModel = new PlaceViewModelPages
            {
                Places = placesModels,
                TotalPlaces = totalPlaces,
                PageSize = pageSize,
                CurrentPage = page
            };

            return View(viewModel);
        }
       
        [HttpGet]
        public ActionResult AddPlace()
        {
            return View(new PlaceViewModel());
        }
        
        [HttpPost]
        public ActionResult AddPlace(PlaceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var place = _mapper.Map<Place>(model);
                _placeService.InsertPlace(place);
                _placeService.Save();
                return RedirectToAction("Index", "MiejscePobytu");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult EditPlace(int PlaceId)
        {
            Place place = _placeService.GetPlaceById(PlaceId);
            var model = _mapper.Map<PlaceViewModel>(place);
            return View(model);
        }
       
        [HttpPost]
        public ActionResult EditPlace(PlaceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var place = _mapper.Map<Place>(model);
                _placeService.UpdatePlace(place);
                _placeService.Save();
                return RedirectToAction("Index", "MiejscePobytu");
            }
            else
            {
                return View(model);
            }
        }
        
        [HttpGet]
        public ActionResult DeletePlace(int PlaceId)
        {
            Place place = _placeService.GetPlaceById(PlaceId);
            var model = _mapper.Map<PlaceViewModel>(place);
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Delete(int PlaceId)
        {
            _placeService.DeletePlace(PlaceId);
            _placeService.Save();
            return RedirectToAction("Index", "MiejscePobytu");
        }
    }
}

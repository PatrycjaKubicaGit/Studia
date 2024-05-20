using Microsoft.AspNetCore.Mvc;
using TourAgency.Models;
using TourAgency.ViewModels;
using TourAgency.ViewModelPages;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace TourAgency.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;
        private readonly IMapper _mapper;

        public GuideController(IGuideService guideService, IMapper mapper)
        {
            _guideService = guideService;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            var guides = _guideService.GetGuidesPerPage(page, pageSize);
            var totalGuides = _guideService.GetTotalNumberOfGuides();
            var guidesModels = _mapper.Map<IEnumerable<Guide>>(guides);

            var viewModel = new GuideViewModelPages
            {
                Guides = guidesModels,
                TotalGuides = totalGuides,
                PageSize = pageSize,
                CurrentPage = page
            };

            return View(viewModel);
        }
        [HttpGet]
        public ActionResult AddGuide()
        {
            return View(new GuideViewModel());
        }

        [HttpPost]
        public ActionResult AddGuide(GuideViewModel model)
        {
            if (ModelState.IsValid)
            {
                var Guide = _mapper.Map<Guide>(model);
                _guideService.InsertGuide(Guide);
                _guideService.Save();
                return RedirectToAction("Index", "Guide");
            }
            return View(model);
        }
        
        [HttpGet]
        public ActionResult EditGuide(int GuideId)
        {
            Guide guide = _guideService.GetGuideById(GuideId);
            var model = _mapper.Map<GuideViewModel>(guide);
            return View(model);
        }
        
        [HttpPost]
        public ActionResult EditGuide(GuideViewModel model)
        {
            if (ModelState.IsValid)
            {
                var guide = _mapper.Map<Guide>(model);
                _guideService.UpdateGuide(guide);
                _guideService.Save();
                return RedirectToAction("Index", "Guide");
            }
            else
            {
                return View(model);
            }
        }
        
        [HttpGet]
        public ActionResult DeleteGuide(int GuideId)
        {
            Guide guide = _guideService.GetGuideById(GuideId);
            var model = _mapper.Map<GuideViewModel>(guide);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int GuideId)
        {
            _guideService.DeleteGuide(GuideId);
            _guideService.Save();
            return RedirectToAction("Index", "Guide");
        }
    }
}

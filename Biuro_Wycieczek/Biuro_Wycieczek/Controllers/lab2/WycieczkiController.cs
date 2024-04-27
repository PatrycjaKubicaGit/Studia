using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Biuro_Wycieczek.Models;
using Biuro_Wycieczek.Repository;

namespace Biuro_Wycieczek.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ITripRepository _wycieczkaRepository;

        public EmployeeController(ITripRepository wycieczkaRepository)
        {
            _wycieczkaRepository = wycieczkaRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _wycieczkaRepository.GetAllTrips();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Trips model)
        {
            if (ModelState.IsValid)
            {
                _wycieczkaRepository.InsertTrip(model);
                _wycieczkaRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditEmployee(int id)
        {
            var model = _wycieczkaRepository.GetTripById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult EditEmployee(Trips model)
        {
            if (ModelState.IsValid)
            {
                _wycieczkaRepository.UpdateTrip(model);
                _wycieczkaRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteEmployee(int id)
        {
            var model = _wycieczkaRepository.GetTripById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteEmployeeConfirmed(int id)
        {
            _wycieczkaRepository.DeleteTrip(id);
            _wycieczkaRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}

using crud_simple.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_simple.Controllers
{
    public class HomeController : Controller
    {
        private IApartmentsRepository repository;

        public HomeController(IApartmentsRepository repo) =>
            this.repository = repo;

        public IActionResult Index()
        {
            return View(repository.Apartments);
        }


        [HttpGet]
        public IActionResult AddApartment()
        {
            //Add default values
            return View("Apartment", new Apartment() { Level=1, NumberOfRooms=1, NumberOfStoreys=5, Price=1000000M, Space=33.00d });
        }

        [HttpGet]
        public IActionResult EditApartment(string id)
        {
            return View("Apartment", repository.Apartments.Where(x => x.ID == id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult SaveApartment(Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(apartment.ID))
                {
                    apartment.ID = Guid.NewGuid().ToString();
                    try
                    {
                        repository.AddApartment(apartment);
                    }
                    catch(Exception err)
                    {
                        ModelState.AddModelError("", err.Message);
                        return View("Apartment", apartment);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    try
                    {
                        repository.EditApartment(apartment);
                    }
                    catch(Exception err)
                    {
                        ModelState.AddModelError("", err.Message);
                        return View("Apartment", apartment);
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                // there is a validation error
                ModelState.AddModelError("", "Error!");
                return View("Apartment", apartment);
            }
        }

        [HttpPost]
        public IActionResult DeleteApartment(string apartmentId)
        {
            try
            {
                var adres = repository.Apartments.Where(x => x.ID == apartmentId).FirstOrDefault().Adres;
                repository.DeleteApartment(repository.Apartments.Where(x => x.ID == apartmentId).FirstOrDefault());
                TempData["messageInfo"] = "Entry (by adres " + adres + ") successfully deleted!";
            }
            catch (Exception err)
            {
                TempData["messageErr"] = err.Message;
            }

            return RedirectToAction("Index", "Home");
        }
    }
}

using crud_ajax.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace crud_ajax.Controllers
{
    public class HomeController : Controller
    {
        private IApartmentsRepository repository;

        public HomeController(IApartmentsRepository repo) =>
            this.repository = repo;

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            return Json(repository.Apartments);
        }

        public IActionResult Add([FromBody]Apartment aObj)
        {
            bool result = false;
            try
            {
                if (aObj == null) return BadRequest("Data entry error! To change the data?");
                
                var apartment = new Apartment()
                {
                    ID = Guid.NewGuid().ToString(),
                    NumberOfRooms = aObj.NumberOfRooms,
                    Space = aObj.Space,
                    Level = aObj.Level,
                    NumberOfStoreys = aObj.NumberOfStoreys,
                    Adres = aObj.Adres,
                    Price = aObj.Price
                };
                repository.AddApartment(apartment);
                result = true;
            }
            catch
            {

            }
            return Json(result);
        }

        public JsonResult Delete(string id)
        {
            bool result = false;
            try
            {
                repository.DeleteApartment(repository.Apartments.Where(x => x.ID == id).FirstOrDefault());
            }
            catch
            {
                
            }
            return Json(result);
        }

        public JsonResult GetbyID(string ID)
        {
            var apartment = repository.Apartments.Where(x => x.ID == ID).FirstOrDefault();
            return Json(apartment);
        }

        public IActionResult Update([FromBody]Apartment aObj)
        {
            bool result = false;
            try
            {
                if (aObj == null) return BadRequest("Data entry error! To change the data?");

                if (!string.IsNullOrEmpty(aObj.ID)) repository.EditApartment(aObj);
                result = true;
            }
            catch
            {

            }
            return Json(result);
        }
    }
}

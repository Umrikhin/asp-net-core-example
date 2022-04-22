using crud_single.Models;
using crud_single.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_single.Controllers
{
    public class HomeController : Controller
    {
        private ILands _lands;
        public HomeController(ILands lands)
        {
            _lands = lands;
        }
        public IActionResult Index(int rowUpdate = 0)
        {
            ViewBag.RowUpdate = rowUpdate;
            return View(_lands.lands.OrderByDescending(x => x.Id).ToList());
        }
        [HttpPost]
        public IActionResult EditLand(string NameLandForRow, string PopulationLandForRow, int saveId = 0)
        {
            if (saveId > 0)
            {
                try
                {
                    int populationLandForRow = 0;
                    if (!int.TryParse(PopulationLandForRow, out populationLandForRow))
                    {
                        throw new Exception("Incorrect expression for Population");
                    }
                    _lands.EditCountry(new Country() { Id = saveId, CountryName = NameLandForRow, Population = populationLandForRow });
                }
                catch (Exception err)
                {
                    ModelState.AddModelError("", err.Message);
                    ViewBag.RowUpdate = saveId;
                    return View("Index", _lands.lands.OrderByDescending(x => x.Id).ToList());
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.RowUpdate = saveId;
                ModelState.AddModelError("", "Select an entry to save the change.");
            }
            return View("Index", _lands.lands.OrderByDescending(x => x.Id).ToList());
        }
        [HttpPost]
        public IActionResult DeleteLand(int deleteId = 0, int saveId = 0)
        {
            try
            {
                var land = _lands.lands.Where(x => x.Id == deleteId).FirstOrDefault();
                if (land != null)
                {
                    _lands.DeleteCountry(land);
                    TempData["messageDelInfo"] = "Recording by " + land.CountryName + " deleted successfully!";
                }
            }
            catch (Exception err)
            {
                TempData["messageDelErr"] = err.Message;
            }
            return saveId == 0 | deleteId == saveId ? RedirectToAction("Index", "Home") : RedirectToAction("Index", "Home", new { rowUpdate = saveId });
        }
        [HttpPost]
        public IActionResult CancelUpdateLand()
        {
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult UpdateLand(int updateId = 0)
        {
            return RedirectToAction("Index", "Home", new { rowUpdate = updateId });
        }
        [HttpPost]
        public IActionResult AddLand(string NameLand, string PopulationLand)
        {
            if (!string.IsNullOrEmpty(NameLand))
            {
                try
                {
                    int populationLand = 0;
                    if (!int.TryParse(PopulationLand, out populationLand))
                    {
                        throw new Exception("Incorrect expression for Population");
                    }
                    _lands.AddCountry(new Country() { Id = 0, CountryName = NameLand, Population = populationLand });
                }
                catch (Exception err)
                {
                    ModelState.AddModelError("", err.Message);
                    return View("Index", _lands.lands.OrderByDescending(x => x.Id).ToList());
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Enter country name.");
            }
            return View("Index", _lands.lands.OrderByDescending(x => x.Id).ToList());
        }
    }
}

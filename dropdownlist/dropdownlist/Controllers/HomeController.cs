using dropdownlist.Infrastructure;
using dropdownlist.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dropdownlist.Controllers
{
    public class HomeController: Controller
    {
        public IActionResult Index(int idLand = 0)
        {
            ViewBag.Land = GetCountryForSelect();
            List<City> citys = Utils.GetCitys();
            if (idLand > 0) citys = citys.Where(x => x.idLand == idLand).ToList();
            return View(new ViewLand() { idLand = idLand, citys = citys });
        }

        Microsoft.AspNetCore.Mvc.Rendering.SelectList GetCountryForSelect()
        {
            var lands = Utils.GetLands();
            lands.Add(new Land() { id = 0, nm = "All countries" });
            return new Microsoft.AspNetCore.Mvc.Rendering.SelectList(lands.OrderBy(x => x.id), "id", "nm");
        }

        [HttpPost]
        public IActionResult Select(int Country)
        {
            return RedirectToAction("Index", "Home", new { idLand = Country });
        }
    }
}

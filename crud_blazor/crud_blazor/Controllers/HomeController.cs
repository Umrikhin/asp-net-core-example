using Microsoft.AspNetCore.Mvc;
using crud_blazor.Infractructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_blazor.Controllers
{
    public class HomeController : Controller
    {
        private IPerson _person;
        public HomeController(IPerson person)
        {
            _person = person;
        }

        public IActionResult Index()
        {
            //var model = _person.Get(string.Empty);
            return View();
        }
    }
}

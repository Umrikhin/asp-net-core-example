using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using table_group.Models;

namespace table_group.Controllers
{
    public class HomeController : Controller
    {
        private IOfficesRepository repositoryOffice;

        public HomeController(IOfficesRepository offices)
        {
            this.repositoryOffice = offices;
        }

        public IActionResult Index()
        {
            return View(repositoryOffice.Offices);
        }
    }
}

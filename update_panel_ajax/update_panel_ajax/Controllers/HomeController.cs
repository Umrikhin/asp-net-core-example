using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using update_panel_ajax.Models;
using System.Diagnostics;

namespace table_sort.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendData(Person person)
        {
            System.Threading.Thread.Sleep(5000);
            if (person.TestError > 0)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            }
            return Json(person);
        }
    }
}

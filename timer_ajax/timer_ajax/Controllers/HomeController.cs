using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using timer_ajax.Models;
using System.Linq;
using System.Collections.Generic;

namespace timer_ajax.Controllers
{
    public class HomeController : Controller
    {
        private IAlertsRepository repository;

        public HomeController(IAlertsRepository repo) =>
            this.repository = repo;

        public IActionResult Index()
        {
            return View(new List<Alert>());
        }

        public JsonResult List()
        {
            var result = repository.Alerts;
            var MaxDate = result.Max(x => x.TimeRun);
            if (MaxDate.AddMinutes(1) < DateTime.Now)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return Json("All messages sent!");
            }
            return Json(repository.Alerts);
        }

    }
}

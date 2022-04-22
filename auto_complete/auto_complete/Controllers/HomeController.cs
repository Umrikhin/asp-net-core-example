using auto_complete.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace auto_complete.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Find()
        {
            var name = HttpContext.Request.Query["frarment"].ToString();
            var list_mo = new List<Lpu>() {
            new Lpu(){ CDLPU = "2010101", CDREESTR="610131", Name="Central Regional Hospital of the Azov region" },
            new Lpu(){ CDLPU = "4010101", CDREESTR="610046", Name="GB 1 named after Semashko, Rostov-n-Donu" },
            new Lpu(){ CDLPU = "4040101", CDREESTR="610001", Name="MBUZ Central City Hospital of Azov" },
            new Lpu(){ CDLPU = "4090101", CDREESTR="610007", Name="Central Regional Hospital of the Belokalitvensky District" },
            new Lpu(){ CDLPU = "4070101", CDREESTR="610005", Name="Central City Hospital Bataysk" },
            new Lpu(){ CDLPU = "4270101", CDREESTR="610031", Name="GB 1 Novocherkassk" },
        };
            var data = list_mo.Where(x => x.Name.ToLower().Contains(name.ToLower())).Select(x => x.Name).ToList();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            //your search logic...
            return RedirectToAction("Index");
        }
    }
}

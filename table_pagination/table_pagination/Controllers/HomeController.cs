using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using table_pagination.Models;

namespace table_pagination.Controllers
{
    public class HomeController : Controller
    {
        public static int PageSize = 5;
        private IPersonsRepository repository;

        public HomeController(IPersonsRepository persons)
        {
            this.repository = persons;
        }

        public IActionResult Index(int? elementPage, int? pageSize)
        {
            if (elementPage == null) elementPage = 1;
            if (pageSize != null) PageSize = pageSize ?? 5;

            var query = repository.Persons;
            PagingInfo p = new PagingInfo()
            {
                CurrentPage = elementPage ?? 1,
                ItemsPerPage = PageSize,
                TotalItems = query.Count()
            };
            ViewBag.PageInfo = p;

            query = query.OrderBy(x => x.ID).Skip((p.CurrentPage - 1) * PageSize).Take(PageSize).ToList();

            return View(query);
        }

    }
}

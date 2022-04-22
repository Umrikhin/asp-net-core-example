using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using table_sort.Models;

namespace table_sort.Controllers
{
    public class HomeController : Controller
    {
        private IPersonsRepository repository;

        public HomeController(IPersonsRepository persons)
        {
            this.repository = persons;
        }

        public IActionResult Index(string sort)
        {
            string new_sort = string.Empty;
            bool IsSort = false;

            if (!string.IsNullOrEmpty(sort))
            {
                List<Person> result = new List<Person>();

                if (sort == "first_name_desc")
                {
                    result = repository.Persons.OrderByDescending(x => x.FirstName).ToList();
                    new_sort = string.Empty;
                    IsSort = true;
                }
                if (sort == "first_name")
                {
                    result = repository.Persons.OrderBy(x => x.FirstName).ToList();
                    new_sort = "_desc";
                    IsSort = true;
                }

                if (sort == "last_name_desc")
                {
                    result = repository.Persons.OrderByDescending(x => x.LastName).ToList();
                    new_sort = string.Empty;
                    IsSort = true;
                }
                if (sort == "last_name")
                {
                    result = repository.Persons.OrderBy(x => x.LastName).ToList();
                    new_sort = "_desc";
                    IsSort = true;
                }

                if (sort == "bithday_desc")
                {
                    result = repository.Persons.OrderByDescending(x => x.DateOfBirth).ToList();
                    new_sort = string.Empty;
                    IsSort = true;
                }
                if (sort == "bithday")
                {
                    result = repository.Persons.OrderBy(x => x.DateOfBirth).ToList();
                    new_sort = "_desc";
                    IsSort = true;
                }

                if (sort == "country_desc")
                {
                    result = repository.Persons.OrderByDescending(x => x.Country).ToList();
                    new_sort = string.Empty;
                    IsSort = true;
                }
                if (sort == "country")
                {
                    result = repository.Persons.OrderBy(x => x.Country).ToList();
                    new_sort = "_desc";
                    IsSort = true;
                }

                if (sort == "driving_experience_desc")
                {
                    result = repository.Persons.OrderByDescending(x => x.DrivingExperience).ToList();
                    new_sort = string.Empty;
                    IsSort = true;
                }
                if (sort == "driving_experience")
                {
                    result = repository.Persons.OrderBy(x => x.DrivingExperience).ToList();
                    new_sort = "_desc";
                    IsSort = true;
                }

                if (IsSort)
                {
                    ViewBag.NewSort = new_sort;
                    ViewBag.Sort = sort.IndexOf("_desc") > 0 ? sort : sort + "_asc";
                    return View(result);
                }
                else
                {
                    View(repository.Persons);
                }
            }

            return View(repository.Persons);
        }

    }
}

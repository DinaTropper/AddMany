using AddMany.Data;
using AddMany.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AddMany.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=People;Integrated Security=true;";

        public IActionResult Index()
        {
            PeopleDb db = new(_connectionString);
            PeopleViewModel vm = new();
            vm.People = db.GetPeople();
            if (TempData["message"] != null)
            {
                vm.Message = (string)TempData["message"];
            }
            return View(vm);
        }
        public IActionResult ShowAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(List<Person> p)
        {
            PeopleDb db = new(_connectionString);
            var pplToAdd = p.Where(p => !String.IsNullOrEmpty(p.FirstName) && !String.IsNullOrEmpty(p.LastName) && !String.IsNullOrEmpty(p.Age.ToString())).ToList();
            db.AddMany(pplToAdd);

            if (pplToAdd.Count > 0)
            {
                TempData["message"] = $"{pplToAdd.Count} added successfully!";
            }
            else
            {
                TempData["message"] = "Unsuccessful in adding people...";

            }

            return Redirect("/home/Index");

        }
    }
}
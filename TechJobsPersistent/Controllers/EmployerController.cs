using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        private JobDbContext context;

        
        // GET: /<controller>/
        public IActionResult Index()
        {

            List<Employer> employers = context.Employers.ToList();
            return View(employers);

        }

        public IActionResult Add(AddEmployerViewModel addEmployerViewModel)
        {
            Employer employer = new Employer(addEmployerViewModel.Name, addEmployerViewModel.Location)
            {
                Name = addEmployerViewModel.Name,
                Location = addEmployerViewModel.Location
            };
            return View(employer);

        }


        [HttpPost]
        public IActionResult ProcessAddEmployerForm(Employer employer)
        {


            if (ModelState.IsValid)
            {
                context.Employers.Add(employer);
                context.SaveChanges();
                return Redirect("/Employer/");
            }

            return View("Add", employer);
        }






/*
        [HttpPost]
        public IActionResult Add(AddEmployerViewModel addEmployerViewModel)
        {

            if (ModelState.IsValid == false)
                return View(addEmployerViewModel);

            context.Employers.Add(addEmployerViewModel.Employer);
            context.SaveChanges();
            return Redirect("Index");

        }
*/

        public IActionResult About(int id)
        {
            Employer employer = context.Employers.SingleOrDefault(e => e.Id == id);

            if (employer == null)
                return Redirect("Index");


            return View(employer);

        }


        
    }
}

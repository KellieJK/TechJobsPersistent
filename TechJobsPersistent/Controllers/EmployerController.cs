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


            //if (ModelState.IsValid)
            //{


            //    List<Employer> existingItems = context.Employer
            //        .Where(js => js.AddEmployerViewModel.Name == AddEmployerViewModel.Name)
            //        .Where(js => js.EmployerId == EmployerId)
            //        .ToList();

            //    if (existingItems.Count == 0)
            //    {
            //        Employer employer = new Employer
            //        {
            //            Name = Name,
            //            Location = Location
            //        };
            //        context.Employer.Add(Name);
            //        context.SaveChanges();
            //    }

            //    return Redirect("/Home/Detail/" + jobId);
            //}

            //return View(viewModel);






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



        public IActionResult About()
        {


            List<Employer> employer = context.Employers
                .Include(j => j.Name)
                .Include(j => j.Location)
                .ToList();

            return View(employer);





        }
    }
}

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

        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employer> employers = context.Employers.ToList();
            return View(employers);
        }

        public IActionResult Add()
        {
            /*Employer employer = new Employer(addEmployerViewModel.Name, addEmployerViewModel.Location)
            {
                Name = addEmployerViewModel.Name,
                Location = addEmployerViewModel.Location
            };*/

            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();

            return View(addEmployerViewModel);

        }


/*
        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
            {
                Employer newEmployer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };

                context.Employers.Add(newEmployer);
                context.SaveChanges();
                return Redirect("/Employer");

            }
            return View("Add", addEmployerViewModel);
        }
*/


  [HttpPost]
       public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
           {

        if (ModelState.IsValid == true)
                  // return View(addEmployerViewModel);

        context.Employers.Add(addEmployerViewModel.ToEmployer());
         context.SaveChanges();
          return Redirect("/Employer");
         
         }






        public IActionResult About(int id)
        {
            /*Employer employer = context.Employers.SingleOrDefault(e => e.Id == id);

            if (employer == null)
                return Redirect("Index");
            else
*/
            Employer employer = context.Employers.Find(id);
                 return View(employer);
        }
        
    }
}

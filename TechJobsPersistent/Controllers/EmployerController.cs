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

        public IActionResult Add()
        {
            Employer employer = new Employer();
            return View(employer);

            
        }

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

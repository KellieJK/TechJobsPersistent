using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistent.Controllers
{
    public class HomeController : Controller
    {
        private JobDbContext context;

        public HomeController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();
            

            return View(jobs);
        }

        [HttpGet("/Add")]
        public IActionResult AddJob()
        {
            List<Employer> allEmployers = context.Employers.ToList();
            ViewBag.allEmployers = allEmployers;

            List<Skill> JobSkills = context.Skills.ToList();
            ViewBag.jobSkills = JobSkills;

            return View();
        }

  

        [HttpPost("/Add")]
        public IActionResult ProcessAddJobForm(SkillsList addJobViewModel, string[] selectedSkills)
        {
            if (ModelState.IsValid)
            {
               Job newJob = new Job(addJobViewModel.Name, addJobViewModel.EmployerId) 
                {
                   Name = addJobViewModel.Name,
                   EmployerId = addJobViewModel.EmployerId,
                   JobSkills = new List<JobSkill>()
                };
                foreach (string skill in selectedSkills)
                {
                    JobSkill newJobSkill = new JobSkill
                    {
                        JobId = newJob.Id,
                        SkillId = int.Parse(skill)
                    };
                    newJob.JobSkills.Add(newJobSkill);
                    context.Add(newJobSkill);
                }
                context.Jobs.Add(newJob);
                context.SaveChanges();
                return Redirect("/Home");
            }
            return View("Add", addJobViewModel);
        }




        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs
                .Include(j => j.Employer)
                .Single(j => j.Id == id);

            List<JobSkill> jobSkills = context.Employer
                .Where(js => js.JobId == id)
                .Include(js => js.Skill)
                .ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }
    }
}
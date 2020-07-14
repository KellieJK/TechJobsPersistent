﻿using System;
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
            return View();
        }

        //this is where I added the AddJobViewModel instance-----------

        public IActionResult AddJob(AddJobViewModel viewModel)
        {
            AddJobViewModel inst1 = new AddJobViewModel();

            return View(inst1);
        }


        //-------------------------------------------------------------


        public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel, string[] selectedSkills)
        {
            if (ModelState.IsValid)
            {
                Job newJob = new Job
                {
                    Name = addJobViewModel.Name,
                    EmployerId = int.Parse(addJobViewModel.EmployerId),
                };
                int newJobId = int.Parse(addJobViewModel.EmployerId);
                foreach (string skill in selectedSkills)
                {
                    JobSkill newJobSkill = new JobSkill
                    {
                        JobId = newJobId,
                        SkillId = int.Parse(skill)
                    };
                    context.JobSkills.Add(newJobSkill);
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

            List<JobSkill> jobSkills = context.JobSkills
                .Where(js => js.JobId == id)
                .Include(js => js.Skill)
                .ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }
    }
}
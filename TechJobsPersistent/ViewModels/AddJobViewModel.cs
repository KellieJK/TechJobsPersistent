using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        public string Name { get; set; }
        public int EmployerId { get; set; }

        public List<int> SkillId { get; set; } 

        public List<Skill> Skills { get; set; } 

        public List<SelectListItem> Employers { get; set; } 

        public Job ToJob() => new Job(Name, EmployerId);

        public AddJobViewModel(List<Employer> employers, List<Skill>skills)
        {
            Employers = new List<SelectListItem>();
            foreach (var employer in employers)
            {
                Employers.Add(new SelectListItem
                {
                    Value = employer.Id.ToString(),
                    Text = employer.Name
                });

                Skills = skills;

            }      
                    
                    
                /*    (employer.Name, employer.Id.ToString()));
            foreach (Skill skill in skills)
                Skills.Add(skill);*/
        }




        public AddJobViewModel()
        {

        }

    }
}

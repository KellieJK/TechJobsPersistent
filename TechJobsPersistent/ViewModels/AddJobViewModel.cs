using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class SkillsList
    {
        public string Name { get; set; }
        public int EmployerId { get; set; }

        public List<int> SkillId { get; set; }

        public List<SelectListItem> Skills { get; set; }

        public SkillsList(List<Skill> skills) { get; set; }



    }
}

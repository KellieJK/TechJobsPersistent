﻿using Microsoft.AspNetCore.Mvc.Rendering;
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

        public List<int> SkillId { get; set; } = new List<int>();

        public List<Skill> Skills { get; set; } = new List<Skill>();

        public List<SelectListItem> Employers { get; set; } = new List<SelectListItem>();




        public List<Skill> skills = new List<Skill>();

    }
}

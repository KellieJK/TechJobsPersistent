using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddEmployerViewModel
    {
       

        [Required]
        public string Name { get; set; }
        
        public string Location { get; set; }

        public Employer ToEmployer()
        {
            return new Employer(Name, Location);
        }

         public AddEmployerViewModel(string name, string location)
         {
            Name = name;
            Location = location;
         }


        public AddEmployerViewModel()
        { 

        }
    }
 
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechJobsPersistent.Models
{
    public class Employer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public Employer()
        {
        }

        public Employer(string name, string location)
        {
            Name = name;
            Location = location;
        }

        internal static object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        internal static List<Employer> ToList()
        {
            throw new NotImplementedException();
        }
    }
}

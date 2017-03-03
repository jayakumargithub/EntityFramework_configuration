using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace My.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

      
        //public string FullName
        //{
        //    get { return FirstName + " " + LastName; }
        //}
    }

    public class Manager : Employee
    { public string SectionManaged { get; set; }
    }
}

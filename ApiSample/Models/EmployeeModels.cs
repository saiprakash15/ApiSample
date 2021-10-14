using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSample.Models
{
    public class EmployeeModels
    {
        public int BusinessEntityID { get; set; } 
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string  OrganizationNode { get; set; }
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }

    }
}

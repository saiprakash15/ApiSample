using ApiSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSample.Repository
{
    public interface IEmployeeRepository
    {
        public IEnumerable<EmployeeModels> GetManagerDetails(int BusinessID);
        

    }
}

using ApiSample.Models;
using ApiSample.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSample.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _repo;
        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        //[Route("Details")]
        public IEnumerable<EmployeeModels> GetDetails( int ID)
        {
            return _repo.GetManagerDetails(ID);
        }

        [HttpGet]
        public string test( )
        {
            return "Hello ";
        }
    }
}

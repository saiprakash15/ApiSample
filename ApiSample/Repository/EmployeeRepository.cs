using ApiSample.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSample.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IConfiguration Configuration { get; }
        private string _ConnectionString;
        private readonly ILogger<EmployeeRepository> logger;

        public EmployeeRepository(IConfiguration _config,ILogger<EmployeeRepository> _logger)
        {
            Configuration = _config;
            _ConnectionString = Configuration["ConnectionStrings:DefaultConnection"];
            logger = _logger;
        }
        public IEnumerable<EmployeeModels> GetManagerDetails(int BusinessID)
        {
            List<EmployeeModels> customers = new List<EmployeeModels>();
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[uspGetManagerEmployees]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BusinessEntityID", BusinessID);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        EmployeeModels customer = new EmployeeModels();
                        customer.BusinessEntityID= Convert.ToInt32(rdr["BusinessEntityID"]);
                        customer.FirstName = rdr["FirstName"].ToString();
                        customer.LastName = rdr["LastName"].ToString();
                        customer.ManagerFirstName = rdr["ManagerFirstName"].ToString();
                        customer.ManagerLastName = rdr["ManagerLastName"].ToString();
                        customers.Add(customer);

                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    //ex.Message.ToString();
                    logger.LogError(ex, "Error at GetAllCustomers() :(");
                    customers = null;
                }
            }
            return customers;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API_capacitacion.Contexts;
using API_capacitacion.Entities;
using CalculatorSOAP;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_capacitacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IConfiguration configuration;
        private readonly AppDbContext context;

        public CustomerController(AppDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            string query = "SELECT * FROM Customer where id=2;";
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var customerDetails = connection.Query<Customer>(query).ToList();

                Console.WriteLine(customerDetails.Count);
                return (customerDetails);
            }
            // return context.Customer.ToList();
        }
        //GET: api/checkInfo
        [HttpGet]
        [Route("/api/checkInfo")]
        public bool CheckInfo([FromBody]LoginData data)
        {
           var listCustomers= context.Customer.ToList();
            foreach (Customer customer in listCustomers)
            {
                if (customer.UserName == data.UserName && customer.Password == data.Password)
                {
                    Console.WriteLine("los datos coinciden");
                    return (true);
                }
            }
            return (false);
        }
        [HttpGet]
        [Route("/api/calculator/add")]
        public int CalculatorAdd([FromBody]Numbers nums)
        {
            var clientCalculator = new CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap12);
            int result = clientCalculator.Add(nums.num1, nums.num2);
            return result;
        }




        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            var findCustomer = context.Customer.FirstOrDefault(c=>c.Id==id);
            return findCustomer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

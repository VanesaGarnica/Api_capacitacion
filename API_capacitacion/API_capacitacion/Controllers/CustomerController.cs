using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API_capacitacion.Contexts;
using API_capacitacion.Entities;
using CalculatorSOAP;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_capacitacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext context;

        public CustomerController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return context.Customer.ToList();
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

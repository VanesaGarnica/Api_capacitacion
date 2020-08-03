using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API_capacitacion.Contexts;
using API_capacitacion.DAO;
using API_capacitacion.Entities;
using Microsoft.AspNetCore.Mvc;
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
            List<Customer> customers = CustomerDAO.Get();
            return customers;
            // return context.Customer.ToList();
        }

        //POST: api/checkInfo
        [HttpPost]
        [Route("/api/checkInfo")]
        public bool CheckInfo([FromBody]LoginData data)
        {
            var listCustomers = CustomerDAO.Get();
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

        //POST api/calculator/add
        [HttpPost]
        [Route("/api/calculator/add")]
        public int CalculatorAdd([FromBody]Numbers nums)
        {
            int result = CalculatorDAO.CalculatorAdd(nums.num1, nums.num2);
            return result;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            var customers = CustomerDAO.Get();
            foreach(var customer in customers)
            {
                if(customer.Id == id)
                {
                    return customer;
                }
            }
            return default;
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

﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API_capacitacion.Contexts;
using API_capacitacion.Entities;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_capacitacion.DAO
{
    public class CustomerDAO
    {
        private static IConfiguration dbConfiguration;
        private static AppDbContext dbContext;
        private static readonly string dbConnectionString = "Data Source=.; Initial Catalog=DbApi; Integrated Security=true";

        public CustomerDAO(AppDbContext context, IConfiguration configuration)
        {
            dbContext = context;
            dbConfiguration = configuration;
        }

        //este metodo devuelve la lista completa de customers
        public static List<Customer> Get()
        {
            string query = "SELECT * FROM Customer;";
            Debug.WriteLine("the saved connection string is " + dbConnectionString);
            using (var connection = new SqlConnection(dbConnectionString))
            {
                Debug.WriteLine("the connection string int the connection is " + connection.ConnectionString);
                var customerDetails = connection.Query<Customer>(query).ToList();

                return (customerDetails);
            }
        }
        

        //aca iria el metodo que agrega un nuevo customer
        public void Post(Customer customer)
        {

        }

        //aca iria el metodo que modificaría un customer
        public void Put(int id, Customer customer)
        {
        }
        
        //aca iria el metodo que elimina un customer
        public void Delete(int id)
        {
        }
    }
}

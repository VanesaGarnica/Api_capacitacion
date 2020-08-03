using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API_capacitacion.Contexts;
using API_capacitacion.Entities;
using CalculatorSOAP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API_capacitacion.DAO
{
    public class CalculatorDAO 
    {
        //este metodo usa un servicio SOAP publico para sumar dos numeros
        public static int CalculatorAdd(int num1, int num2)
        {
            var clientCalculator = new CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap12);
            int result = clientCalculator.Add(num1, num2);
            return result;
        }

    }
}

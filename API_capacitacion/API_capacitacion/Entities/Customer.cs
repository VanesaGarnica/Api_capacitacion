using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_capacitacion.Entities
{
    public class Customer
    {   
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
    }

    public class LoginData
    {
        public string UserName { set; get; }
        public string Password { set; get; }
    }
    public class Numbers
    {
        public int num1 { set; get; }
        public int num2 { set; get; }
    }
}

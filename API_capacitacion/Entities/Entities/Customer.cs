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
}

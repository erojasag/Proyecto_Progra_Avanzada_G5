using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Entities
{
    public class Respuesta
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool transaccion { get; set; }
        public Customer customer { get; set; }
        public List<Customer> customers { get; set; }

        public Product product { get; set; }
        public List<Product> products { get; set; }

        public Employee employee { get; set; }

        public List<Employee> employees { get; set; }

    }
}
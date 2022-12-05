using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion.Entities
{
    public class Shipments
    {

        public int Id { get; set; }
        public int Order_Id { get; set; }
        public DateTime Date { get; set; }
        public string status { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip_code { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid Customer_id { get; set; }

    }
}
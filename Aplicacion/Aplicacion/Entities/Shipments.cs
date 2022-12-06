using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion.Entities
{
    public class Shipments
    {

        public int shipment_id { get; set; }
        public int shipment_order_id { get; set; }
        public System.DateTime shipment_date { get; set; }
        public string shipment_status { get; set; }
        public string shipment_address { get; set; }
        public string shipment_city { get; set; }
        public string shipment_state { get; set; }
        public string shipment_zip_code { get; set; }
        public string shipment_country { get; set; }
        public string shipment_phone { get; set; }
        public string shipment_email { get; set; }
        public System.Guid shipment_customer_id { get; set; }

        public virtual Orders Orders { get; set; }
        public virtual Users Users { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion.Entities
{
    public class Product_By_Order
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public int Order_Id { get; set; }

        public virtual Orders Orders { get; set; }
        public virtual Products Products { get; set; }
    }
}
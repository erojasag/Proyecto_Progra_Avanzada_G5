using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int User_Id { get; set; }
        public int Product_Id { get; set; }

        public virtual Product Products { get; set; }
        public virtual Users Users { get; set; }
    }
}
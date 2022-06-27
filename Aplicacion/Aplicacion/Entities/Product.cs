using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion.Entities
{
    public class Product
    {
        public Product()
        {
            this.Product_By_Order = new HashSet<Product_By_Order>();
            this.ShoppingCart = new HashSet<ShoppingCart>();
        }

        public int Id { get; set; }
        public Nullable<int> Brand_Id { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string shoeSize { get; set; }
        public string Photo { get; set; }
        public System.DateTime Registration_date { get; set; }
        public Nullable<System.DateTime> Modification_date { get; set; }

        public virtual Brand Brand { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_By_Order> Product_By_Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
    }
}
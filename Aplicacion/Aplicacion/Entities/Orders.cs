using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion.Entities
{
    public class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            this.Product_By_Order = new HashSet<Product_By_Order>();
        }

        public int Id { get; set; }
        public int Order_User_Id { get; set; }
        public byte[] Order_date { get; set; }
        public decimal Order_total { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_By_Order> Product_By_Order { get; set; }
        public virtual Users Users { get; set; }
    }
}
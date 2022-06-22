using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion.Entities
{
    public class Users
    {
        public Users()
        {
            this.Orders = new HashSet<Orders>();
            this.Persons = new HashSet<Persons>();
            this.ShoppingCart = new HashSet<ShoppingCart>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string User_type { get; set; }
        public string Photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Persons> Persons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
    }
}
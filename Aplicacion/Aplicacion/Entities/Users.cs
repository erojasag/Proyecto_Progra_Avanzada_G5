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
            this.ShoppingCart = new HashSet<ShoppingCart>();
        }

        public Guid Id { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public string First_last_name { get; set; }
        public string Second_last_name { get; set; }
        public int User_Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public System.DateTime Birth_date { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public System.DateTime Registration_date { get; set; }
        public string Photo { get; set; }
        public Nullable<System.DateTime> Modification_date { get; set; }
        public string Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }

        public string Token { get; set; }
    }
}
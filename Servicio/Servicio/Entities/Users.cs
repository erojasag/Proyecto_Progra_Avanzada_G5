//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servicio.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.Orders = new HashSet<Orders>();
            this.Shipments = new HashSet<Shipments>();
            this.ShoppingCart = new HashSet<ShoppingCart>();
        }
    
        public System.Guid Id { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public string First_last_name { get; set; }
        public string Second_last_name { get; set; }
        public int User_Role { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public string noHashPass { get; set; }
        public System.DateTime Birth_date { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public System.DateTime Registration_date { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<System.DateTime> Modification_date { get; set; }
        public string Address { get; set; }
        public Nullable<bool> Email_Verification { get; set; }
        public Nullable<System.Guid> Activation_Code { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual Roles Roles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipments> Shipments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
    }
}
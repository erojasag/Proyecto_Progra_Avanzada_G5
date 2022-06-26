using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string First_last_name { get; set; }
        public string Second_last_name { get; set; }
        public string Identification { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public System.DateTime Registration_date { get; set; }
        public Nullable<System.DateTime> Modification_date { get; set; }
        public System.DateTime Birth_date { get; set; }
        public string Address { get; set; }
        public int User_Id { get; set; }

        public virtual Users Users { get; set; }
    }
}
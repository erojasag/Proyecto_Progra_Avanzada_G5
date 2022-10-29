using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Entities
{
    public class Usuario
    {

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

}

}
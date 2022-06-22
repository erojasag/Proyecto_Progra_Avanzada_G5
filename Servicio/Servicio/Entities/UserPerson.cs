using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Entities
{
    public class UserPerson
    {
        public Persons Person { get; set; }
        public Users User { get; set; }

    }
}
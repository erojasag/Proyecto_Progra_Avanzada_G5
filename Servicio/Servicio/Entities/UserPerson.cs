using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Entities
{
    public class UserPerson
    {
        public Person Person { get; set; }
        public Users User { get; set; }

        public List<UserPerson> UserPersons { get; set; }

    }
}
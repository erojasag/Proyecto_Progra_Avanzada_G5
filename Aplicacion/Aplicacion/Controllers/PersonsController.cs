using Aplicacion.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Controllers
{
    public class PersonsController : Controller
    {
        public ActionResult viewPersons()
        {
            return null;
        }

        /*public Person ViewPersonById(int Id)
        {
            
        }*/

        public ActionResult ViewPersonsWithUsers()
        {
            return null;
        }
        public ActionResult CheckPersonAndUserById(int Id)
        {
            return null;
        }


        /*public bool InsertPerson(Person Person)
        {
            
        }*/

        public ActionResult InsertPersonWithUser(UserPerson UserPerson)
        {
            return null;
        }

        /*public bool EditPerson(Person Person)
        {
            
        }*/

        //Edit UserPerson
        public ActionResult EditUserPerson(UserPerson UserPerson)
        {
            return null;
        }


        /*public bool DeletePerson(int Id)
        {
            
        }*/

        public ActionResult DeletePersonAndUserById(int Id)
        {
            return null;
        }
    }
}
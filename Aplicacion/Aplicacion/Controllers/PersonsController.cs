using Aplicacion.Entities;
using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Controllers
{
    public class PersonsController : Controller
    {
        PersonsModel model = new PersonsModel();
        public ActionResult viewPersons()
        {
            return null;
        }

        /*public Person ViewPersonById(int Id)
        {
            
        }*/

        [HttpGet]
        [Route("ViewPersonsWithUsers")]
        public ActionResult ViewPersonsWithUsers()
        {
            try
            {
                var datos = model.ViewPersonsWithUsers();
                if (datos != null)
                {
                    return View(datos.UsersPersons);
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            try
            {
                var datos = model.InsertPersonWithUser(UserPerson);
                if (datos != null)
                {
                    return View(datos.UsersPersons);
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
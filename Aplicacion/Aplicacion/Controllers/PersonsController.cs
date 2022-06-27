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

        [HttpGet]
        [Route("CheckPersonAndUserById")]
        public ActionResult CheckPersonAndUserById(int Id)
        {
            try
            {
                var datos = model.CheckPersonAndUserById(Id);
                if (datos != null)
                {
                    return View(datos.UserPerson);
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

        [HttpPost]
        [Route("InsertPersonWithUser")]
        public ActionResult InsertPersonWithUser(UserPerson UserPerson)
        {
            try
            {
                var datos = model.InsertPersonWithUser(UserPerson);
                if (datos != null)
                {
                    return View(datos);
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



        //Edit UserPerson
        public ActionResult EditUserPerson(UserPerson UserPerson)
        {
            try
            {
                var datos = model.EditUserPerson(UserPerson);
                if (datos != null)
                {
                    return View(datos.UserPerson);
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



        public ActionResult DeletePersonAndUserById(int Id)
        {
            try
            {
                var datos = model.DeletePersonAndUserById(Id);
                if (datos != null)
                {
                    return View(datos.User.Id);
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


    }
}
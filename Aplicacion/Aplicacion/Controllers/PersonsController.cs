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
                if(UserPerson.User.User_Role == 0)
                {
                    UserPerson.User.User_Role = 2;
                }
                var datos = model.InsertPersonWithUser(UserPerson);
                if (datos != null)
                {
                    return View("ThankYou");
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
        [Route("EditUserPerson")]
        public ActionResult EditUserPerson(int? Id)
        {
            try
            {
                var data = model.CheckPersonAndUserById((int)Id);

                if(data != null)
                {
                    return View(data.UsersPersons);
                }
                else
                {
                    return View("Error");
                }
            }
            catch(Exception ex)
            {
                return View("Error");
                throw ex;
            }
        }

        [HttpPost]
        [Route("EditUserPerson")]
        //Edit UserPerson
        public ActionResult EditUserPerson(UserPerson UserPerson)
        {
            try
            {
                var datos = model.CheckPersonAndUserById((int)UserPerson.Person.Id);

                if (datos != null)
                {
                    model.EditUserPerson(UserPerson);
                    return View();
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
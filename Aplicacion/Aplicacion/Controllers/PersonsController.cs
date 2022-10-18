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

        [SessionFilter]
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

        [SessionFilter]
        [HttpPost]
        [Route("EditUserPerson")]
        //Edit UserPerson
        public ActionResult EditUserPerson(UserPerson UserPerson)
        {
            try
            {
                var datos = model.CheckPersonAndUserById((int)UserPerson.Person.Id);
                datos.Person.Name = UserPerson.Person.Name;
                datos.Person.First_last_name = UserPerson.Person.First_last_name;
                datos.Person.Second_last_name = UserPerson.Person.Second_last_name;
                datos.Person.Identification = UserPerson.Person.Identification;
                datos.Person.Phone = UserPerson.Person.Phone;
                datos.Person.Email  = UserPerson.Person.Email;
                datos.Person.Address = UserPerson.Person.Address;
                datos.User.Username = UserPerson.User.Username;
                datos.User.Password = UserPerson.User.Password;


                if (datos.Transaction == true)
                {
                    model.EditUserPerson(UserPerson);
                    ViewBag.Mensaje = "User edited succesfully";
                    return View();
                }
                else
                {
                    ViewBag.Mensaje = "Product not edited";
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("CheckPersonById")]
        public ActionResult CheckPersonById(int Id)
        {
            try
            {
                var datos = model.CheckPersonById(Id);

                if(datos != null)
                {
                    return View(datos.Person);
                }
                else
                {
                    return View("Error");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [SessionFilter]
        [HttpGet]
        [Route("DeletePersonAndUserById")]
        public ActionResult DeletePersonAndUserById(int? Id)
        {
            try
            {
                var datos = model.DeletePersonAndUserById((int)Id);
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
                return View("Error");
                throw ex;
            }
        }


    }
}
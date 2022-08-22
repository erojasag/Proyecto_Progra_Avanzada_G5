using Aplicacion.Entities;
using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Controllers
{
    public class LogInController : Controller
    {
        readonly UsersModel model = new UsersModel();
        readonly PersonsModel pmodel = new PersonsModel();

        [HttpGet]
        public ActionResult UserLogIn(Users User)
        {
            return View(new Users());
        }

        [HttpGet]
        public ActionResult UserRegistration(UserPerson UserPerson)
        {
            return View(new UserPerson());
        }

        [HttpPost]
        public ActionResult ValidateUser(Users User)
        {

            if (User.Password != null && User.Username != null)
            {
                var datos = model.ValidateUser(User);
                //var getPerson = pmodel.CheckPersonById(datos.Id);

                if (datos.Id != -1)
                {
                    var username = datos.User.Username;
                    var role = datos.User.User_Role;
                    var photo = datos.User.Photo;
                    var Id = datos.User.Id;

                    if (datos != null)
                    {
                        Session["Username"] = username;
                        Session["User_Role"] = role;
                        Session["Photo"] = photo;
                        Session["Id"] = Id;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ViewBag.Mensaje = "User or Password Incorrect, please try again";
            return View("UserLogIn");
        }

        [SessionFilter]
        [HttpGet]
        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }
    }
}
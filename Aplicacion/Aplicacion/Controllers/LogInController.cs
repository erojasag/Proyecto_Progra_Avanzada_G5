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
        UsersModel model = new UsersModel();

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

            if (User.Password != null)
            {
                var datos = model.ValidateUser(User);

                if (datos != null)
                {

                    Session["Username"] = datos.User.Username;
                    Session["User_Role"] = datos.User.User_Role;
                    Session["Photo"] = datos.User.Photo;
                    return RedirectToAction("Index", "Home");
                }

            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }
    }
}
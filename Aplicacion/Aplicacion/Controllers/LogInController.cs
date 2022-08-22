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
            ViewBag.Mensaje = string.Empty;

            if (User.Password != null)
            {
                var datos = model.ValidateUser(User);
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
            ViewBag.Mensaje = "User incorrect, please try it again!";
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
using Aplicacion.Entities;
using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Controllers
{
    public class LogInController : BaseController
    {
        readonly UsersModel model = new UsersModel();

        [HttpGet]
        public ActionResult UserLogIn(Users User)
        {
            return View(new Users());
        }

        [SessionFilter]
        [HttpGet]
        public ActionResult UserRegistration(Users user)
        {
            
            return View(new Users());
        }

        [HttpPost]
        public ActionResult ValidateUser(Users User)
        {

            if (User.Password != null && User.Username != null)
            {
                var datos = model.ValidateUser(User);

                if (datos != null)
                {

                    Users usuario = new Users();
                    Session["User"] = datos;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("UserLogIn");
                }
            }
            else
            {
                ViewBag.Msj = "¡ERROR! El usuario o la contraseña son incorrectos. Por favor intente de nuevo.";

            }
            return View();

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
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

        [HttpGet]
        public ActionResult Terms()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserRegistration(Users user)
        {
            
            return View(new Users());
        }

        [HttpPost]
        public ActionResult ValidateUser(Users User)
        {

            if (User.noHashPass != null && User.Username != null)
            {
                var datos = model.ValidateUser(User);

                var genToken = model.GetToken(User.Id);

                if (datos.User != null)
                {

                    Session["User"] = new Users();
                    Session["User"] = datos.User;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Msj = "¡ERROR! El usuario o la contraseña son incorrectos. Por favor intente de nuevo.";
                    return View("UserNotActive");
                    
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
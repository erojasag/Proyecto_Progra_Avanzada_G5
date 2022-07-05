using Aplicacion.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UserRegistration()
        {
            return View();
        }


        [HttpGet]
        [Route("UserLogIn")]
        public ActionResult UserLogIn()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public ActionResult UserLogIn2(Users User)
        {
            Session["Username"] = "";
            Session["User_Role"] = null;
            return View();
        }

    }
}
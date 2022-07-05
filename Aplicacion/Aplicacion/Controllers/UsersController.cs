using Aplicacion.Entities;
using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Controllers
{
    public class UsersController : Controller
    {
        UsersModel model = new UsersModel();
        public ActionResult ViewUsers()
        {
            return null;
        }

        public ActionResult ViewUserById(int Id)
        {
            return null;
        }

        public ActionResult InsertUser(Users User)
        {
            return null;
        }

        public ActionResult EditUser(Users User)
        {
            return null;
        }

        public ActionResult DeleteUser(int Id)
        {
            return null;
        }

        public ActionResult ValidateUser(Users User)
        {
            try
            {
                var datos = model.ValidateUser(User);

                if (datos != null)
                {
                    return View(datos.Products);
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
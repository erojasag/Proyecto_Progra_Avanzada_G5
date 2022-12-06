using Aplicacion.Entities;
using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Controllers
{
    public class UsersController : BaseController
    {

        readonly UsersModel model = new UsersModel();

        [HttpGet]
        [Route("ViewUsers")]
        public ActionResult ViewUsers()
        {
            try
            {
                var datos = model.ViewUsers();

                if (datos != null)
                {
                    return View(datos.Users);
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
        [Route("ViewUserById")]
        public ActionResult ViewUserById(Guid? Id)
        {

            try
            { 
                var datos = model.ViewUserById((Guid)Id);
                if (datos == null)
                {
                    return View("Error");
                }
                else
                {
                    return View(datos);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [SessionFilter]
        public ActionResult UserRegistration(Users user)
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidateUser(Users user)
        {
            try
            {
                if (user != null)
                {
                    var datos = model.UserRegistration(user);

                    if (datos != null)
                    {
                        return RedirectToAction("UserRegistration", "Users");
                    }
                }

                return View("Error");

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        [HttpGet]
        [Route("ForgotPassword")]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public ActionResult ForgotPassword(Users user)
        {
            try
            {
                var checkUser = model.ViewUserByEmail(user.Email);

                if(checkUser.Transaction != false) 
                {
                    var data = model.ForgotPassword(user);

                    if (data != null)
                    {
                        return View("ForgotPasswordSuccessful");
                    }
                    else
                    {
                        return View("ForgotPasswordNotSuccessful");
                    }

                }
                else
                {
                    return View("ForgotPasswordNotSuccessful");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("ActivateAccount")]
        public ActionResult ActivateAccount()
        {
            try
            {
                return View("ActivateAccount");
            }
            catch(Exception ex)
            {
                throw ex;

            }
        }

        [HttpPost]
        [Route("ActivateAccount")]
        public ActionResult ActivateAccount(Users User)
        {
            try
            {
                var activate = model.ActivateAccount((Guid)User.Activation_Code);

                if (activate.Transaction == true)
                {
                    return View("AccountActivated");
                }
                else
                {
                    return View("AccountNotActivated");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [SessionFilter]
        [HttpGet]
        [Route("EditUser")]
        public ActionResult EditUser(Guid? Id)
        {
            try
            {
                var data = model.ViewUserById((Guid)Id);

                if (data != null)
                {
                    return View(data.User);
                }
                else
                {
                    return View();
                }
                

            }
            catch (Exception ex)
            {
                return View("Error");
                throw ex;
            }
        }

        [SessionFilter]
        [HttpPost]
        [Route("EditUser")]
        public ActionResult EditUser(Users user)
        {
            try
            {
                var data = model.EditUser(user);

                if (data.Transaction == true)
                {

                    ViewBag.Mensaje = "The brand was successfully modified";
                    return RedirectToAction("ViewUsers", "Users");
                }
                else
                {
                    ViewBag.Mensaje = "User not edited";
                    return View("EditUser");
                }

            }catch (Exception ex){
                return View("Error");
            }
        }


        [SessionFilter]
        [HttpGet]
        [Route("DeleteUser")]
        public ActionResult DeleteUser(Guid? Id)
        {
            try
            {
                var data = model.DeleteUser((Guid)Id);

                if (data.Transaction == true)
                {
                    ViewBag.Mensaje = "User properly deleted";
                    model.DeleteUser((Guid)Id);
                    return View();
                }
                else
                {
                    return View("UserNotDeleted");
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
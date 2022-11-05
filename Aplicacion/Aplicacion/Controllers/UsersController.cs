﻿using Aplicacion.Entities;
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

                    if (Id == null)
                    {
                        return View();
                    }

                    var datos = model.ViewUserById((Guid)Id);
                    if (datos == null)
                    {
                        return View("Error");
                    }

                    return View(datos);
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
                        return View(data.Users);
                    }
                    return View();

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
                    var data = model.ViewUserById((Guid)user.Id);
                    data.User.Name = user.Name;
                    data.User.First_last_name = user.First_last_name;
                    data.User.Second_last_name = user.Second_last_name;
                    data.User.User_Role = user.User_Role;
                    data.User.Password = user.Password;
                    data.User.Phone = user.Phone;
                    data.User.Email = user.Email;
                    data.User.Photo = user.Photo;
                    data.User.Address = user.Address;


                    if (data.Transaction == true)
                    {
                        model.EditUser(user);
                        return View("UserSuccessfullyEdited");
                    }
                    else
                    {
                        ViewBag.Mensaje = "User not edited";
                        return View("EditUser");
                    }
                }
                catch (Exception ex)
                {
                    return View("Error");
                    throw ex;
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
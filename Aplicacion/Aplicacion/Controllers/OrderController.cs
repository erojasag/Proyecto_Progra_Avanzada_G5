using Aplicacion.Entities;
using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Controllers
{
    public class OrderController : BaseController
    {
        readonly OrderModel model = new OrderModel();
        

        [HttpGet]
        public ActionResult InsertOrder(Orders Order)
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidateOrder(Orders Order)
        {
            try
            {
                if (Order != null)
                {
                    var datos = model.InsertOrder(Order);

                    if (datos != null)
                    {
                        return RedirectToAction("ViewOrders", "Orders");
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
        [Route("EditOrder")]
        public ActionResult EditOrder(Guid? Id)
        {
            try
            {
                var data = model.ViewDetailedOrderById((Guid)Id);

                if (data != null)
                {
                    return View(data.Order);
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
        [Route("EditOrder")]
        public ActionResult EditOrder(Orders order)
        {
            try
            {
                var data = model.EditOrder(order);

                if (data.Transaction == true)
                {

                    ViewBag.Mensaje = "The Order was successfully modified";
                    return RedirectToAction("ViewOrders", "Orders");
                }
                else
                {
                    ViewBag.Mensaje = "Order not edited";
                    return View("EditOrder");
                }

            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        [Route("CancelOrder")]
        public ActionResult CancelOrder(Guid? Id)
        {
            try
            {
                var datos = model.CancelOrder((Guid)Id);

                if(datos.Transaction == true)
                {
                    return View("OrderDeleted");
                }
                else
                {
                    return View("OrderNotDeleted");
                }
            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        [Route("ViewDetailedOrders")]
        public ActionResult ViewDetailedOrders()
        {
            try
            {
                var datos = model.ViewDetailedOrders();

                if (datos != null)
                {
                    return View(datos.Orders);
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
        [Route("ViewCustomersDetailedOrders")]
        public ActionResult ViewCustomersDetailedOrders(Guid? Id, bool? showCanceledOrders)
        {
            try
            {
                var datos = model.ViewCustomersDetailedOrders((Guid)Id, (bool)showCanceledOrders);

                if (datos.Transaction != false)
                {
                    return View(datos.Orders);
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
        [Route("ViewOrderById")]
        public ActionResult ViewDetailedOrderById(Guid Id)
        {
            try
            {

                if (Id == null)
                {
                    return View();
                }

                var datos = model.ViewDetailedOrderById((Guid)Id);
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

    }
}
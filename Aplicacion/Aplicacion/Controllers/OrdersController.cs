using Aplicacion.Entities;
using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Controllers
{
    public class OrdersController : BaseController
    {
        readonly OrderModel model = new OrderModel();

        [HttpGet]
        [Route("ViewOrders")]
        public ActionResult ViewOrders()
        {
            try
            {
                var datos = model.ViewOrders();

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
        [Route("ViewCustomersOrders")]
        public ActionResult ViewCustomersOrders(Guid Id)
        {
            try
            {
                var datos = model.ViewCustomersOrders(Id);

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
        [Route("ViewOrderById")]
        public ActionResult ViewOrderById(int Id)
        {
            try
            {

                if (Id == 0)
                {
                    return View();
                }

                var datos = model.ViewOrderById(Id);
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

    }
}
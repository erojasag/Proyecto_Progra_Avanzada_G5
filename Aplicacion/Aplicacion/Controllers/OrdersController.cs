using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult ViewOrders()
        {
            return View();
        }

        public ActionResult OrderConfirmation()
        {
            return View();
        }
    }
}
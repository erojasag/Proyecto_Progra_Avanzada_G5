using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult ViewShoppingCart()
        {
            return View();
        }

        public ActionResult GoToCheckOut()
        {
            return View();
        }

        public ActionResult FinishPurchase()
        {
            return View();
        }
    }
}
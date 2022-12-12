using Aplicacion.Entities;
using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Controllers
{
    public class ShoppingCartController : BaseController
    {
        // GET: ShoppingCart
        public ActionResult ViewShoppingCart()
        {
            return View();
        }

        public JsonResult ConsultarProductosJson()
        {
            try
            {
                List<Product> listaProductos = new List<Product>();
                ProductModel pl = new ProductModel();

                listaProductos = pl.ViewProducts().Products;

                foreach (Product i in listaProductos)
                {
                    i.Photo = "/assets/img/tratamientos/" + i.Id.ToString() + ".jpeg";
                    i.Model = i.Model;

                }
                var servicios = Json(listaProductos, JsonRequestBehavior.AllowGet);
                return servicios;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
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
using Aplicacion.Entities;
using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Controllers
{
    public class ProductsController : Controller
    {

        ProductsModel model = new ProductsModel();

        [HttpGet]
        [Route("ViewProducts")]
        public ActionResult ViewProducts()
        {
            try
            {
                //var datos = model.ViewProducts();
                return View();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
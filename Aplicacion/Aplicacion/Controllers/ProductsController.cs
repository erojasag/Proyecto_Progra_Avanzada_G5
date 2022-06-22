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


        // GET: Products
        [HttpGet]
        [Route("ViewProducts")]
        public ActionResult ViewProducts()
        {
            try
            {
                return model.ViewProducts();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
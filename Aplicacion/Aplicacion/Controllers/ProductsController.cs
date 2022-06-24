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
        Respuesta respuesta = new Respuesta();

        [HttpGet]
        [Route("ViewProducts")]
        public ActionResult ViewProducts()
        {
            try
            {
                var datos = model.ViewProducts();

                if (datos.Id == 0)
                {
                    return View();
                }
                else
                {
                    return View("Error");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("ViewProductById")]

        public ActionResult ViewProductById(int Id)
        {
            try
            {
                var datos = model.ViewProductById(Id);

                if (datos.Id == 0)
                {
                    return View();
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
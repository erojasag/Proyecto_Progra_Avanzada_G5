using Aplicacion.Entities;
using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Controllers
{
    public class ProductController : Controller
    {
        ProductModel model = new ProductModel();

        [HttpGet]
        [Route("ViewProducts")]
        public ActionResult ViewProducts()
        {
            try
            {
                var datos = model.ViewProducts();

                if (datos != null)
                {
                    return View(datos.Products);
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

        [HttpPost]
        [Route("InsertProduct")]
        public ActionResult InsertProduct(Product Product)
        {
            try
            {
                var datos = model.InsertProduct(Product);
                if(datos != null)
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

        [HttpPut]
        [Route("EditProduct")]
        public ActionResult EditProduct(Product product)
        {
            return null;
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public ActionResult DeleteProduct(int Id)
        {
            return null;
        }
    }
}
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
        readonly ProductModel model = new ProductModel();

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
        public ActionResult ViewProductById(int? Id)
        {
            try
            {
                
                if (Id == null)
                {
                    return View();
                }

                var datos = model.ViewProductById((int)Id);
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
        
        public ActionResult InsertProduct(Product Product)
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidateProduct(Product product)
        {
            try
            {
                if (product != null)
                {
                    var datos = model.InsertProduct(product);

                    if(datos != null)
                    {
                        return RedirectToAction("InsertProduct", "Product");
                    }
                }
              
                return View("Error");
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            

        }
        


        [HttpGet]
        [Route("EditProduct")]
        public ActionResult EditProduct(Product product)
        {
            return View();
        }



        [HttpGet]
        [Route("DeleteProduct")]
        public ActionResult DeleteProduct(int? Id)
        {
            return null;
        }
    }
}
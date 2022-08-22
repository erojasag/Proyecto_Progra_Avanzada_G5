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
        public ActionResult EditProduct(int? Id)
        {
            try
            {
                var data = model.ViewProductById((int)Id);

                if (data != null)
                {
                    return View(data.Product);
                }
                return View();

            }
            catch(Exception ex)
            {
                return View("Error");
                throw ex;
            }
        }

        [HttpPost]
        [Route("EditProduct")]
        public ActionResult EditProduct(Product product)
        {
            try
            {
                var data = model.ViewProductById((int)product.Id);
                data.Product.Brand_Id = product.Brand_Id;
                data.Product.Color = product.Color;
                data.Product.Model = product.Model;
                data.Product.shoeSize = product.shoeSize;
                data.Product.Stock = product.Stock;
                data.Product.Photo = product.Photo;

                if(data.Transaction == true)
                {
                    model.EditProduct(product);
                    return View("ProductoEditadoSatisfactoriamente");
                }
                else
                {
                    ViewBag.Mensaje = "Product not edited";
                    return View("EditProduct");
                }
            }
            catch(Exception ex)
            {
                return View("Error");
                throw ex;
            }
        }



        [HttpGet]
        [Route("DeleteProduct")]
        public ActionResult DeleteProduct(int? Id)
        {
            try
            {
                var data = model.DeleteProduct((int)Id);

                if(data.Transaction == true)
                {
                    ViewBag.Mensaje = "Product deleted properly";
                    model.DeleteProduct((int)Id);
                    return View();
                }
                else
                {
                    return View("ProductNotDeleted");
                }
            }
            catch(Exception ex)
            {
                return View("Error");
                throw ex;
            }
        }
    }
}
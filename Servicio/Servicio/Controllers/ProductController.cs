using Servicio.Entities;
using Servicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Servicio.Controllers
{
    public class ProductController : ApiController
    {
        readonly ProductModel model = new ProductModel();

        //GET Products
        [HttpGet]
        [Route("product/ViewProducts")]
        public Respuesta ViewProducts()
        {
            try
            {
                return model.ArmarRespuesta(0, "OK", true, null, model.ViewProducts());
            }
            catch(Exception ex)
            {
                return model.ArmarRespuesta(-1, ex.Message, false, null, null);
            }
        }

        //Get Product by id
        [HttpGet]
        [Route("product/ViewProduct")]
        public Respuesta ViewProduct(int Id)
        {
            try
            {
                return model.ArmarRespuesta(0, "OK", true, model.ViewProduct(Id), null);
            }
            catch (Exception ex)
            {
                return model.ArmarRespuesta(-1, ex.Message, false, null, null);
            }
        }

        //POST Product
        [HttpPost]
        [Route("product/InsertProduct")]
        public Respuesta InsertProduct(Product product)
        {
            try
            {
                return model.ArmarRespuesta(0, "OK", model.InsertProduct(product), product, null);
            }
            catch (Exception ex)
            {
                return model.ArmarRespuesta(-1, ex.Message, false, null, null);
            }
        }


        //PUT Product
        [HttpPut]
        [Route("product/UpdateProduct")]
        public Respuesta UpdateProduct(Product product)
        {
            try
            {
                return model.ArmarRespuesta(0, "OK", model.UpdateProduct(product), null, null);
            }
            catch (Exception ex)
            {
                return model.ArmarRespuesta(-1, ex.Message, model.UpdateProduct(product), null, null);
            }
        }


        //DELETE Product
        [HttpDelete]
        [Route("product/DeleteProduct")]
        public Respuesta DeleteProduct(int Id)
        {
            try
            {
                return model.ArmarRespuesta(0, "OK", model.DeleteProduct(Id), null, null);
            }
            catch (Exception ex)
            {
                return model.ArmarRespuesta(-1, ex.Message, model.DeleteProduct(Id), null, null);
            }
        }
    }
}

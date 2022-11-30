using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Servicio.Entities;
using Servicio.Models;

namespace Servicio.Controllers
{
    public class ProductsController : ApiController
    {
        readonly Respuesta respuesta = new Respuesta();
        readonly ProductsModel model = new ProductsModel();

        [HttpGet]
        [Route("products/ViewProducts")]
        public Respuesta ViewProducts()
        {
            try
            {
                return respuesta.ArmarRespuestaProducts(1, "OK", true, null, model.ViewProducts());
            }
            catch(Exception ex)
            {
                return respuesta.ArmarRespuestaProducts(-1, ex.Message, false, null, null);
            }
        }

        
        [HttpGet]
        [Authorize]
        [Route("products/ViewProductById")]
        public Respuesta ViewProductById(int Id) 
        {
            try
            {
                return respuesta.ArmarRespuestaProducts(1, "OK", true, model.ViewProductById(Id), null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaProducts(-1, ex.Message, false, null, null);
            }
        }



        [HttpPost]
        [Authorize]
        [Route("products/InsertProduct")]
        public Respuesta InsertProduct(Product product)
        {
            try
            {
                return respuesta.ArmarRespuestaProducts(1, "OK", model.InsertProduct(product), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaProducts(-1, ex.Message, false, null, null);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("products/EditProduct")]
        public Respuesta EditProduct(Product product)
        {
            try
            {
                return respuesta.ArmarRespuestaProducts(1, "OK", model.EditProduct(product), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaProducts(-1, ex.Message, false, null, null);
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("products/DeleteProduct")]

        public Respuesta DeleteProduct(int Id)
        {
            try
            {
                return respuesta.ArmarRespuestaProducts(1, "OK", model.DeleteProduct(Id), null , null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaProducts(-1, ex.Message, false, null, null);
            }
        }

    }
}

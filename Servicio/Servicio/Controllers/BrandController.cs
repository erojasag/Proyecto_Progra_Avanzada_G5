using Servicio.Entities;
using Servicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;

namespace Servicio.Controllers
{
    public class BrandController : ApiController
    {
        readonly Respuesta respuesta = new Respuesta();
        readonly BrandModel model = new BrandModel();

        [HttpGet]
        
        [Route("brands/ViewBrands")]
        public Respuesta ViewBrands()
        {
            try
            {
                return respuesta.ArmarRespuestaBrand(1, "OK", false, null, model.ViewBrands());
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaBrand(-1, ex.Message, false, null, null);
            }
        }

        [HttpGet]
        
        [Route("brands/ViewBrandById")]
        public Respuesta ViewBrandById(int Id)
        {
            try
            {
                return respuesta.ArmarRespuestaBrand(1, "OK", false, model.ViewBrandById(Id), null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaBrand(-1, ex.Message, false, null, null);
            }
        }

        [HttpPost]
        
        [Route("brands/InsertBrand")]
        public Respuesta InsertBrand(Brand Brand)
        {
            try
            {
                return respuesta.ArmarRespuestaBrand(1, "OK", model.InsertBrand(Brand), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaBrand(-1, ex.Message, false, null, null);
            }
        }

        [HttpPut]
        
        [Route("brands/EditBrand")]
        public Respuesta EditBrand(Brand Brand)
        {
            try
            {
                return respuesta.ArmarRespuestaBrand(1, "OK", model.EditBrand(Brand), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaBrand(-1, ex.Message, false, null, null);
            }
        }

        [HttpGet]
        [Route("brands/DeleteBrand")]
        public Respuesta DeleteBrand(int Id)
        {
            try
            {
                return respuesta.ArmarRespuestaBrand(1, "OK", model.DeleteBrand(Id), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaBrand(-1, ex.Message, false, null, null);
            }
        }
    }
}

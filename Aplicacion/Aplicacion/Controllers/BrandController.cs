using Aplicacion.Entities;
using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Controllers
{
    public class BrandController : Controller
    {
        BrandModel model = new BrandModel();

        [HttpGet]
        [Route("ViewBrands")]
        public ActionResult ViewBrands()
        {
            try
            {
                var datos = model.ViewBrands();
                if(datos != null)
                {
                    return View(datos.Brands);
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

        public ActionResult ViewBrandById(int Id)
        {
            return null;
        }

        public ActionResult InsertBrand(Brand brand)
        {
            return null;
        }

        public ActionResult EditBrand(Brand brand)
        {
            return null;
        }

        public ActionResult DeleteBrand(int Id)
        {
            return null;
        }
    }
}
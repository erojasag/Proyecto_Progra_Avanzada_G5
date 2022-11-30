using Aplicacion.Entities;
using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Controllers
{
    public class BrandController : BaseController
    {
        readonly BrandModel model = new BrandModel();

        [HttpGet]
        [Route("ViewBrands")]
        public ActionResult ViewBrands()
        {
            try
            {
                var datos = model.ViewBrands();

                if (datos != null)
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

        [HttpGet]
        [Route("ViewBrandById")]
        public ActionResult ViewBrandById(int Id)
        {
            try
            {

                if (Id == 0)
                {
                    return View();
                }

                var datos = model.ViewBrandById(Id);
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
        [SessionFilter]
        public ActionResult InsertBrand(Brand Brand)
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidateBrand(Brand Brand)
        {
            try
            {
                if (Brand != null)
                {
                    var datos = model.InsertBrand(Brand);

                    if (datos != null)
                    {
                        return RedirectToAction("ViewBrands", "Brand");
                    }
                }

                return View("Error");

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        [SessionFilter]
        [HttpGet]
        [Route("EditBrand")]
        public ActionResult EditBrand(int Id)
        {
            try
            {
                var data = model.ViewBrandById(Id);

                if (data != null)
                {
                    return View(data.Brand);
                }
                return View();

            }
            catch (Exception ex)
            {
                return View("Error");
                throw ex;
            }
        }

        [SessionFilter]
        [HttpPost]
        [Route("EditBrand")]
        public ActionResult EditBrand(Brand brand)
        {
            try
            {
                var data = model.EditBrand(brand);


                if (data.Transaction)
                {
                    ViewBag.Mensaje = "The brand was successfully modified";
                    return RedirectToAction("ViewBrands", "Brand");
                }
                else
                {
                    ViewBag.Mensaje = "ERROR! The Brand could not be edited";
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
                throw ex;
            }
        }


        [SessionFilter]
        [HttpGet]
        [Route("DeleteBrand")]
        public ActionResult DeleteBrand(int Id)
        {
            try
            {
                var respuesta = model.ViewBrandById(Id);

                if (respuesta == null || respuesta.Id != 0)
                    return View("Error");
                else
                    return View(respuesta.Brand);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [SessionFilter]
        [HttpPost]
        [Route("DeleteBrand")]
        public ActionResult DeleteBrand(Brand brand)
        {
            try
            {
                var respuesta = model.DeleteBrand(brand.Id);

                if (respuesta.Transaction == true)
                    return RedirectToAction("ViewBrands", "Brand");
                else
                    return View("Error");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
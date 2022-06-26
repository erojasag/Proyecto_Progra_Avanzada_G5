using Aplicacion.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        public ActionResult ViewBrands()
        {
            return View();
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
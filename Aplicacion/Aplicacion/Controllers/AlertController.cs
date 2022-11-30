using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Aplicacion.Models.Enum;

namespace Aplicacion.Controllers
{
    public class AlertController : BaseController
    {
        [HttpGet]
        public ActionResult ShowAlert()
        {
            Alert("El tutorial ha finalizado con éxito", NotificationType.success);
            return View();
        }
    }
}
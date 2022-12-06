using Aplicacion.Entities;
using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Controllers
{
    public class ShipmentController : BaseController
    {
        readonly ShipmentModel model = new ShipmentModel();

        [HttpGet]
        [Route("ViewShipments")]
        public ActionResult ViewShipments()
        {
            try
            {
                var datos = model.ViewShipments();

                if (datos.Transaction == true)
                {
                    return View(datos.Shipments);
                }
                if(datos.Transaction == false)
                {
                    return View("NoShippings");
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
        [Route("ViewShipmentsById")]
        public ActionResult ViewShipmentsById(int Id)
        {
            try
            {

                if (Id == 0)
                {
                    return View();
                }

                var datos = model.ViewShipmentsById(Id);
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
        [Route("InsertShipments")]
        [SessionFilter]
        public ActionResult InsertShipment(Shipments Shipment)
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidateShipment(Shipments Shipment)
        {
            try
            {
                if (Shipment != null)
                {
                    var datos = model.InsertShipment(Shipment);

                    if (datos != null)
                    {
                        return RedirectToAction("ViewShipments", "Shipment");
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
        [Route("EditShipments")]
        public ActionResult EditShipments(int Id)
        {
            try
            {
                var data = model.ViewShipmentsById(Id);

                if (data != null)
                {
                    return View(data.Shipment);
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
        [Route("EditShipments")]
        public ActionResult EditShipments(Shipments Shipment)
        {
            try
            {
                var data = model.EditShipments(Shipment);


                if (data.Transaction)
                {
                    ViewBag.Mensaje = "The shipment was successfully modified";
                    return RedirectToAction("ViewShipments", "Shipment");
                }
                else
                {
                    ViewBag.Mensaje = "ERROR! The shipment could not be edited";
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
        [Route("DeleteShipment")]
        public ActionResult DeleteShipment(int? Id)
        {
            try
            {
                var respuesta = model.DeleteShipment((int)Id);

                if (respuesta == null || respuesta.Id != 0)
                    return View("Error");
                else
                    return View(respuesta.Shipment);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [SessionFilter]
        [HttpPost]
        [Route("DeleteShipment")]
        public ActionResult DeleteShipment(Shipments shipment)
        {
            try
            {
                var respuesta = model.DeleteShipment(shipment.shipment_id);

                if (respuesta.Transaction == true)
                    return RedirectToAction("ViewShipments", "Shipment");
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
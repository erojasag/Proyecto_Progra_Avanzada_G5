﻿using Servicio.Entities;
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
    public class ShipmentController : ApiController
    {
        readonly Respuesta respuesta = new Respuesta();
        readonly ShipmentsModel model = new ShipmentsModel();

        [HttpGet]
        //[Authorize]
        [Route("shipments/ViewShipments")]
        public Respuesta ViewShipments()
        {
            try
            {
                return respuesta.ArmarRespuestaShipment(1, "OK", true, null, model.ViewShipments());
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaShipment(-1, ex.Message, false, null, null);
            }
        }

        [HttpGet]
        //[Authorize]
        [Route("shipments/ViewShipmentsById")]
        public Respuesta ViewShipmentsById(int Id)
        {
            try
            {
                return respuesta.ArmarRespuestaShipment(1, "OK", false, model.ViewShipmentsById(Id), null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaShipment(-1, ex.Message, false, null, null);
            }
        }

        [HttpGet]
        //[Authorize]
        [Route("shipments/ViewOrderStatus")]
        public Respuesta ViewOrderStatus(int Id)
        {
            try
            {
                return respuesta.ArmarRespuestaShipment(1, "OK", false, model.ViewOrderStatus(Id), null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaShipment(-1, ex.Message, false, null, null);
            }
        }


        [HttpPost]
        //[Authorize]
        [Route("shipments/InsertShipment")]
        public Respuesta InsertShipment(Shipments shipments)
        {
            try
            {
                return respuesta.ArmarRespuestaShipment(1, "OK", model.InsertShipment(shipments), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaShipment(-1, ex.Message, false, null, null);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("shipments/EditShipments")]
        public Respuesta EditShipments(Shipments shipments)
        {
            try
            {
                return respuesta.ArmarRespuestaShipment(1, "OK", model.EditShipments(shipments), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaShipment(-1, ex.Message, false, null, null);
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("shipments/DeleteShipment")]
        public Respuesta DeleteShipment(int Id)
        {
            try
            {
                return respuesta.ArmarRespuestaShipment(1, "OK", model.DeleteShipment(Id), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaShipment(-1, ex.Message, false, null, null);
            }
        }
    }
}
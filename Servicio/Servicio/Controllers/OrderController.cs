using Servicio.Entities;
using Servicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace Servicio.Controllers
{
    public class OrderController : ApiController
    {
        readonly Respuesta respuesta = new Respuesta();
        readonly OrderModel model = new OrderModel();

        [HttpPost]
        //[Authorize]
        [Route("Order/InsertOrder")]
        public string InsertOrder(Orders order)
        {
            try
            {
                return model.InsertOrder(order);
            }
            catch (Exception ex)
            {
                return "Error al Registrar Orden";
            }

        }

        [HttpPost]
       // [Authorize]
        [Route("Order/EditOrder")]
        public Respuesta EditOrder(Orders Order)
        {
            try
            {
                return respuesta.ArmarRespuestaOrders(1, "OK", model.EditOrder(Order), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaOrders(0, ex.Message, false, null, null);
            }
        }

        [HttpGet]
        //[Authorize]
        [Route("Order/CancelOrder")]
        public Respuesta CancelOrder(Guid Id)
        {
            try
            {
                return respuesta.ArmarRespuestaOrders(1, "OK", model.CancelOrder(Id), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaOrders(0, ex.Message, false, null, null);
            }
        }

        [HttpGet]
        // [Authorize]
        [Route("Order/ViewDetailedOrders")]
        public Respuesta ViewDetailedOrders()
        {
            try
            {
                return respuesta.ArmarRespuestaOrders(1, "OK", true, null, model.ViewDetailedOrders());
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaOrders(0, ex.Message, false, null, null);
            }
        }

        //[Authorize]
        [HttpGet]
        [Route("Order/ViewCustomersDetailedOrders")]
        public Respuesta ViewCustomersDetailedOrders(Guid Id, bool showCanceledOrders)
        {
            try
            {
                return respuesta.ArmarRespuestaOrders(1, "OK", true, null, model.ViewCustomersDetailedOrders(Id, showCanceledOrders));
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaOrders(0, ex.Message, false, null, null);
            }
        }

        [HttpGet]
        // [Authorize]
        [Route("Order/ViewDetailedOrderById")]
        public Respuesta ViewDetailedOrderById(Guid Id)
        {
            try
            {
                return respuesta.ArmarRespuestaOrders(1, "OK", true, model.ViewDetailedOrderById(Id), null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaOrders(0, ex.Message, false, null, null);
            }
        }
    }
}

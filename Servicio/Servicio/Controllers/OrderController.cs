using Servicio.Entities;
using Servicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Servicio.Controllers
{
    public class OrderController : Controller
    {
        readonly Respuesta respuesta = new Respuesta();
        readonly OrderModel model = new OrderModel();

        [HttpGet]
        [Authorize]
        [Route("Orders/ViewOrders")]
        public Respuesta ViewOrders()
        {
            try
            {
                return respuesta.ArmarRespuestaOrdenDetallada(1, "OK", false, null, model.ViewOrders());
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaOrdenDetallada(-1, ex.Message, false, null, null);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("Orders/ViewOrderById")]
        public Respuesta ViewOrderById(int Id)
        {
            try
            {
                return respuesta.ArmarRespuestaOrdenDetallada(1, "OK", false, model.ViewOrderById(Id), null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaOrdenDetallada(-1, ex.Message, false, null, null);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("Orders/InsertOrder")]
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

        [HttpPut]
        [Authorize]
        [Route("Orders/EditOrder")]
        public Respuesta EditOrder(Orders Order)
        {
            try
            {
                return respuesta.ArmarRespuestaOrders(1, "OK", model.EditOrder(Order), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaOrders(-1, ex.Message, false, null, null);
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("Orders/DeleteOrder")]
        public Respuesta DeleteOrder(int Id)
        {
            try
            {
                return respuesta.ArmarRespuestaOrders(1, "OK", model.DeleteOrder(Id), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaOrders(-1, ex.Message, false, null, null);
            }
        }
    }
}

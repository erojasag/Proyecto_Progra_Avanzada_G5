using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Servicio.Controllers;
using Servicio.Entities;

namespace Servicio.Controllers
{
    public class RespuestaController : ApiController
    {
        Customer customer = new Customer();
        public Respuesta ArmarRespuesta(int Id, string Message, bool transaccion, Customer customer
            , List<Customer> customers)
        {

            Respuesta respuesta = new Respuesta();
            respuesta.Id = 0;
            respuesta.Message = "OK";
            respuesta.transaccion = transaccion;
            respuesta.customers = customers;
            respuesta.customer = customer;

            return respuesta;

        }
    }
}

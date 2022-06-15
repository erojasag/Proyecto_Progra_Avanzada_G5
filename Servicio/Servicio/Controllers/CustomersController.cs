using Servicio.Entities;
using Servicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Servicio.Controllers
{
    public class CustomersController : ApiController
    {
        readonly CustomerModel model = new CustomerModel();
        readonly RespuestaController respuesta = new RespuestaController();
        [HttpGet]
        [Route("customers/viewCustomers")]
        public Respuesta viewCustomers()
        {

            try 
            {
                return respuesta.ArmarRespuesta(0, "OK", false, null, model.viewCustomers());
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuesta(-1, ex.Message, false, null, null);

            }



        }


        [HttpGet]
        [Route("customers/viewCustomerById")]

        public Respuesta viewCustomerById(int Id)
        {
            try
            {
                return respuesta.ArmarRespuesta(0, "OK", false, model.viewCustomerById(Id), null);
            }
            catch (Exception ex) {

                return respuesta.ArmarRespuesta(-1, ex.Message, false, null, null);
            }
        }

        [HttpPost]
        [Route("customers/addCustomer")]
        public Respuesta addCustomer(Customer customer)
        {
            try
            {
                return respuesta.ArmarRespuesta(0, "OK", model.addCustomer(customer), customer, null);
            }
            catch(Exception ex)
            {
                return respuesta.ArmarRespuesta(-1, ex.Message, false, null, null);
            }
        }


        [HttpPut]
        [Route("customers/editCustomer")]
        public Respuesta editCustomer(Customer customer)
        {
            try
            {
                return respuesta.ArmarRespuesta(0, "OK", model.editCustomer(customer), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuesta(-1, ex.Message, false, null, null);
            }
        }

        [HttpDelete]
        [Route("customers/deleteCustomerById")]
        public Respuesta deleteCustomerById(int Id)
        {
            try
            {
                return respuesta.ArmarRespuesta(0, "OK", model.deleteCustomerById(Id), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuesta(-1, ex.Message, false, null, null);
            }
        }

    }
}

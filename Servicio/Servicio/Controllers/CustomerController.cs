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
    public class CustomerController : ApiController
    {
        readonly CustomerModel model = new CustomerModel();
        

        [HttpGet]
        [Route("customer/ViewCustomers")]
        public Respuesta ViewCustomers()
        {
            try
            {
                return model.ArmarRespuesta(0, "OK", false, null, model.ViewCustomers());

            }
            catch (Exception ex)
            {
                return model.ArmarRespuesta(-1, ex.Message, false, null, null);
            }
        }

        [HttpGet]
        [Route("customer/ViewCustomerById")]
        public Respuesta ViewCustomerById(int Id)
        {
            try
            {
                return model.ArmarRespuesta(0, "OK", false, model.ViewCustomerById(Id), null);

            }
            catch (Exception ex)
            {
                return model.ArmarRespuesta(-1, ex.Message, false, null, null);
            }
        }

        [HttpPost]
        [Route("customer/InsertCustomer")]
        public Respuesta InsertCustomer(Customer customer)
        {
            try
            {
                return model.ArmarRespuesta(0, "OK", model.InsertCustomer(customer), customer, null);

            }
            catch (Exception ex)
            {
                return model.ArmarRespuesta(-1, ex.Message, false, null, null);
            }
        }

        [HttpPut]
        [Route("customer/UpdateCustomer")]
        public Respuesta UpdateCustomer(Customer customer)
        {
            try
            {
                return model.ArmarRespuesta(0, "OK", model.UpdateCustomer(customer), customer, null);

            }
            catch (Exception ex)
            {
                return model.ArmarRespuesta(-1, ex.Message, false, null, null);
            }
        }

        [HttpDelete]
        [Route("customer/DeleteCustomer")]
        public Respuesta DeleteCustomer(int user_Id)
        {
            try
            {
                return model.ArmarRespuesta(0, "OK", model.DeleteCustomer(user_Id), null, null);

            }
            catch (Exception ex)
            {
                return model.ArmarRespuesta(-1, ex.Message, false, null, null);
            }
        }
    }
}

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

        [HttpGet]
        [Route("customers/viewCustomers")]
        public List<Customer> viewCustomers()
        {

            try 
            {
                return model.viewCustomers();
            }
            catch (Exception ex){
                throw ex;

            }



        }


        [HttpGet]
        [Route("customers/viewCustomerById")]

        public Customer viewCustomerById(int Id)
        {
            try
            {
                return model.viewCustomer(Id);
            }
            catch (Exception ex) { 
                
                throw ex;
            }
        }
    }
}

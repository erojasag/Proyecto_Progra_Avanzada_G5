using Servicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Models
{
    public class CustomerModel
    {
        public List<Customer> viewCustomers()
        {
            
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var customers = db.Customer.ToList();
                    return customers;

                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }

            }
           
        }

        public Customer viewCustomer(int Id)
        {
            try
            {
                Customer customer = new Customer();
                var response = "";
                using(var db = new Proyecto_Progra_Avanzada_G5Entities())
                {
                    customer = db.view_customer_by_id(Id).FirstOrDefault();
                }
                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
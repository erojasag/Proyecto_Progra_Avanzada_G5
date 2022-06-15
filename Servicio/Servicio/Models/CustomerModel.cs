using Servicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

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

        public Customer viewCustomerById(int Id)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var customer = db.Customer.Find(Id);
                    if (customer != null)
                    {

                        return customer;

                    }
                    else
                    {
                        db.Dispose();
                        return null;
                    }


                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public bool addCustomer(Customer customer)
        {
            Customer customer2 = new Customer();
            using(var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    if(customer2 != null)
                    {
                        customer2.customer_name = customer.customer_name;
                        customer2.customer_first_last_name = customer.customer_first_last_name;
                        customer2.customer_last_name = customer.customer_last_name;
                        customer2.customer_phone = customer.customer_phone;
                        customer2.customer_email = customer.customer_email;
                        customer2.customer_address = customer.customer_address;
                        customer2.customer_id = customer.customer_id;
                        customer2.customer_birthDate = customer.customer_birthDate;
                        customer2.customer_registration_date = DateTime.Now;
                        db.Customer.Add(customer2);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch(Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }
        public bool editCustomer(Customer customer)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var data = db.Customer.Find(customer.customer_user_id);
                    if(data != null)
                    {
                        data.customer_email = customer.customer_email;
                        data.customer_address = customer.customer_address;
                        data.customer_phone = customer.customer_phone;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("No se pudo actualizar la informacion del cliente");
                    }
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public bool deleteCustomerById(int Id)
        {
            using(var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var data = db.Customer.Find(Id);
                    if(data != null)
                    {
                        db.Customer.Remove(data);
                        db.SaveChanges();
                        return true;

                    }
                    else
                    {
                        throw new Exception("No se encontro el cliente que desea eliminar");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
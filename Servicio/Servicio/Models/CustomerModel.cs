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
            using (var conection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var data = conection.TCustomer.ToList();

           
                    List<Customer> customers = new List<Customer>();
                    foreach (var customer in data)
                    {
                   
                       
                        customers.Add(new Customer
                        {
                            user_Id = customer.user_Id,
                            login_name_customer = customer.login_name_customer,
                            password_hash_customer = customer.password_hash_customer,
                            name = customer.name,
                            first_last_name = customer.first_last_name,
                            second_last_name = customer.second_last_name,
                            Id = customer.Id,
                            phone = customer.phone,
                            email = customer.email,
                            registration_date = customer.registration_date,
                            birth_date = customer.birth_date,
                            customer_photo = customer.customer_photo,
                            address = customer.address
                        });
                    }
                    return customers;

                }
                catch (Exception ex)
                {
                    conection.Dispose();
                    throw ex;
                }
            }
        }

        public Customer ViewCustomerById(int Id)
        {

            using (var conection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    Customer customer = new Customer();
                    var getCustomer = conection.TCustomer.FirstOrDefault();
                    
                    customer.user_Id = getCustomer.user_Id;
                    customer.login_name_customer = getCustomer.login_name_customer;
                    customer.password_hash_customer = getCustomer.password_hash_customer;
                    customer.name = getCustomer.name;
                    customer.first_last_name = getCustomer.first_last_name;
                    customer.second_last_name = getCustomer.second_last_name;
                    customer.Id = getCustomer.Id;
                    customer.phone = getCustomer.phone;
                    customer.email = getCustomer.email;
                    customer.registration_date = getCustomer.registration_date;
                    customer.birth_date = getCustomer.birth_date;
                    customer.customer_photo = getCustomer.customer_photo;
                    customer.address = getCustomer.address;

                    return customer;
                }
                catch (Exception ex)
                {
                    conection.Dispose();
                    throw ex;
                }
            }
        }

        public bool InsertCustomer(Customer customer)
        {
            

            using (var conection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    

                    if (customer != null)
                    {
                        TCustomer tcustomer = new TCustomer();
                        tcustomer.login_name_customer = customer.login_name_customer;
                        tcustomer.password_hash_customer = customer.password_hash_customer;
                        tcustomer.name = customer.name;
                        tcustomer.first_last_name = customer.first_last_name;
                        tcustomer.second_last_name = customer.second_last_name;
                        tcustomer.Id = customer.Id;
                        tcustomer.phone = customer.phone;
                        tcustomer.email = customer.email;
                        tcustomer.birth_date = new DateTime();
                        tcustomer.customer_photo = customer.customer_photo;
                        tcustomer.address = customer.address;
                        conection.TCustomer.Add(tcustomer);
                        conection.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    conection.Dispose();
                    throw ex;
                }
            }

        }

        public bool UpdateCustomer(Customer customer)
        {
            using(var conection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var getCustomer = conection.TCustomer.Find(customer.user_Id);

                    if(getCustomer != null)
                    {

                        getCustomer.name = customer.name;
                        getCustomer.first_last_name = customer.first_last_name;
                        getCustomer.second_last_name = customer.second_last_name;
                        getCustomer.phone = customer.phone;
                        getCustomer.email = customer.email;
                        getCustomer.customer_photo = customer.customer_photo;
                        getCustomer.address = customer.address;
                        conection.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("Cliente no encontrado");
                    }
                }
                catch (Exception ex)
                {
                    conection.Dispose();
                    throw ex;

                }
            }
        }

        public bool DeleteCustomer(int user_Id)
        {
            using (var conection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var getCustomer = conection.TCustomer.Find(user_Id);
                    if( getCustomer != null)
                    {
                        conection.TCustomer.Remove(getCustomer);
                        conection.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("No se encontro el cliente a eliminar");
                    }
                }
                catch (Exception ex)
                {
                    conection.Dispose();
                    throw ex;
                }
            }
        }

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
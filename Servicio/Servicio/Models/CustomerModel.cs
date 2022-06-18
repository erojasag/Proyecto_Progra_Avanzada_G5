using Servicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Models
{
    public class CustomerModel
    {
        public List<Customer> ViewCustomers()
        {
            using (var connection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var data = connection.Customer.ToList();

           
                    List<Customer> customers = new List<Customer>();
                    foreach (var customer in data)
                    {
                   
                       
                        customers.Add(new Customer
                        {
                            User_Id = customer.User_Id,
                            Login_name_customer = customer.Login_name_customer,
                            Password = customer.Password,
                            Name = customer.Name,
                            First_last_name = customer.First_last_name,
                            Second_last_name = customer.Second_last_name,
                            Id = customer.Id,
                            Phone = customer.Phone,
                            Email = customer.Email,
                            Registration_date = customer.Registration_date,
                            Birth_date = customer.Birth_date,
                            Photo = customer.Photo,
                            Address = customer.Address
                        });
                    }
                    return customers;

                }
                catch (Exception ex)
                {
                    connection.Dispose();
                    throw ex;
                }
            }
        }

        public Customer ViewCustomerById(int Id)
        {

            using (var connection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    Customer customer = new Customer();
                    var getCustomer = connection.Customer.Find(Id);
                    
                    customer.User_Id = getCustomer.User_Id;
                    customer.Login_name_customer = getCustomer.Login_name_customer;
                    customer.Password = getCustomer.Password;
                    customer.Name = getCustomer.Name;
                    customer.First_last_name = getCustomer.First_last_name;
                    customer.Second_last_name = getCustomer.Second_last_name;
                    customer.Id = getCustomer.Id;
                    customer.Phone = getCustomer.Phone;
                    customer.Email = getCustomer.Email;
                    customer.Birth_date = getCustomer.Birth_date;
                    customer.Photo = getCustomer.Photo;
                    customer.Address = getCustomer.Address;

                    return customer;
                }
                catch (Exception ex)
                {
                    connection.Dispose();
                    throw ex;
                }
            }
        }

        public bool InsertCustomer(Customer customer)
        {
            

            using (var connection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    

                    if (customer != null)
                    {
                        Customer tcustomer = new Customer();
                        tcustomer.Login_name_customer = customer.Login_name_customer;
                        tcustomer.Password = customer.Password;
                        tcustomer.Name = customer.Name;
                        tcustomer.First_last_name = customer.First_last_name;
                        tcustomer.Second_last_name = customer.Second_last_name;
                        tcustomer.Id = customer.Id;
                        tcustomer.Phone = customer.Phone;
                        tcustomer.Email = customer.Email;
                        tcustomer.Registration_date = DateTime.Now;
                        tcustomer.Birth_date = new DateTime();
                        tcustomer.Photo = customer.Photo;
                        tcustomer.Address = customer.Address;
                        connection.Customer.Add(tcustomer);
                        connection.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    connection.Dispose();
                    throw ex;
                }
            }

        }

        public bool UpdateCustomer(Customer customer)
        {
            using(var connection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var getCustomer = connection.Customer.Find(customer.User_Id);

                    if(getCustomer != null)
                    {

                        getCustomer.Name = customer.Name;
                        getCustomer.First_last_name = customer.First_last_name;
                        getCustomer.Second_last_name = customer.Second_last_name;
                        getCustomer.Phone = customer.Phone;
                        getCustomer.Email = customer.Email;
                        getCustomer.Photo = customer.Photo;
                        getCustomer.Address = customer.Address;
                        getCustomer.Modification_date = DateTime.Now;
                        connection.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("Cliente no encontrado");
                    }
                }
                catch (Exception ex)
                {
                    connection.Dispose();
                    throw ex;

                }
            }
        }

        public bool DeleteCustomer(int user_Id)
        {
            using (var connection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var getCustomer = connection.Customer.Find(user_Id);
                    if( getCustomer != null)
                    {
                        connection.Customer.Remove(getCustomer);
                        connection.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("No se encontro el cliente a eliminar");
                    }
                }
                catch (Exception ex)
                {
                    connection.Dispose();
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
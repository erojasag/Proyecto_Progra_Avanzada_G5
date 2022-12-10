using Aplicacion.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Models
{
    public class OrderModel
    {
        string Url = ConfigurationManager.AppSettings["urlServicioProyecto"].ToString();
        
        public Respuesta ViewOrders()
         {
            using (var client = new HttpClient())
            {
                try
                {
                    string Route = "Orders/ViewOrders";

                    HttpResponseMessage response = client.GetAsync(Url + Route).Result;

                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsAsync<Respuesta>().Result; //serializacion del obj JSON a un objeto
                    }
                    else
                    {
                        return null;
                    }


                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public Respuesta ViewCustomersOrders(Guid Id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string Route = "Orders/ViewCustomersOrders?Id=" + Id; 

                    HttpResponseMessage response = client.GetAsync(Url + Route).Result;

                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsAsync<Respuesta>().Result; //serializacion del obj JSON a un objeto
                    }
                    else
                    {
                        return null;
                    }


                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }


        public Respuesta ViewOrderById(int Id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    if (Id >= 0)
                    {
                        string api = "Orders/ViewOrderById?Id=" + Id;
                        string route = Url + api;

                        HttpResponseMessage response = client.GetAsync(route).Result;

                        response.EnsureSuccessStatusCode();
                        if (response.IsSuccessStatusCode)
                        {
                            var responseBody = response.Content.ReadAsAsync<Respuesta>().Result; //serializacion del obj JSON a un objeto
                            return responseBody;
                        }
                        else
                        {
                            throw new Exception("Could not find any orders under Id:" + " " + Id);
                        }

                    }
                    else
                    {
                        throw new Exception("The order Id must be higher than 0");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public Respuesta InsertOrder(Orders order)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    if (order != null)
                    {
                        string api = "Orders/InsertOrder";
                        string route = Url + api;
                        var content = JsonContent.Create(order);
                        HttpResponseMessage response = client.PostAsync(route, content).Result;

                        response.EnsureSuccessStatusCode();
                        if (response.IsSuccessStatusCode)
                        {
                            var responseBody = response.Content.ReadAsAsync<Respuesta>().Result;
                            return responseBody;
                        }
                        else
                        {
                            throw new Exception("The order could not be created");
                        }
                    }
                    else
                    {
                        throw new Exception("Please enter the information of the new order.");
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
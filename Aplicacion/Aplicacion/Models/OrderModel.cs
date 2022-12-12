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

        public Respuesta EditOrder(Orders order)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    if (order != null)
                    {
                        JsonContent body = JsonContent.Create(order);
                        string api = "Order/EditOrder";
                        string route = Url + api;
                        HttpResponseMessage respuesta = client.PostAsync(route, body).Result;
                        if (respuesta.IsSuccessStatusCode)
                        {
                            return respuesta.Content.ReadAsAsync<Respuesta>().Result;
                        }

                    }
                    else
                    {
                        return null;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Respuesta ViewDetailedOrders()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string Route = "OrdenDetallada/ViewDetailedOrders";

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
        public Respuesta ViewCustomersDetailedOrders(Guid Id, bool showCanceledOrders)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string Route = "Order/ViewCustomersDetailedOrders?Id=" + Id + "&showCanceledOrders="+showCanceledOrders;

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
        public Respuesta ViewDetailedOrderById(Guid Id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    if (Id != null)
                    {
                        string api = "Order/ViewDetailedOrderById?Id=" + Id;
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

        public Respuesta CancelOrder(Guid Id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    if (Id != null)
                    {
                        string api = "Order/CancelOrder?Id=" + Id;
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
                            throw new Exception("Could not delete de order ID:" + " " + Id);
                        }

                    }
                    else
                    {
                        throw new Exception("The order does not exists");
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
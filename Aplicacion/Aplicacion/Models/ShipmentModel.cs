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
    public class ShipmentModel
    {
        string Url = ConfigurationManager.AppSettings["urlServicioProyecto"].ToString();
        public Respuesta ViewShipments()
        {

            using (var client = new HttpClient())
            {
                try
                {
                    string Route = "shipments/ViewShipments";

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

        public Respuesta ViewShipmentsById(int Id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    if (Id >= 0)
                    {
                        string api = "shipments/ViewShipmentsById?Id=" + Id;
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
                            throw new Exception("Could not find any shipment results under Id:" + " " + Id);
                        }

                    }
                    else
                    {
                        throw new Exception("The shipment Id must be higher than 0");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public Respuesta ViewOrderStatus(int Id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    if (Id >= 0)
                    {
                        string api = "shipments/ViewOrderStatus?Id=" + Id;
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
                            throw new Exception("Could not find any shipment results under Order Id:" + " " + Id);
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



        public Respuesta InsertShipment(Shipments shipment)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    if (shipment != null)
                    {
                        string api = "shipments/InsertShipment";
                        string route = Url + api;
                        var content = JsonContent.Create(shipment);
                        HttpResponseMessage response = client.PostAsync(route, content).Result;

                        response.EnsureSuccessStatusCode();
                        if (response.IsSuccessStatusCode)
                        {
                            var responseBody = response.Content.ReadAsAsync<Respuesta>().Result;
                            return responseBody;
                        }
                        else
                        {
                            throw new Exception("The shipment information could not be inserted");
                        }
                    }
                    else
                    {
                        throw new Exception("Please enter the information of the new shipment.");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Respuesta EditShipments(Shipments shipment)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(shipment);

                string metodo = "shipments/EditShipments";
                string route = Url + metodo;
                HttpResponseMessage respuesta = client.PutAsync(route, body).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<Respuesta>().Result;
                }

                return null;
            }
        }


        public Respuesta DeleteShipment(int Id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    if (Id != 0)
                    {
                        string api = "shipments/DeleteShipment?Id=" + Id; ;
                        string route = Url + api;
                        HttpResponseMessage response = client.GetAsync(route).Result;

                        response.EnsureSuccessStatusCode();
                        if (response.IsSuccessStatusCode)
                        {
                            var responseBody = response.Content.ReadAsAsync<Respuesta>().Result;
                            return responseBody;
                        }
                        else
                        {
                            throw new Exception("Error");
                        }
                    }
                    else
                    {
                        throw new Exception("The shipment data was not deleted");
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
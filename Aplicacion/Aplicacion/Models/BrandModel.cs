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
    public class BrandModel
    {
        string Url = ConfigurationManager.AppSettings["urlServicioProyecto"].ToString();
        public Respuesta ViewBrands()
        {

            using (var client = new HttpClient())
            {
                try
                {
                    string Route = "brands/ViewBrands";

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

        public Respuesta ViewBrandById(int Id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    if (Id >= 0)
                    {
                        string api = "brands/ViewBrandById?Id=" + Id;
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
                            throw new Exception("Could not find any brands under Id:" + " " + Id);
                        }

                    }
                    else
                    {
                        throw new Exception("The brand Id must be higher than 0");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public Respuesta InsertBrand(Brand brand)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    if (brand != null)
                    {
                        string api = "brands/InsertBrand";
                        string route = Url + api;
                        var content = JsonContent.Create(brand);
                        HttpResponseMessage response = client.PostAsync(route, content).Result;

                        response.EnsureSuccessStatusCode();
                        if (response.IsSuccessStatusCode)
                        {
                            var responseBody = response.Content.ReadAsAsync<Respuesta>().Result;
                            return responseBody;
                        }
                        else
                        {
                            throw new Exception("The brand could not be inserted");
                        }
                    }
                    else
                    {
                        throw new Exception("Please enter the information of the new brand.");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Respuesta EditBrand(Brand brand)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(brand);

                string metodo = "brands/EditBrand";
                string route = Url + metodo;
                HttpResponseMessage respuesta = client.PostAsync(route, body).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<Respuesta>().Result;
                }

                return null;
            }
        }


        public Respuesta DeleteBrand(int Id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    if (Id != 0)
                    {
                        string api = "brands/DeleteBrand?Id=" + Id; ;
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
                        throw new Exception("The brand was not deleted");
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
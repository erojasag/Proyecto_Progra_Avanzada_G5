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
    public class ProductModel
    {
        string Url = ConfigurationManager.AppSettings["urlServicioProyecto"].ToString();
        public Respuesta ViewProducts()
        {

            using(var client = new HttpClient())
            {
                try
                {
                    string Route = "products/ViewProducts";

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
                catch(Exception ex)
                {
                    throw ex;
                }

            }
        }

        public Respuesta ViewProductById(int Id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    if (Id >= 0)
                    {
                        
                        string api = "products/ViewProductById?Id=" + Id;
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
                            throw new Exception("No se encontro un producto existente bajo el Id:" + " " + Id);
                        }

                    }
                    else
                    {
                        throw new Exception("El Id del producto no puede ser 0 ni menor que 0");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public Respuesta InsertProduct(Product Product)
        {
            using(var client = new HttpClient())
            {
                try
                {
                    if(Product != null)
                    {
                        string api = "products/InsertProduct";
                        string route = Url + api;
                        var content = JsonContent.Create(Product);
                        HttpResponseMessage response = client.PostAsync(route, content).Result;

                        response.EnsureSuccessStatusCode();
                        if (response.IsSuccessStatusCode)
                        {
                            var responseBody = response.Content.ReadAsAsync<Respuesta>().Result;
                            return responseBody;
                        }
                        else
                        {
                            throw new Exception("No se inserto el producto");
                        }
                    }
                    else
                    {
                        throw new Exception("Ingrese la informacion del nuevo producto");
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Respuesta EditProduct(Product Product)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    if(Product != null)
                    {
                        string api = "products/EditProduct";
                        string route = Url + api;
                        var content = JsonContent.Create(Product);
                        HttpResponseMessage response = client.PutAsync(route, content).Result;

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
                        throw new Exception("Porfavor ingrese los datos a modificar");
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Respuesta DeleteProduct(int Id)
        {
            return null;
        }
    }
}
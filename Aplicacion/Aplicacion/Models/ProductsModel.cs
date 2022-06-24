using Aplicacion.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Models
{
    public class ProductsModel
    {
        public Respuesta ViewProducts()
        {
            using(var client = new HttpClient())
            {
                try
                {
                    string Url = System.Configuration.ConfigurationManager.AppSettings["urlServicioProyecto"].ToString();
                    string Route = "products/ViewProducts";

                    HttpResponseMessage response = client.GetAsync(Url + Route).Result;

                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = response.Content.ReadAsAsync<Respuesta>().Result; //serializacion del obj JSON a un objeto
                    }

                    return null;
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
                        string Url = System.Configuration.ConfigurationManager.AppSettings["urlServicioProyecto"].ToString();
                        string Route = "products/ViewProductById?Id=" + 2;
                        string call = Url + Route;

                        HttpResponseMessage response = client.GetAsync(Url).Result;

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
    }
}
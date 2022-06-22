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
        public void ViewProducts()
        {
            using(var client = new HttpClient())
            {
                try
                {
                    //ROUTE
                    string Url = System.Configuration.ConfigurationManager.AppSettings["urlServicioProyecto"].ToString();
                    string Route = "products/ViewProducts";

                    //I/O PARAMETERS

                    HttpResponseMessage response = client.GetAsync(Url + Route).Result;
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = response.Content.ReadAsAsync<Respuesta>().Result; //serializacion del obj JSON a un objeto
                    }

                    //return null;
                }
                catch(Exception ex)
                {
                    throw ex;
                }

            }
        }
    }
}
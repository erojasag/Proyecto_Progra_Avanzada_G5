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
        public ActionResult ViewProducts()
        {
            using(var client = new HttpClient())
            {
                //ROUTE
                string Url = System.Configuration.ConfigurationManager.AppSettings["urlServicioProyecto"].ToString();
                string Route = "products/ViewProducts";

                //I/O PARAMETERS

                HttpResponseMessage response = client.GetAsync(Url+Route).Result;
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    
                }
                return null;

            }
        }
    }
}
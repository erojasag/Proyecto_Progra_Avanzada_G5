using Aplicacion.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Aplicacion.Models
{
    public class BrandModel
    {
        string Url = ConfigurationManager.AppSettings["urlServicioProyecto"].ToString();
        public Respuesta ViewBrands()
        {
            using (var client = new HttpClient())
            {
                string Route = "brands/ViewBrands";

                HttpResponseMessage response = client.GetAsync(Url + Route).Result;

                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Respuesta>().Result;
                }
                else
                {
                    return null;
                }
            }
        }

        public Respuesta ViewBrandById(int Id)
        {
            return null;
        }

        public Respuesta InsertBrand(Brand brand)
        {
            return null;
        }

        public bool EditBrand(Brand brand)
        {
            return false;
        }

        public bool DeleteBrand(int Id)
        {
            return false;
        }
    }
}

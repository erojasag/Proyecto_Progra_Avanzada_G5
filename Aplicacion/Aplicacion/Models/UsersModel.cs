using Aplicacion.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace Aplicacion.Models
{
    public class UsersModel
    {
        readonly string Url = ConfigurationManager.AppSettings["urlServicioProyecto"].ToString();

        public Respuesta ValidateUser(Users User)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string Route = "users/ValidateUser";

                    var Body = JsonContent.Create(User);
                    HttpResponseMessage response = client.PostAsync(Url + Route, Body).Result;

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
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
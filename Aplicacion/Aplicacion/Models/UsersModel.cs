using Aplicacion.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Aplicacion.Models
{
    public class UsersModel
    {
        readonly string Url = ConfigurationManager.AppSettings["urlServicioProyecto"].ToString();
        public Respuesta ViewUsers()
        {
            return null;
        }

        public Respuesta ViewUserById(int Id)
        {
            return null;
        }

        public Respuesta InsertUser(Users User)
        {
            return null;
        }

        public Respuesta EditUser(Users User)
        {
            return null;
        }

        public Respuesta DeleteUser(int Id)
        {
            return null;
        }

        public Respuesta ValidateUser(Users User)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string Route = "users/ValidateUser";

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
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
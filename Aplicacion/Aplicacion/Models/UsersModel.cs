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
      
        public Users ValidateUser(Users User)
        {
            string Url = ConfigurationManager.AppSettings["urlServicioProyecto"];
            using (var client = new HttpClient())
            {
                try
                {
                    JsonContent body = JsonContent.Create(User);
                    string Route = "users/ValidateUser";
                    HttpResponseMessage response = client.PostAsync(Url + Route, body).Result;

                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsAsync<Users>().Result;
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

        


        public Respuesta ViewUsers()
        {
            string Url = ConfigurationManager.AppSettings["urlServicioProyecto"];
            using (var client = new HttpClient())
            {
                try
                {
                    string Route = "Users/ViewUsers";

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

        public Respuesta ViewUserById(Guid Id)
        {
            string Url = ConfigurationManager.AppSettings["urlServicioProyecto"];
            using (var client = new HttpClient())
            {
                try
                {
                        string api = "Users/ViewUserById?Id=" + Id;
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
                            throw new Exception("No se encontro un usuario existente bajo el Id:" + " " + Id);
                        }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public Respuesta UserRegistration(Users user)
        {
            string Url = ConfigurationManager.AppSettings["urlServicioProyecto"];
            using (var client = new HttpClient())
            {
                try
                {
                    if (user != null)
                    {
                        string api = "Users/UserRegistration";
                        string route = Url + api;
                        var content = JsonContent.Create(user);
                        HttpResponseMessage response = client.PostAsync(route, content).Result;

                        response.EnsureSuccessStatusCode();
                        if (response.IsSuccessStatusCode)
                        {
                            var responseBody = response.Content.ReadAsAsync<Respuesta>().Result;
                            return responseBody;
                        }
                        else
                        {
                            throw new Exception("No se inserto el usuario");
                        }
                    }
                    else
                    {
                        throw new Exception("Ingrese toda la información requerida");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Respuesta EditUser(Users user)
        {
            string Url = ConfigurationManager.AppSettings["urlServicioProyecto"];
            using (var client = new HttpClient())
            {
                try
                {
                    if (user != null)
                    {
                        string api = "Users/EditUser";
                        string route = Url + api;
                        var content = JsonContent.Create(user);
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
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Respuesta DeleteUser(Guid Id)
        {
            string Url = ConfigurationManager.AppSettings["urlServicioProyecto"];
            using (var client = new HttpClient())
            {
                try
                {
                    if (Id != null)
                    {
                        string api = "Users/DeleteUser";
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
                        throw new Exception("El usuario no existe");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Respuesta ActualizarUsuario(Users user)
        {
            string ruta = ConfigurationManager.AppSettings["urlServicioProyecto"];
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(user);

                if(user.Password != null) {
                    string routePassword = "Users/ActualizarContraseña";
                    HttpResponseMessage respuestaPassword = client.PutAsync(ruta + routePassword, body).Result;

                    return respuestaPassword.Content.ReadAsAsync<Respuesta>().Result;
                }

                string route = "Users/EditUser";
                HttpResponseMessage respuesta = client.PutAsync(ruta + route, body).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<Respuesta>().Result;
                }
                else
                {
                    return null;
                }

            }
        }
    }
}
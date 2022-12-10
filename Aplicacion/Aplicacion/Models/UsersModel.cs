using Aplicacion.Entities;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;
using System.Web.ModelBinding;
using System.Web.WebPages;

namespace Aplicacion.Models
{
    public class UsersModel
    {
        string Url = ConfigurationManager.AppSettings["urlServicioProyecto"];
        public Respuesta ValidateUser(Users User)
        {
            
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

        


        public Respuesta ViewUsers()
        {
            
            using (var client = new HttpClient())
            {
                try
                {

                    
                    string api = "Users/ViewUsers";
                    string route = Url + api;

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Token);

                    //string headers = client.DefaultRequestHeaders.Add("Authorization", "Bearer" + Token);

                    HttpResponseMessage response = client.GetAsync(route).Result;

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
            
            using (var client = new HttpClient())
            {
                try
                {
                    object sesion = new Users();
                    sesion = HttpContext.Current.Session["User"];


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

        public Respuesta ViewUserByEmail(string email)
        {
            string api = "Users/ViewUserByEmail?email=" + email;
            string route = Url + api;

            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage respuesta = client.GetAsync(route).Result;
                    if (respuesta.IsSuccessStatusCode)
                    {
                        return respuesta.Content.ReadAsAsync<Respuesta>().Result;
                    }
                    else
                    {
                        throw new Exception("error");
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Respuesta UpdatePassword(Users user)
        {
            using(var client = new HttpClient())
            {
                string api = "Users/UpdatePassword";
                string route = Url + api;
                try
                {
                    JsonContent body = JsonContent.Create(user);
                    HttpResponseMessage respuesta = client.PostAsync(route, body).Result;
                    if (respuesta.IsSuccessStatusCode)
                    {
                        return respuesta.Content.ReadAsAsync<Respuesta>().Result;
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

        public Respuesta ForgotPassword(Users user)
        {
            string api = "Users/ForgotPassword";
            string route = Url + api;

            using(var client = new HttpClient())
            {
                try
                {
                    JsonContent body = JsonContent.Create(user);

                    if (user.Email.IsEmpty())
                    {
                        return null;
                    }
                    else
                    {
                        HttpResponseMessage respuesta = client.PostAsync(route, body).Result;
                        if (respuesta.IsSuccessStatusCode)
                        {
                            return respuesta.Content.ReadAsAsync<Respuesta>().Result;
                        }
                    }

                    return null;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }

        }

        public Respuesta ActivateAccount(Guid activationCode)
        {
            string api = "Users/ActivateAccount?activationCode=" + activationCode;
            string route = Url + api;

            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage respuesta = client.GetAsync(route).Result;
                    if (respuesta.IsSuccessStatusCode)
                    {
                        return respuesta.Content.ReadAsAsync<Respuesta>().Result;
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

        public Respuesta EditUser(Users user)
        {
            
     
            using (var client = new HttpClient())
            {
                try
                {
                    
                    JsonContent body = JsonContent.Create(user);

                    if (user != null && (user.newPassword == null && user.newPassword2 == null))
                    {

                        string api = "Users/EditUser";
                        string route = Url + api;
                        HttpResponseMessage respuesta = client.PostAsync(route, body).Result;
                        if (respuesta.IsSuccessStatusCode)
                        {
                            return respuesta.Content.ReadAsAsync<Respuesta>().Result;
                        }

                    }
                    else if (user != null && (user.newPassword != null && user.newPassword2 != null))
                    {
                        string api = "Users/UpdatePassword";
                        string route = Url + api;

                        HttpResponseMessage respuesta = client.PostAsync(route, body).Result;


                        return respuesta.Content.ReadAsAsync<Respuesta>().Result;

                    }
                    else
                    {
                        return null;
                    }

                    throw new Exception("El usuario no existe");


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Respuesta DeleteUser(Guid Id)
        {
            
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

    }
}
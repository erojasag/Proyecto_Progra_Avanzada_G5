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
    public class PersonsModel
    {
        readonly string Url = ConfigurationManager.AppSettings["urlServicioProyecto"].ToString();

        public Respuesta ViewPersonsWithUsers()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string Route = "persons/ViewPersonsWithUsers";

                    HttpResponseMessage response = client.GetAsync(Url + Route).Result;

                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = response.Content.ReadAsAsync<Respuesta>().Result;//serializacion del obj JSON a un objeto
                        return responseBody;
                    }
                    else
                    {
                        throw new Exception("El usuario no se encontro");
                    }


                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
        public Respuesta CheckPersonAndUserById(int Id)
        {
            using(var client = new HttpClient())
            {
                try
                {
                    string Route = "persons/CheckPersonAndUserById";

                    HttpResponseMessage response = client.GetAsync(Url + Route).Result;

                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = response.Content.ReadAsAsync<Respuesta>().Result;
                        return responseBody;
                    }
                    else
                    {
                        throw new Exception("El usuario no se encontro");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Respuesta CheckPersonById(int Id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string Route = "persons/CheckPersonById";
                    HttpResponseMessage response = client.GetAsync(Url + Route).Result;

                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = response.Content.ReadAsAsync<Respuesta>().Result;
                        return responseBody;
                    }
                    else
                    {
                        throw new Exception("El usuario no se encontro");
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Respuesta InsertPersonWithUser(UserPerson UserPerson)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string api = "persons/InsertPersonWithUser";
                    string Route = Url + api;
                    var content = JsonContent.Create(UserPerson);
                    HttpResponseMessage response = client.PostAsync(Route, content).Result;

                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = response.Content.ReadAsAsync<Respuesta>().Result;//serializacion del obj JSON a un objeto
                        return responseBody;
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

        //Edit UserPerson
        public Respuesta EditUserPerson(UserPerson UserPerson)
        {
            return null;
        }


        /*public bool DeletePerson(int Id)
        {
            
        }*/

        public Respuesta DeletePersonAndUserById(int Id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string api = "persons/DeletePersonAndUserById";
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
                        throw new Exception("El usuario no se encontro");
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
using Servicio.Entities;
using Servicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Servicio.Controllers
{
    public class UsersController : ApiController
    {
        readonly Respuesta respuesta = new Respuesta();
        readonly UsersModel model = new UsersModel();


        //GET List of Users
        [HttpGet]
        [Route("Users/ViewUsers")]

        public Respuesta ViewUsers()
        {
            try
            {
                return respuesta.ArmarRespuestaUsers(0, "OK", false, null, model.ViewUsers());
            }
            catch(Exception ex)
            {
                return respuesta.ArmarRespuestaUsers(-1, ex.Message, false, null, null);
            }
        }

        //GET User by Id
        [HttpGet]
        [Route("Users/ViewUserById")]
        public Respuesta ViewUserById(int Id)
        {
            try
            {
                return respuesta.ArmarRespuestaUsers(0, "OK", false, model.ViewUserById(Id), null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaUsers(-1, ex.Message, false, null, null);
            }
        }

        //POST Insert User
        [HttpPost]
        [Route("users/InsertUser")]
        public Respuesta InsertUser(Users User)
        {
            try
            {
                return respuesta.ArmarRespuestaUsers(0, "OK", model.InsertUser(User), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaUsers(-1, ex.Message, false, null, null);
            }
        }

        //PUT Edit User By Id
        [HttpPut]
        [Route("users/EditUser")]
        public Respuesta EditUser(Users User)
        {
            try
            {
                return respuesta.ArmarRespuestaUsers(0, "OK", model.EditUser(User), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaUsers(-1, ex.Message, false, null, null);
            }
        }

        //DELETE Delete User By Id
        [HttpDelete]
        [Route("users/DeleteUser")]
        public Respuesta DeleteUser(int Id)
        {
            try
            {
                return respuesta.ArmarRespuestaUsers(0, "OK", model.DeleteUser(Id), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaUsers(-1, ex.Message, false, null, null);
            }
        }
    }
}

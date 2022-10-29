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

        [HttpPost]
        [Route("Users/ValidateUser")]
        public Usuario ValidateUser(Usuario User)
        {

            return model.ValidateUser(User);
        }

        [HttpGet]
        [Route("Users/ViewUsers")]
        public Respuesta ViewUsers()
        {
            try
            {
                return respuesta.ArmarRespuestaUsers(1, "OK", false, null, model.ViewUsers());
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaUsers(-1, ex.Message, false, null, null);
            }
        }

        [HttpGet]
        [Route("Users/ViewUserById")]
        public Respuesta ViewUserById(Guid Id)
        {
            try
            {
                return respuesta.ArmarRespuestaUsers(1, "OK", false, model.ViewUserById(Id), null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaUsers(-1, ex.Message, false, null, null);
            }
        }

        [HttpPost]
        [Route("Users/UserRegistration")]
        public Respuesta InsertUser(Usuario user)
        {
            try
            {
                return respuesta.ArmarRespuestaUsers(1, "OK", model.InsertUser(user), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaUsers(-1, ex.Message, false, null, null);
            }
        }

        [HttpPut]
        [Route("Users/EditUser")]
        public Respuesta EditUser(Usuario user)
        {
            try
            {
                return respuesta.ArmarRespuestaUsers(1, "OK", model.EditUser(user), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaUsers(-1, ex.Message, false, null, null);
            }
        }

        [HttpDelete]
        [Route("Users/DeleteUser")]
        public Respuesta DeleteUser(Guid Id)
        {
            try
            {
                return respuesta.ArmarRespuestaUsers(1, "OK", model.DeleteUser(Id), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaUsers(-1, ex.Message, false, null, null);
            }
        }

        //ACTUALIZAR CONTRASEÑA
        [HttpPut]
        [Route("Users/ActualizarContraseña")]
        public string ActualizarContraseña(Usuario obj)
        {
            try
            {
                return model.ActualizarContraseña(obj);
            }
            catch (Exception ex)
            {
                return "Error al Cambiar Contraseña";
            }
        }

    }
}

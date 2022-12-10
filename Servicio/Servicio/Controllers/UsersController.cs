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
        public Respuesta ValidateUser(Users User)
        {
            try
            {
                return respuesta.ArmarRespuestaUsers(1, "OK", true, model.ValidateUser(User), null);
            }
            catch(Exception ex)
            {
                return respuesta.ArmarRespuestaUsers(0, ex.Message, false, model.ValidateUser(User), null);
            }

            
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
        public Respuesta UserRegistration(Users user)
        {
            try
            {
                return respuesta.ArmarRespuestaUsers(1, "OK", model.UserRegistration(user), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaUsers(-1, ex.Message, false, null, null);
            }
        }

        [HttpGet]
        [Route("Users/ActivateAccount")]
        public Respuesta ActivateAccount(Guid activationCode)
        {
            try
            {
                return respuesta.ArmarRespuestaUsers(1, "OK", model.ActivateAccount(activationCode), null, null);
            }
            catch(Exception ex)
            {
                return respuesta.ArmarRespuestaUsers(0, ex.Message, false, null, null);
            }
        }

        [HttpPost]
        [Route("Users/EditUser")]
        public Respuesta EditUser(Users user)
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


        [HttpGet]
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
        [HttpPost]
        [Route("Users/UpdatePassword")]
        public Respuesta UpdatePassword(Users user)
        {
            try
            {
                return respuesta.ArmarRespuestaUsers(1, "OK",model.UpdatePassword(user), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaUsers(0, ex.Message, model.UpdatePassword(user), null, null);
            }
        }

        [HttpPost]
        [Route("Users/ForgotPassword")]
        public Respuesta ForgotPassword(Users user)
        {
            try
            {
                return respuesta.ArmarRespuestaUsers(1, "OK", model.ForgotPassword(user), null, null);

            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaUsers(0, ex.Message, false, null, null);
            }
        }

        [HttpGet]
        [Route("Users/ViewUserByEmail")]
        public Respuesta ViewUserByEmail(string email)
        {
            try
            {
                return respuesta.ArmarRespuestaUsers(1, "OK", model.ViewUserByEmail(email), null, null);
            }
            catch(Exception ex)
            {
                return respuesta.ArmarRespuestaUsers(0, ex.Message, false, null, null);
            }
        }

    }
}

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
        [Route("users/ValidateUser")]
        public Respuesta ValidateUser(Users User)
        {
            try
            {
                return respuesta.ArmarRespuestaUsers(1, "OK", true, model.ValidateUser(User), null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaUserPerson(-1, ex.Message, false, null, null);
            }
        }
    }
}

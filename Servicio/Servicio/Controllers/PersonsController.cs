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
    public class PersonsController : ApiController
    {

        readonly Respuesta respuesta = new Respuesta();
        readonly PersonsModel model = new PersonsModel();

        [HttpGet]
        [Route("persons/ViewPersons")]
        public Respuesta ViewPersons()
        {
            try
            {
                return null;
            }
            catch(Exception ex)
            {
                return respuesta.ArmarRespuestaPersons(-1, ex.Message, false, null, null);
            }
        }

        [HttpGet]
        [Route("persons/ViewPersonById")]
        public Respuesta ViewPersonById()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaPersons(-1, ex.Message, false, null, null);
            }
        }

        [HttpPost]
        [Route("persons/InsertPerson")]
        public Respuesta InsertPerson()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaPersons(-1, ex.Message, false, null, null);
            }
        }
        [HttpPut]
        [Route("persons/EditPerson")]
        public Respuesta EditPerson()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaPersons(-1, ex.Message, false, null, null);
            }
        }

        [HttpDelete]
        [Route("persons/DeletePerson")]
        public Respuesta DeletePerson()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaPersons(-1, ex.Message, false, null, null);
            }
        }

    }
}

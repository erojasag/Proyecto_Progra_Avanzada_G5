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
        [Route("person/ViewPersons")]
        public Respuesta ViewPersons()
        {
            try
            {
                return respuesta.ArmarRespuestaPerson(1, "OK", false, null, model.viewPersons());
            }
            catch(Exception ex)
            {
                return respuesta.ArmarRespuestaPerson(-1, ex.Message, false, null, null);
            }
        }

        [HttpGet]
        [Route("person/ViewPersonById")]
        public Respuesta ViewPersonById(int Id)
        {
            try
            {
                return respuesta.ArmarRespuestaPerson(1, "OK", true, model.ViewPersonById(Id), null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaPerson(-1, ex.Message, false, null, null);
            }
        }

        [HttpGet]
        [Route("person/ViewPersonsWithUsers")]
        public Respuesta ViewPersonsWithUsers()
        {
            try
            {
                return respuesta.ArmarRespuestaUserPerson(1, "OK", true, null, model.ViewPersonsWithUsers());
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaUserPerson(-1, ex.Message, false, null, null);
            }
        }

        [HttpGet]
        [Route("person/CheckPersonAndUserById")]
        public Respuesta CheckPersonAndUserById(int Id)
        {
            try
            {
                return respuesta.ArmarRespuestaUserPerson(1, "OK", true, model.CheckPersonAndUserById(Id), null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaPerson(-1, ex.Message, false, null, null);
            }
        }

        [HttpPost]
        [Route("persons/InsertPerson")]
        public Respuesta InsertPerson(Person Person)
        {
            try
            {
                return respuesta.ArmarRespuestaPerson(1, "OK", model.InsertPerson(Person), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaPerson(-1, ex.Message, false, null, null);
            }
        }


        [HttpPost]
        [Route("Person/InsertPersonWithUser")]
        public Respuesta InsertPersonWithUser(UserPerson UserPerson)
        {
            try
            {
                return respuesta.ArmarRespuestaPerson(1, "OK", model.InsertPersonWithUser(UserPerson), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaPerson(-1, ex.Message, false, null, null);
            }
        }


        [HttpPut]
        [Route("persons/EditPerson")]
        public Respuesta EditPerson(Person Person)
        {
            try
            {
                return respuesta.ArmarRespuestaPerson(1, "OK", model.EditPerson(Person), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaPerson(-1, ex.Message, false, null, null);
            }
        }

        [HttpPut]
        [Route("persons/EditUserPerson")]
        public Respuesta EditUserPerson(UserPerson UserPerson)
        {
            try
            {
                return respuesta.ArmarRespuestaUserPerson(1, "OK", model.EditUserPerson(UserPerson), null, null);
            }
            catch(Exception ex)
            {
                return respuesta.ArmarRespuestaUserPerson(-1, ex.Message, false, null, null);
            }
        }

        [HttpDelete]
        [Route("persons/DeletePerson")]
        public Respuesta DeletePerson(int Id)
        {
            try
            {
                return respuesta.ArmarRespuestaPerson(1, "OK", model.DeletePerson(Id), null, null);
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaPerson(-1, ex.Message, false, null, null);
            }
        }

        [HttpDelete]
        [Route("persons/DeletePersonAndUserById")]
        public Respuesta DeletePersonAndUserById(int Id)
        {
            try
            {
                return respuesta.ArmarRespuestaUserPerson(1, "OK", model.DeletePersonAndUserById(Id), null, null); ;
            }
            catch (Exception ex)
            {
                return respuesta.ArmarRespuestaPerson(-1, ex.Message, false, null, null);
            }
        }

    }
}

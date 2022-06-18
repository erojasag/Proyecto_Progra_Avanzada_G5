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
    public class EmployeeController : ApiController
    {
        readonly EmployeeModel model = new EmployeeModel();
 

        [HttpGet]
        [Route("employee/ViewEmployees")]
        public Respuesta ViewEmployees()
        {
            try
            {
                return model.ArmarRespuesta(0, "OK", false, null, model.ViewEmployees());

            }
            catch (Exception ex)
            {
                return model.ArmarRespuesta(-1, ex.Message, false, null, null);
            }
        }

        [HttpGet]
        [Route("employee/ViewEmployeeById")]
        public Respuesta ViewEmployeeById(int User_Id)
        {
            try
            {
                return model.ArmarRespuesta(0, "OK", false, model.ViewEmployee(User_Id), null);

            }
            catch (Exception ex)
            {
                return model.ArmarRespuesta(-1, ex.Message, false, null, null);
            }
        }

        [HttpPost]
        [Route("employee/InsertEmployee")]
        public Respuesta InsertEmployee(Employee employee)
        {
            try
            {
                return model.ArmarRespuesta(0, "OK", model.InsertEmployee(employee), null, null);

            }
            catch (Exception ex)
            {
                return model.ArmarRespuesta(-1, ex.Message, false, null, null);
            }
        }

        [HttpPut]
        [Route("employee/UpdateEmployee")]
        public Respuesta UpdateEmployee(Employee employee)
        {
            try
            {
                return model.ArmarRespuesta(0, "OK", model.UpdateEmployee(employee), null, null);

            }
            catch (Exception ex)
            {
                return model.ArmarRespuesta(-1, ex.Message, false, null, null);
            }
        }

        [HttpDelete]
        [Route("employee/DeleteEmployee")]
        public Respuesta DeleteEmployee(int User_Id)
        {
            try
            {
                return model.ArmarRespuesta(0, "OK", model.DeleteEmployee(User_Id), null, null);

            }
            catch (Exception ex)
            {
                return model.ArmarRespuesta(-1, ex.Message, false, null, null);
            }
        }

        //Modulo de cambio de password
        [HttpPut]
        [Route("employee/ChangePassword")]

        public Respuesta ChangePassword(string User_name, string Old_Password, String New_Password)
        {
            try
            {
                return model.ArmarRespuesta(0, "OK", model.ChangePassword(User_name, Old_Password, New_Password), null, null);
            }catch(Exception ex)
            {
                return model.ArmarRespuesta(-1, ex.Message, false, null, null);
            }
        }


    }
}

using Servicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Models
{
    public class EmployeeModel
    {
        readonly Respuesta respuesta = new Respuesta();
        public List<Employee> ViewEmployees()
        {
            using (var connection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                   
                    var getEmployees = connection.Employee.ToList();
                    List<Employee> tEmployees = new List<Employee>();
                    foreach (var employee in getEmployees)
                    {
                        tEmployees.Add(new Employee
                        {
                            User_Id = employee.User_Id,
                            User_name = employee.User_name,
                            Password = employee.Password,
                            Name = employee.Name,
                            First_last_name = employee.First_last_name,
                            Second_last_name = employee.Second_last_name,
                            Id = employee.Id,
                            Phone = employee.Phone,
                            Email = employee.Email,
                            Hire_date = employee.Hire_date,
                            Birth_date = employee.Birth_date
                        });
                    }
                    return tEmployees;
                   

                }
                catch (Exception ex)
                {
                    connection.Dispose();
                    throw ex;
                }
            }
        }

        public Employee ViewEmployee(int User_Id)
        {
            using (var connection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    Employee tEmployee = new Employee();
                    var getEmployee = connection.Employee.Find(User_Id);
                    tEmployee.User_Id = getEmployee.User_Id;
                    tEmployee.User_name = getEmployee.User_name;
                    tEmployee.Name = getEmployee.Name;
                    tEmployee.First_last_name = getEmployee.First_last_name;
                    tEmployee.Second_last_name = getEmployee.Second_last_name;
                    tEmployee.Id = getEmployee.Id;
                    tEmployee.Phone = getEmployee.Phone;
                    tEmployee.Email = getEmployee.Email;
                    tEmployee.Hire_date = getEmployee.Hire_date;
                    tEmployee.Birth_date = getEmployee.Birth_date;
 
                    return tEmployee;
                }
                catch (Exception ex)
                {
                    connection.Dispose();
                    throw ex;
                }

            }
        }

        public bool InsertEmployee(Employee employee)
        {
            using (var connection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    if (employee != null)
                    {
                        Employee tEmployee = new Employee();
                        tEmployee.User_Id = employee.User_Id;
                        tEmployee.User_name = employee.User_name;
                        tEmployee.Password = employee.Password;
                        tEmployee.Name = employee.Name;
                        tEmployee.First_last_name = employee.First_last_name;
                        tEmployee.Second_last_name = employee.Second_last_name;
                        tEmployee.Id = employee.Id;
                        tEmployee.Phone = employee.Phone;
                        tEmployee.Email = employee.Email;
                        tEmployee.Hire_date = DateTime.Now;
                        tEmployee.Birth_date = employee.Birth_date;
                        connection.Employee.Add(tEmployee);
                        connection.SaveChanges();

                        return true;
                        
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    connection.Dispose();
                    throw ex;
                }
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            using (var connection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var data = connection.Employee.Find(employee.User_Id);
                    if (data != null)
                    {
                        data.User_name = employee.User_name;
                        data.Password = employee.Password;
                        data.Name = employee.Name;
                        data.First_last_name = employee.First_last_name;
                        data.Second_last_name= employee.Second_last_name;
                        data.Id = employee.Id;
                        data.Phone = employee.Phone;
                        data.Email = employee.Email;
                        connection.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("El Empleado a actualizar no se encontro");
                    }
                }
                catch (Exception ex)
                {
                    connection.Dispose();
                    throw ex;
                }
            }
        }

        public bool DeleteEmployee(int User_Id)
        {
            using (var connection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var getEmployee = connection.Employee.Find(User_Id);
                    if (getEmployee != null)
                    {
                        connection.Employee.Remove(getEmployee);
                        connection.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("El Empleado no se encontro");
                    }
                }
                catch (Exception ex)
                {
                    connection.Dispose();
                    throw ex;
                }

            }
        }

        public bool ChangePassword(string User_name, string Old_Password, string New_Password)
        {
            using(var connection = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    connection.Change_Employee_Password(User_name, Old_Password, New_Password);
                    connection.SaveChanges();
                    return true;

                }catch (Exception ex)
                {
                    connection.Dispose();
                    throw ex;
                }
            }

        }



        public Respuesta ArmarRespuesta(int Id, string Message, bool transaccion, Employee employee
            , List<Employee> employees)
        {

            respuesta.Id = 0;
            respuesta.Message = "OK";
            respuesta.transaccion = transaccion;
            respuesta.employees = employees;
            respuesta.employee = employee;

            return respuesta;

        }
    }
}

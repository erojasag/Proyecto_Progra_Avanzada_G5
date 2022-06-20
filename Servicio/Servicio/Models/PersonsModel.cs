using Servicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Models
{
    public class PersonsModel
    {
        public List<Persons> viewPersons()
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tPersons = db.Persons.ToList();
                    List<Persons> persons = new List<Persons>();
                    if (tPersons.Count != 0)
                    {
                        foreach (var tPerson in tPersons)
                        {
                            persons.Add(new Persons
                            {
                                Name = tPerson.Name,
                                First_last_name = tPerson.First_last_name,
                                Second_last_name = tPerson.Second_last_name,
                                Identification = tPerson.Identification,
                                Phone = tPerson.Phone,
                                Email = tPerson.Email,
                                Registration_date = DateTime.Now,
                                Birth_date = new DateTime(),
                                Address = tPerson.Address
                            });
                        }
                    }
                    else
                    {
                        throw new Exception("No existen usuarios");
                    }
                  
                    return persons;
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public Persons ViewPersonById(int Id)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tPerson = db.Persons.Find(Id);
                    Persons Person = new Persons();
                    if (tPerson != null)
                    {
                        Person.Name = tPerson.Name;
                        Person.First_last_name = tPerson.First_last_name;
                        Person.Second_last_name = tPerson.Second_last_name;
                        Person.Identification = tPerson.Identification;
                        Person.Phone = tPerson.Phone;
                        Person.Email = tPerson.Email;
                        Person.Registration_date = DateTime.Now;
                        Person.Birth_date = new DateTime();
                        Person.Address = tPerson.Address;
                    }
                    return Person;
                }
                catch(Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public bool InsertPerson(Persons Person, Users User)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    if (Person != null && User != null)
                    {
                        Persons tPerson = new Persons();
                        tPerson.Name = Person.Name;
                        tPerson.First_last_name = Person.First_last_name;
                        tPerson.Second_last_name = Person.Second_last_name;
                        tPerson.Identification = Person.Identification;
                        tPerson.Phone = Person.Phone;
                        tPerson.Email = Person.Email;
                        tPerson.Registration_date = DateTime.Now;
                        tPerson.Birth_date = new DateTime();
                        tPerson.Address = Person.Address;


                        UsersModel model = new UsersModel();
                        Users tUser = new Users();

                        tUser.Username = User.Username;
                        tUser.Password = User.Password;
                        tUser.User_type = User.User_type;
                        tUser.Photo = User.Photo;

                        model.InsertUser(tUser);
                    }
                    return true;
                }
                catch(Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }
    }
}
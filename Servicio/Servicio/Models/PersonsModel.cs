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

        public bool InsertPerson(Persons Person)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    if (Person != null)
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
                        tPerson.Users = Person.Users;

                        


                    }
                    if (Person.Users == null)
                    {
                        UsersModel model = new UsersModel();
                        model.InsertUser(new Users
                        {
                            
                        });
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

        public bool InsertPersonWithUser(UserPerson UserPerson)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    
                    if (UserPerson != null)
                    {
                        Persons tPerson = new Persons();
                        Users user = new Users();
                        tPerson.Name = UserPerson.Person.Name;
                        tPerson.First_last_name = UserPerson.Person.First_last_name;
                        tPerson.Second_last_name = UserPerson.Person.Second_last_name;
                        tPerson.Identification = UserPerson.Person.Identification;
                        tPerson.Phone = UserPerson.Person.Phone;
                        tPerson.Email = UserPerson.Person.Email;
                        tPerson.Registration_date = DateTime.Now;
                        tPerson.Birth_date = UserPerson.Person.Birth_date;
                        tPerson.Address = UserPerson.Person.Address;
                        user.Username = UserPerson.User.Username;
                        user.Password = UserPerson.User.Password;
                        user.User_type = UserPerson.User.User_type;
                        user.Id = UserPerson.Person.Id;
                        db.Persons.Add(tPerson);
                        db.Users.Add(user);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("Faltan parametros");
                    }
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

    }
}
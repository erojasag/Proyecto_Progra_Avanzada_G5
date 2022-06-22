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
                                Id = tPerson.Id,
                                Name = tPerson.Name,
                                First_last_name = tPerson.First_last_name,
                                Second_last_name = tPerson.Second_last_name,
                                Identification = tPerson.Identification,
                                Phone = tPerson.Phone,
                                Email = tPerson.Email,
                                Registration_date = DateTime.Now,
                                Birth_date = new DateTime(),
                                Address = tPerson.Address,
                                User_Id = tPerson.User_Id,
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
        public UserPerson CheckPersonAndUserById(int Id)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tperson = db.Persons.Find(Id);
                    var tuser = db.Users.Find(Id);
                    UserPerson UserPerson = new UserPerson();

                    if (tuser != null && tperson != null)
                    {
                        Persons person = new Persons();
                        Users user = new Users();
                        person.Id = tperson.Id;
                        person.Name = tperson.Name;
                        person.First_last_name = tperson.First_last_name;
                        person.Second_last_name = tperson.Second_last_name;
                        person.Phone = tperson.Phone;
                        person.Registration_date = tperson.Registration_date;
                        person.Birth_date = tperson.Birth_date;
                        person.Address = tperson.Address;

                        user.Username = tuser.Username;
                        user.User_type = tuser.User_type;

                        UserPerson.Person = person;
                        UserPerson.User = user;
                    }

                    return UserPerson;
                }
                catch (Exception ex)
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
                        user.Username = UserPerson.User.Username;
                        user.Password = UserPerson.User.Password;
                        user.User_type = UserPerson.User.User_type;
                        db.Users.Add(user);
                        db.SaveChanges();

                        var u = db.Users.FirstOrDefault();

                        tPerson.Name = UserPerson.Person.Name;
                        tPerson.First_last_name = UserPerson.Person.First_last_name;
                        tPerson.Second_last_name = UserPerson.Person.Second_last_name;
                        tPerson.Identification = UserPerson.Person.Identification;
                        tPerson.Phone = UserPerson.Person.Phone;
                        tPerson.Email = UserPerson.Person.Email;
                        tPerson.Registration_date = DateTime.Now;
                        tPerson.Birth_date = UserPerson.Person.Birth_date;
                        tPerson.Address = UserPerson.Person.Address;
                        tPerson.User_Id = u.Id;
                        db.Persons.Add(tPerson);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("El nombre de usuario que intenta registrar ya existe");
                    }
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public bool EditPerson(Persons Person)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tperson = db.Persons.Find(Person.Id);
                    if (tperson != null)
                    {
                        tperson.Id = Person.Id;
                        if (Person.Name != null)
                        {
                            tperson.Name = Person.Name;
                            tperson.Modification_date = DateTime.Now;
                        }
                        if (Person.First_last_name != null)
                        {
                            tperson.First_last_name = Person.First_last_name;
                            tperson.Modification_date = DateTime.Now;
                        }
                        if (Person.Second_last_name != null)
                        {
                            tperson.Second_last_name = Person.Second_last_name;
                            tperson.Modification_date = DateTime.Now;
                        }
                        if (Person.Phone != null)
                        {
                            tperson.Phone = Person.Phone;
                            tperson.Modification_date = DateTime.Now;
                        }
                        if (Person.Email != null)
                        {
                            tperson.Email = Person.Email;
                            tperson.Modification_date = DateTime.Now;
                        }
                        if (Person.Birth_date != null)
                        {
                            tperson.Birth_date = Person.Birth_date;
                            tperson.Modification_date = DateTime.Now;
                        }
                        if (Person.Address != null)
                        {
                            tperson.Address = Person.Address;
                            tperson.Modification_date = DateTime.Now;
                        }
                        db.SaveChanges();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        

        public bool DeletePerson(int Id)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tperson = db.Persons.Find(Id);

                    if (tperson != null)
                    {
                        db.Persons.Remove(tperson);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("El usuario no se pudo eliminar");
                    }

                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public bool DeletePersonAndUser(int Id)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tperson = db.Persons.Find(Id);

                    if (tperson != null)
                    {
                        db.Persons.Remove(tperson);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("El usuario no se pudo eliminar");
                    }

                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }




        //DeletePersonAndUserById()

    }
}
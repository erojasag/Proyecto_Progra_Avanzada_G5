using Servicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Models
{
    public class PersonsModel
    {
        public List<Person> viewPersons()
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tPersons = db.Person.ToList();
                    List<Person> persons = new List<Person>();
                    if (tPersons.Count != 0)
                    {
                        foreach (var tPerson in tPersons)
                        {
                            persons.Add(new Person
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

        public Person ViewPersonById(int Id)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tPerson = db.Person.Find(Id);
                    Person Person = new Person();
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

        public List<UserPerson> ViewPersonsWithUsers()
        {
            using(var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    List<UserPerson> PersonUserList = new List<UserPerson>();

                    var tUsers = db.Users.ToList();
                    var tPersons = db.Person.ToList();

                    if (tUsers != null && tPersons != null)
                    {
                        Users user = new Users();
                        Person person = new Person();
                        foreach (var tUser in tUsers)
                        {
                            user.Id = tUser.Id;   
                            user.Username = tUser.Username;
                            user.User_type = tUser.User_type;

                        }
                        foreach (var tPerson in tPersons)
                        {
                            person.User_Id = tPerson.User_Id;
                            person.Name = tPerson.Name;
                            person.First_last_name = tPerson.First_last_name;
                            person.Second_last_name = tPerson.Second_last_name;
                            person.Identification = tPerson.Identification;
                            person.Phone = tPerson.Phone;
                            person.Email = tPerson.Email;
                            person.Birth_date = tPerson.Birth_date;
                            person.Address = tPerson.Address;
                            person.Registration_date = tPerson.Registration_date;
                        }
                        PersonUserList.Add(new UserPerson
                        {
                            Person = person,
                            User = user
                        });
                    }
                    else
                    {
                        throw new Exception("No existen usuarios");
                    }
                    return PersonUserList;
                }
                catch (Exception ex)
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
                    var tperson = db.Person.Find(Id);
                    var tuser = db.Users.Find(Id);
                    UserPerson UserPerson = new UserPerson();

                    if (tuser != null && tperson != null)
                    {
                        Person person = new Person();
                        Users user = new Users();
                        person.Id = tperson.Id;
                        person.Name = tperson.Name;
                        person.First_last_name = tperson.First_last_name;
                        person.Second_last_name = tperson.Second_last_name;
                        person.Identification = tperson.Identification;
                        person.Phone = tperson.Phone;
                        person.Email = tperson.Email;
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


        public bool InsertPerson(Person Person)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    if (Person != null)
                    {
                        Person tPerson = new Person();
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
                        Person tPerson = new Person();
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
                        db.Person.Add(tPerson);
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

        public bool EditPerson(Person Person)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tperson = db.Person.Find(Person.Id);
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

        //Edit UserPerson
        public bool EditUserPerson(UserPerson UserPerson)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var Id = UserPerson.User.Id;
                    var tUser = db.Users.Find(Id);
                    var tPerson = db.Person.Find(Id);

                    if (tUser != null)
                    {
                        if (tPerson.Name != UserPerson.Person.Name)
                        {
                            tPerson.Name = UserPerson.Person.Name;
                            tPerson.Modification_date = DateTime.Now;
                        }
                        if (tPerson.First_last_name != UserPerson.Person.First_last_name)
                        {
                            tPerson.First_last_name = UserPerson.Person.First_last_name;
                            tPerson.Modification_date = DateTime.Now;
                        }
                        if (tPerson.Second_last_name != UserPerson.Person.Second_last_name)
                        {
                            tPerson.Second_last_name = UserPerson.Person.Second_last_name;
                            tPerson.Modification_date = DateTime.Now;
                        }
                        if (tPerson.Phone != UserPerson.Person.Phone)
                        {
                            tPerson.Phone= UserPerson.Person.Phone;
                            tPerson.Modification_date = DateTime.Now;
                        }
                        if (tPerson.Email != UserPerson.Person.Email)
                        {
                            tPerson.Email = UserPerson.Person.Email;
                            tPerson.Modification_date = DateTime.Now;
                        }
                        if (tPerson.Address != UserPerson.Person.Address)
                        {
                            tPerson.Address = UserPerson.Person.Address;
                            tPerson.Modification_date = DateTime.Now;
                        }
                        if (tUser.Username != UserPerson.User.Username)
                        {
                            tUser.Username = UserPerson.User.Username;
                        }
                        if (tUser.Password != UserPerson.User.Password)
                        {
                            tUser.Password = UserPerson.User.Password;
                        }

                        db.SaveChanges();
                        
                        return true;
                    }
                    else
                    {
                        throw new Exception("No se pudo editar el usuario");
                    }

                }
                catch(Exception ex)
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
                    var tperson = db.Person.Find(Id);

                    if (tperson != null)
                    {
                        db.Person.Remove(tperson);
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

        public bool DeletePersonAndUserById(int Id)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tperson = db.Person.Find(Id);

                    

                    if (tperson != null)
                    {
                        var tuser = db.Users.Find(tperson.User_Id);
                        if (tuser != null)
                        {
                            db.Person.Remove(tperson);
                            db.Users.Remove(tuser);
                            db.SaveChanges();
                        }

                        return true;
                    }
                    else
                    {
                        throw new Exception("El usuario no existe");
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
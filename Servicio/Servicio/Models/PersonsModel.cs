using Servicio.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Servicio.Models
{
    public class PersonsModel
    {
        public List<Person> ViewPersons()
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
                                Email_Verification = tPerson.Email_Verification
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


        public List<UserPerson> ViewPersonsWithUsers()
        {
            using(var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tPersons = db.Person.ToList();
                    List<UserPerson> PersonUserList = new List<UserPerson>();
                    if (tPersons != null)
                    {
                        foreach (var tPerson in tPersons)
                        {
                            Person person = new Person();
                            person.User_Id = tPerson.User_Id;
                            person.Id = tPerson.Id;
                            person.Name = tPerson.Name;
                            person.First_last_name = tPerson.First_last_name;
                            person.Second_last_name = tPerson.Second_last_name;
                            person.Identification = tPerson.Identification;
                            person.Phone = tPerson.Phone;
                            person.Email = tPerson.Email;
                            person.Birth_date = tPerson.Birth_date;
                            person.Address = tPerson.Address;
                            person.Registration_date = tPerson.Registration_date;
                            person.Email_Verification = tPerson.Email_Verification;

                            var tUser = db.Users.Find(tPerson.User_Id);
                            Users user = new Users();
                            user.Id = tUser.Id;
                            user.Username = tUser.Username;
                            user.User_Role = tUser.User_Role;
                            PersonUserList.Add(new UserPerson
                            {
                                User = user,
                                Person = person
                            });
                        }
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
                        person.Email_Verification = tperson.Email_Verification;

                        user.Username = tuser.Username;
                        user.User_Role = tuser.User_Role;

                        UserPerson.Person = person;
                        UserPerson.User = user;
                    }
                    else
                    {
                        throw new Exception("El usuario ID:" + Id + " " + "no existe");
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
                        user.User_Role = UserPerson.User.User_Role;
                        db.Users.Add(user);
                        tPerson.Name = UserPerson.Person.Name;
                        tPerson.First_last_name = UserPerson.Person.First_last_name;
                        tPerson.Second_last_name = UserPerson.Person.Second_last_name;
                        tPerson.Identification = UserPerson.Person.Identification;
                        tPerson.Phone = UserPerson.Person.Phone;
                        tPerson.Email = UserPerson.Person.Email;
                        tPerson.Registration_date = DateTime.Now;
                        tPerson.Birth_date = UserPerson.Person.Birth_date;
                        tPerson.Address = UserPerson.Person.Address;
                        tPerson.User_Id = user.Id;
                        tPerson.Email_Verification = false;
                        tPerson.Activation_Code = Guid.NewGuid();
                        db.Person.Add(tPerson);
                        int i = db.SaveChanges();

                        if(i > 0)
                        {
                            EmailModel email = new EmailModel();
                            email.SendVerificationLinkEmail(tPerson.Email, tPerson.Activation_Code.ToString());
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                    
                }
                catch (Exception)
                {
                    db.Dispose();
                    throw new Exception("Ya existe un usuario con los paremetros username, identification o email");
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

                    
                    //guardar el role
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
                        try
                        {
                            if (tPerson.Email != UserPerson.Person.Email)
                            {
                                tPerson.Email = UserPerson.Person.Email;
                                tPerson.Modification_date = DateTime.Now;
                            }
                        }
                        catch (Exception) 
                        {
                            throw new Exception("El correo que desea ingresar se encuentra asociado a otra cuenta");
                        }
                        
                        if (tPerson.Address != UserPerson.Person.Address)
                        {
                            tPerson.Address = UserPerson.Person.Address;
                            tPerson.Modification_date = DateTime.Now;
                        }

                        try
                        {
                            if (tUser.Username != UserPerson.User.Username)
                            {
                                tUser.Username = UserPerson.User.Username;
                            }
                        }
                        catch (Exception)
                        {
                            throw new Exception("El nombre de usuario no se encuentra disponible");
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
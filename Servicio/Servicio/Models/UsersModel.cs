using Servicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Models
{
    public class UsersModel
    {

        //logica para ver todos los usuarios en la db
        public List<Users>  ViewUsers()
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tusers = db.Users.ToList();

                    List<Users> Users = new List<Users>();
                    foreach (var User in tusers)
                    {
                        Users.Add(new Users
                        {
                            Id = User.Id,
                            Username = User.Username,
                            Password = User.Password,
                            User_Role = User.User_Role,
                            Photo = User.Photo
                        });
                    }

                    if (Users.Count == 0)
                    {
                        throw new Exception("No se encontraron usuarios");
                    }
                    else
                    {
                        return Users;
                    }
                }catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public Users ViewUserById(int Id)
        {
            using(var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    Users User = new Users();
                    var tusers = db.Users.Find(Id);
                    if (tusers != null)
                    {
                        User.Id = tusers.Id;
                        User.Username = tusers.Username;
                        User.Password = tusers.Password;
                        User.User_Role = tusers.User_Role;
                        User.Photo = tusers.Photo;
                        return User;
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

        public bool InsertUser(Users User)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    Users tusers = new Users();
                    if (User != null)
                    {
                        tusers.Username = User.Username;
                        tusers.Password = User.Password;
                        tusers.User_Role = User.User_Role;
                        tusers.Photo = User.Photo;
                        db.Users.Add(tusers);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("Ingrese los parametros necesarios");
                    }

                }catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public bool EditUser(Users User)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tuser = db.Users.Find(User.Id);
                    if(tuser != null)
                    {
                        tuser.Username = User.Username;
                        tuser.Password = User.Password;
                        tuser.User_Role = User.User_Role;
                        tuser.Photo = User.Photo;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("Error al editar usuario");
                    }
                }catch(Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public bool DeleteUser(int Id)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {
                    var tuser = db.Users.Find(Id);

                    if(tuser != null)
                    {
                        db.Users.Remove(tuser);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("El usuario no se pudo eliminar");
                    }

                }catch(Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public Users ValidateUser(Users User)
        {
            using (var db = new Proyecto_Progra_Avanzada_G5Entities())
            {
                try
                {


                    var tUser = (from x in db.Users
                                 where x.Username == User.Username
                                      && x.Password == User.Password
                                 select x).FirstOrDefault();

                    var tRol = db.Roles.Find(tUser.User_Role);


                    if (tUser != null)
                    {
                        Users user = new Users();
                        user.Username = tUser.Username;
                        user.User_Role = tUser.User_Role;
                        user.Photo = tUser.Photo;

                        return user;
                    }
                    else
                    {
                        return null;
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
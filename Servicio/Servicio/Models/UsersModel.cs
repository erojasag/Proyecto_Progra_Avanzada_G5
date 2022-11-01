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
        public List<Users> ViewUsers()
        {
            using (var db = new SHOECORP_BDEntities())
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
                            Identification = User.Identification,
                            Name= User.Name,
                            First_last_name= User.First_last_name,
                            Second_last_name = User.Second_last_name,
                            User_Role = User.User_Role,
                            Username = User.Username,
                            Birth_date = User.Birth_date,
                            Phone = User.Phone,
                            Email = User.Email,
                            Registration_date = User.Registration_date,
                            Photo = User.Photo,
                            Modification_date = User.Modification_date,
                            Address = User.Address
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
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public Users ViewUserById(Guid Id)
        {
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {
                    Users User = new Users();
                    var tusers = db.Users.Find(Id);
                    if (tusers != null)
                    {
                        User.Id = tusers.Id;
                        User.Identification = tusers.Identification;
                        User.Name = tusers.Name;
                        User.First_last_name = tusers.First_last_name;
                        User.Second_last_name = tusers.Second_last_name;
                        User.User_Role = tusers.User_Role;
                        User.Username = tusers.Username;
                        User.Birth_date = tusers.Birth_date;
                        User.Phone = tusers.Phone;
                        User.Email = tusers.Email;
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


        public bool InsertUser(Usuario User)
        {
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {

                    db.REGISTRAR_USUARIO(User.Identification, User.Name, User.First_last_name, User.Second_last_name, User.User_Role,
                        User.Username, User.Password, User.Birth_date, User.Phone, User.Email, User.Photo, User.Address);
                    return true;

                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public bool EditUser(Usuario User)
        {
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {
                    if (ViewUserById(User.Id) == null)
                    {
                        return false;
                    }
                    else
                    {
                        db.ACTUALIZAR_USUARIO(User.Id, User.Name, User.First_last_name, User.Second_last_name, User.User_Role, User.Password,
                            User.Phone, User.Email, User.Photo, User.Address);
                        return true;
                    }


                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public bool DeleteUser(Guid Id)
        {
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {
                    var tuser = db.Users.Find(Id);

                    if (tuser != null)
                    {
                        db.Users.Remove(tuser);
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

        public Usuario ValidateUser(Usuario User)
        {
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {

                   var datos = db.DESENCRIPTAR_CONTRA(User.Username, User.Password).FirstOrDefault();

                    if (datos != null)
                    {
                        User = new Usuario();
                        User.Username = datos.Username;
                        User.User_Role = datos.User_Role;
                        User.Photo = datos.Photo;

                        return User;
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

       public string ActualizarContraseña(Usuario obj)
        {
            using (var contexto = new SHOECORP_BDEntities())
            {

                try
                {
                    if (ViewUserById(obj.Id) == null)
                    {
                        return "No se puede cambiar contraseña porque el usuario no existe.";
                    }
                    else
                    {
                        contexto.ACTUALIZAR_CONTRASENIA(obj.Id, obj.Password);
                        return "Cambio de contraseña satisfactorio";
                    }


                }
                catch (Exception ex)
                {
                    contexto.Dispose();
                    throw ex;
                }
            }
        }

    }
}

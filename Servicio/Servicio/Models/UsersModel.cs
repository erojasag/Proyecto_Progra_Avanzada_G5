using Microsoft.IdentityModel.Tokens;
using Servicio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace Servicio.Models
{
    public class UsersModel
    {

        readonly EmailModel emailModel = new EmailModel();

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
                    var tusers = db.Users.Find(Id);
                    Users User = new Users();

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
                        User.Address = tusers.Address;
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
        public bool ViewUserByEmail(string email)
        {
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {
                    var TablaUser = (from x in db.Users
                                     where x.Email == email
                                     select x).FirstOrDefault();

                    if(TablaUser != null)
                    {
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


        public bool UserRegistration(Users User)
        {
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {
                    

                    db.REGISTRAR_USUARIO(User.Identification, User.Name, User.First_last_name, User.Second_last_name, User.User_Role,
                        User.Username, User.noHashPass, User.Birth_date, User.Phone, User.Email, User.Photo, User.Address);

                    var getActivationCode = (from x in db.Users
                                            where x.Email == User.Email
                                            select x).FirstOrDefault();

                    emailModel.SendVerificationLinkEmail(User.Email, getActivationCode.Activation_Code);
                    return true;

                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public bool ActivateAccount(Guid? activationCode)
        {
            using(var db = new SHOECORP_BDEntities())
            {
                try
                {
                    var activateAccount = (from x in db.Users
                                           where x.Activation_Code == activationCode
                                           select x).FirstOrDefault();

                    if(activateAccount != null && activateAccount.Activation_Code == activationCode)
                    {
                        activateAccount.Email_Verification = true;
                        emailModel.SendActivationConfirmationEmail(activateAccount.Email);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        db.Dispose();
                        return false;
                    }
                }
                catch(Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public bool EditUser(Users User)
        {
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {
                    var TablaUser = (from x in db.Users
                                      where x.Id == User.Id
                                      select x).FirstOrDefault();

                    if (TablaUser != null)
                    {

                        db.ACTUALIZAR_USUARIO(User.Id, User.Name, User.First_last_name, User.Second_last_name, User.User_Role,
                            User.Phone, User.Email, User.Photo, User.Address);
                        return true;
                    }
                    else
                        throw new Exception("The user does not exist");
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }
        public bool ForgotPassword(Users User)
        {
            using(var db = new SHOECORP_BDEntities())
            {
                try
                {
                    var datos = (from x in db.Users
                                 where x.Email == User.Email
                                 select x).FirstOrDefault();

                    if(datos != null)
                    {
                        var generateRandomPassword = db.FORGOT_PASS(User.Email);

                        ObjectResult<string> getTempPassword = db.SEE_TEMPASSWORD(User.Email);

                        var tempPassword = getTempPassword.FirstOrDefault();
                        

                        emailModel.ForgotPasswordEmail(User.Email, tempPassword);

                        return true;
                    }
                    else
                    {
                        return false;

                    }
                }catch(Exception ex)
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
                        db.Dispose();
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

        public Users ValidateUser(Users User)
        {
            using (var db = new SHOECORP_BDEntities())
            {
                try
                {


                    var datos = db.DESENCRIPTAR_CONTRA(User.Username, User.noHashPass).FirstOrDefault();

                    if (datos != null && datos.Email_Verification == true)
                    {
                        var token = GetToken(datos.Id);

                        Users u1 = new Users();
                        u1.Id = datos.Id;
                        u1.Username = datos.Username;
                        u1.Name= datos.Name;
                        u1.User_Role = datos.User_Role;
                        u1.Photo = datos.Photo;
                        u1.Token = token;
                        u1.Email_Verification = true;

                        return u1;
                    }
                    if(datos != null && datos.Email_Verification == false)
                    {
                       return null;
                    }
                    else
                    {
                        throw new Exception("El usuario y contrasena no matchean");

                    }
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    throw ex;
                }
            }
        }

        public string GetToken(Guid Id)
        {
            try
            {
                var key = ConfigurationManager.AppSettings["JwtKey"];

                var issuer = ConfigurationManager.AppSettings["JwtIssuer"];

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                //Create a List of Claims, Keep claims name short    
                var permClaims = new List<Claim>();
                permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                permClaims.Add(new Claim("userid", "Id"));

                //Create Security Token object by giving required parameters    
                var token = new JwtSecurityToken(issuer, //Issure    
                                issuer,  //Audience    
                                permClaims,
                                expires: DateTime.Now.AddDays(1),
                                signingCredentials: credentials);
                var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt_token;
            }
            catch(Exception ex)
            {
                return string.Empty;
            }

        }

        public bool UpdatePassword(Users user)
        {
            using (var contexto = new SHOECORP_BDEntities())
            {

                try
                {
                    if (ViewUserById(user.Id) == null)
                    {
                        return false;
                    }
                    else
                    {
                        var updatePassword = contexto.ACTUALIZAR_CONTRASENIA(user.Id, user.noHashPass);

                        if(updatePassword == 0)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
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

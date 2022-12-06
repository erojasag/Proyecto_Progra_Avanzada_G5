//Esta clase al igual que el controlador solo sirven para envio y validacion de correos de autentication de registro
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Servicio.Models
{
    public class EmailModel
    {
        public void SendVerificationLinkEmail(string emailId, string activationcode)
        {
            string scheme = "http";
            string host = "localhost";
            string port = "1433";
            string Url = ConfigurationManager.AppSettings["email"].ToString();
            string password = ConfigurationManager.AppSettings["password"].ToString();
            var verifyUrl = scheme + "://" + host + ":" + port + "/ShoeCorp/ActivateAccount/" + activationcode;
            var fromMail = new MailAddress(Url, "ShoeCorp");
            var toMail = new MailAddress(emailId);
            string subject = "Activate your ShoeCorp Account";
            string body = "<br/><br/>We are excited to tell you that your account is" +
              " successfully created. Please click on the below link to verify your account" +
              " <br/><br/><a href='" + verifyUrl + "'>" + verifyUrl + "</a> ";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Url, password)

            };
            using (var message = new MailMessage(fromMail, toMail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }

        public void ForgotPasswordEmail(string correo, string newPassword)
        {
            try
            {

                string Url = ConfigurationManager.AppSettings["email"].ToString();
                string password = ConfigurationManager.AppSettings["password"].ToString();
                var fromMail = new MailAddress(Url, "ShoeCorp");
                var toMail = new MailAddress(correo);
                string subject = "Reset ShoeCorp Account Password";
                string body = "<br/><br/>Please find below your new Shoe Corp Account Password" + " " +
                  newPassword + " " + " <br/><br/>" +
                  "Remember to change your password the next time you log in";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(Url, password)

                };
                using (var message = new MailMessage(fromMail, toMail)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                    smtp.Send(message);

            }
            catch(Exception ex)
            {
                throw ex;

            }
        }
    }
}
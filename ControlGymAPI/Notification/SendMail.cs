using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Security;

namespace ControlGymAPI.Notification
{
    public class SendMail
    {
        public static bool SendNotificationByRegister(String completename, string email, string password, string Gimnasio)
        {
            try
            {
                var mail = new Mail();
                var mailMessage = new MailMessage { Subject = "Registro de usuario en " + Gimnasio };

                mailMessage.To.Add(new MailAddress(email));
                mailMessage.From = new MailAddress("gymcontrolservice@outlook.com", Gimnasio);
                mailMessage.IsBodyHtml = true;

                string htmlmessage = "<h3>Estimado(a) " + completename + ":</h3>"
                                     + "<br>Se ha registrado correctamente en " + Gimnasio
                                     + "<br><br>El usuario para ingresar a la aplicacion es: <B>" + email + "</B>"
                                     + "<br>Su contraseña para ingresar a la aplicacion es: <B>\"" + password + "\"</B> sin la comillas<br>"
                                     + "<br>Descargue nuestra aplicacion : <a href=\"http://mfrancorc.com/control_gym_apk\">aqui</a>"
                                     + "<br><br>Agradecemos no contestar este correo,  esta dirección de correo electrónico únicamente envía codigos de registro. Favor remitir sus consultas a gymcontrolservice@outlook.com o comuníquese al teléfono (506) 8302-1353."
                                     + "<br><br>Si no ha realizado ningun registro por favor ignorar este mensaje.";
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlmessage, Encoding.UTF8, MediaTypeNames.Text.Html);
                mailMessage.AlternateViews.Add(htmlView);
                mail.SendMail(mailMessage);

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public static bool SendNotificationByRegisterAdmin(String completename, string email, string password, string Gimnasio)
        {
            try
            {
                var mail = new Mail();
                var mailMessage = new MailMessage { Subject = "Registro de usuario en " + Gimnasio };

                mailMessage.To.Add(new MailAddress(email));
                mailMessage.From = new MailAddress("gymcontrolservice@outlook.com", Gimnasio);
                mailMessage.IsBodyHtml = true;

                string htmlmessage = "<h3>Estimado(a) " + completename + ":</h3>"
                                     + "<br>Se ha registrado correctamente en " + Gimnasio
                                     + "<br><br>El usuario para ingresar a la aplicacion es: <B>" + email + "</B>"                                     
                                     + "<br>Su clave para ingresar a la aplicacion es: <B>\"" + password + "\"</B> sin la comillas<br>"
                                     + "<br>Ingrese a nuestro sitio web : <a href=\"http://mfrancorc.com/ControlGymWeb\">aqui</a>"
                                     + "<br><br>Agradecemos no contestar este correo,  esta dirección de correo electrónico únicamente envía codigos de registro. Favor remitir sus consultas a gymcontrolservice@outlook.com o comuníquese al teléfono (506) 8302-1353."
                                     + "<br><br>Si no ha realizado ningun registro por favor ignorar este mensaje.";
                htmlmessage += "<div align=\"center\"> <img src='cid:imagen' />  </div> ";

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlmessage, Encoding.UTF8, MediaTypeNames.Text.Html);
                mailMessage.AlternateViews.Add(htmlView);
                mail.SendMail(mailMessage);

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}
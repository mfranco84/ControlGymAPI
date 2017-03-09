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
        public static bool SendNotificationByRegister(String completename, string email, string password)
        {
            try
            {
                var mail = new Mail();
                var mailMessage = new MailMessage { Subject = "Registro de usuario en GymControl" };
                var nombreGimnasio = "Control Gym 360";
                mailMessage.To.Add(new MailAddress(email));
                mailMessage.From = new MailAddress("gymcontrolservice@outlook.com", nombreGimnasio);
                mailMessage.IsBodyHtml = true;

                var pass = Membership.GeneratePassword(6, 0);

                string htmlmessage = "<h3>Estimado(a) " + completename + ":</h3>"
                                     + "<br>Se ha registrado correctamente en GymControl"
                                     + "<br>Su contraseña para ingresar a la aplicacion es: \"" + pass + "\" sin la comillas<br>"
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
    }
}
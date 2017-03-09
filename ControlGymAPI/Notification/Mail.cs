using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ControlGymAPI.Notification
{
   public class Mail
    {
        /*
         * Cliente SMTP
         * Gmail:  smtp.gmail.com  puerto:587
         * Hotmail: smtp.live.com  puerto:25
         */
        //readonly SmtpClient _server = new SmtpClient("smtp.gmail.com", 587);
        readonly SmtpClient _server = new SmtpClient("smtp.live.com", 25);

        public Mail()
        {
            /*
             * Autenticacion en el Servidor
             * Utilizaremos nuestra cuenta de correo
             *
             * Direccion de Correo (Gmail o Hotmail)
             * y Contrasena correspondiente
             */            
            _server.Credentials = new System.Net.NetworkCredential("gymcontrolservice@outlook.com", "ABC123xyz");
            _server.EnableSsl = true;
        }

        public void SendMail(MailMessage mensaje)
        {
            _server.Send(mensaje);
        }
    }
}
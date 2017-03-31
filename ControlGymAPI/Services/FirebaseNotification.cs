using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Text;
using ControlGymAPI.Models;
using ControlGymAPI.Repositories;

namespace ControlGymAPI.Services
{
    public class FirebaseNotification
    {
        private static readonly HttpClient client = new HttpClient();
        private static String serverKey = "AAAAxdZ_rFE:APA91bHGpP4Kwf5z8lO8O2fcnCR-cEOCkoW8CXPKMpvMS50rGHprpat2GQiu0A1-nhd5dg83YgKYOFHhtjb0HeIflMuBQBZTAGc27HimJAq6bkvgW6mMVzT2MFgjp5xqcqgPX7rE1W5_";
        private static String url = "https://fcm.googleapis.com/fcm/send";

        // Envia notificacion a un miembro en especifico
        public void post(String deviceToken, String title, String body)
        {
            // Agregando header customizado "Authorization: key=<serverKey>"
            String authHeader = "key=" + serverKey;
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authHeader);

            // Generando json para el body del POST
            dynamic myObject = new JObject();
            myObject.to = deviceToken;
            dynamic notificationObject = new JObject();
            notificationObject.title = title;
            notificationObject.body = body;
            myObject.notification = notificationObject;

            // Generando contenido final del POST y haciendo el request
            var content = new StringContent(myObject.ToString(), Encoding.UTF8, "application/json");
            var response = client.PostAsync(url, content).Result;

        }

        // Envia notificacion a todos los miembros del gimnasio que tengan el device registrado
        public void postGeneral(String title, String body)
        {
            List<MiembroModel> listaMiembros;
            MiembroRepository miembroRep = new MiembroRepository();
            listaMiembros = miembroRep.RetrieveMiembros();
            foreach (var miembro in listaMiembros)
            {
                if ( !string.IsNullOrEmpty(miembro.DeviceToken) )
                {
                    post(miembro.DeviceToken, title, body);
                }
            }
        }
    }
}
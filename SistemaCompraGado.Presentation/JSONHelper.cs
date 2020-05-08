using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using SistemaCompraGado.Presentation.Negocios.Entities;
using Newtonsoft.Json;

namespace SistemaCompraGado.Presentation
{
    public static class JSONHelper
    {
        public static string GetJSONString(string url)
        {
            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(
                    stream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }

        public static T GetObjectFromJSONString<T>(string json) where T : new()
        {
            using (MemoryStream stream = new MemoryStream(
                Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(stream);
            }
        }

        public static Retorno Post(string Ura, object obj)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Ura);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                streamWriter.Write(obj);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {

                return JsonConvert.DeserializeObject<Retorno>(streamReader.ReadToEnd());

            }
        }

    }
}

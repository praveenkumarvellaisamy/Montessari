using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Montessari.API
{
    public class MontessoriAPI
    {
        public static string WebPOST(string EndPoint, object T)
        {
            var body = JsonConvert.SerializeObject(T);
            string URL = ConfigurationManager.AppSettings.Get("APIURL");

            if (URL.Contains("https:"))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }

            var baseAddress = URL + EndPoint;// + "?APIKEY=" + APIKey;

            var http = (HttpWebRequest)WebRequest.Create(baseAddress);
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";


            string parsedContent = body;
            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(parsedContent);

            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            var response = http.GetResponse();

            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();

            return JsonConvert.DeserializeObject(content).ToString();
        }
    }
}
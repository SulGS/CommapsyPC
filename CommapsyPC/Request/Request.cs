using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows;
using CommapsyPC.Windows;

namespace CommapsyPC.Request
{
    class Request
    {
        public static readonly string URL = "http://commapsy.us.to:8081";
        public static string Token = "null";

        public static string RequestData(string page, List<KeyValuePair<string,string>> parameters) 
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(URL + page);
                httpWebRequest.Headers.Add("Authorization",Token);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{";

                    int i = 1;
                    foreach (KeyValuePair<string, string> parameter in parameters)
                    {
                        json += "\"" + parameter.Key + "\":\"" + parameter.Value + "\"";

                        if (i < parameters.Count())
                        {
                            json += ",";
                        }
                        i++;
                    }

                    json += "}";




                    streamWriter.Write(json);
                    streamWriter.Flush();
                }


                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                if (httpResponse.StatusCode==HttpStatusCode.Forbidden) 
                {
                    PlatformWindow.pw.Dispatcher.Invoke(() =>
                    {
                        MessageBox.Show("Token desactualizado. Reinicie la aplicacion");
                        Environment.Exit(0);
                    });
                }

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string stringReturn = streamReader.ReadToEnd();
                    return stringReturn;
                }

            }
            catch (WebException ex) 
            {
                return "";
            }

        }
    }
}

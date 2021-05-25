using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace CommapsyPC.Request
{
    class Request
    {
        public static readonly string URL = "http://192.168.1.192:8080";

        public static string RequestData(string page, List<KeyValuePair<string,string>> parameters) 
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(URL + page);
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

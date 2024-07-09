using Microsoft.AspNet.Identity;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CodeLock.Areas.Operation.Repository
{
    public class Class_IRISEwayBill
    {
        public string newRequestPost(string pMethod, string pUrl, string pJsonContent, Dictionary<string, string> pHeaders)
        {
            string result = "";
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3;


                var httpWebRequest = (HttpWebRequest)WebRequest.Create(pUrl);
                httpWebRequest.ContentType = "application/json";
                string username = "CJDarcl@PB_API_IRS";
                string password = "Hrhk@123456789";

                //// Add basic authentication credentials
                string credentials = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(username + ":" + password));
                httpWebRequest.Headers["Authorization"] = "Basic " + credentials;
                //httpWebRequest.Headers[HttpRequestHeader.Authorization] = "NoAuth";

                // httpWebRequest.AllowAutoRedirect = true;
                // httpWebRequest.UserAgent = "TMSC";
                //httpWebRequest.Connection = "keep-alive";
                // httpWebRequest.Accept = "*/*";

                if (pMethod == "POST")
                {
                    httpWebRequest.Method = "POST";
                }
                else
                {
                    httpWebRequest.Method = pMethod;
                }

                foreach (var head in pHeaders)
                {
                    httpWebRequest.Headers.Add(head.Key, head.Value);
                }


                if (pMethod == "POST")
                {
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(pJsonContent);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();


                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

            }
            catch (WebException ex)
            {
                HttpWebResponse response = ex.Response as HttpWebResponse;

                if (response != null)
                {
                    using (Stream data = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(data))
                    {
                        result = reader.ReadToEnd();
                    }
                }
            }

            return result;
        }

        public string newRequest(string pMethod, string pUrl, string pJsonContent, Dictionary<string, string> pHeaders)
        {
            string result = "";
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3;


                var httpWebRequest = (HttpWebRequest)WebRequest.Create(pUrl);
                httpWebRequest.ContentType = "application/json";
                
                if(pMethod == "POST")
                {
                    httpWebRequest.Method = "POST";
                }
                else
                {
                    httpWebRequest.Method = pMethod;
                }


                foreach (var head in pHeaders)
                {
                    httpWebRequest.Headers.Add(head.Key, head.Value);
                }
                

                if (pMethod == "POST")
                {
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(pJsonContent);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();


                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

            }
            catch (WebException ex)
            {
                HttpWebResponse response = ex.Response as HttpWebResponse;

                if (response != null)
                {
                    using (Stream data = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(data))
                    {
                        result = reader.ReadToEnd();
                    }
                }
            }

            return result;
        }

        public string RequestRestClient(string pMethod, string pUrl, string pJsonContent, Dictionary<string, string> pHeaders)
        {
            string result = "";
            RestClient client = new RestClient(pUrl);
            RestRequest request = new RestRequest();
            request.Method= Method.Post;
            foreach (var head in pHeaders)
            {
                request.AddHeader(head.Key, head.Value);
            }
            request.AddBody(pJsonContent);

            RestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result = response.Content;
                // Process the response content as needed
            }


            return result;
        }


        public byte[] downloadRequest(string pUrl, string pJsonContent, Dictionary<string, string> pHeaders)
        {

            RestClient client = new RestClient(pUrl);
            RestRequest request = new RestRequest();
            request.Method= Method.Post;
            foreach (var head in pHeaders)
            {
                request.AddHeader(head.Key, head.Value);
            }
            request.AddBody(pJsonContent);
            byte[] response = client.DownloadData(request);

            return response;
        }

    }
}
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
    public class WebtelSendingJsonData
    {
        private static readonly HttpClient _Client = new HttpClient();

        public async Task<HttpResponseMessage> Request(HttpMethod pMethod, string pUrl, string pJsonContent, Dictionary<string, string> pHeaders)
        {
            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = pMethod;
            httpRequestMessage.RequestUri = new Uri(pUrl);
            foreach (var head in pHeaders)
            {
                httpRequestMessage.Headers.Add(head.Key, head.Value);
            }
            switch (pMethod.Method)
            {
                case "POST":
                    HttpContent httpContent = new StringContent(pJsonContent, Encoding.UTF8, "application/json");
                    httpRequestMessage.Content = httpContent;
                    break;

            }

            return await _Client.SendAsync(httpRequestMessage);
        }

        public string newRequest(string pMethod, string pUrl, string pJsonContent, Dictionary<string, string> pHeaders)
        {
            string result = "";
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(pUrl);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = pMethod;
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

        public string RequestRestClient(string pUrl, string pJsonContent, Dictionary<string, string> pHeaders)
        {
            string result = "";
            RestClient client = new RestClient(pUrl);
            RestRequest request = new RestRequest();
            request.Method= Method.Post;
            foreach (var head in pHeaders)
            {
                request.AddHeader(head.Key, head.Value);
            }
            request.AddHeader("Content-Type", "application/json");
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
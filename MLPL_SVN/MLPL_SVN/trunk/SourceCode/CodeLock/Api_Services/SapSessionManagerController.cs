using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;
using CodeLock.Models;
using Microsoft.Owin.BuilderProperties;

namespace CodeLock.Api_Services
{    
    // ULIP Token Generation
    public static class SapSessionManagerController
    {
        public class B1Session
        {
            public string SessionId { get; set; }
        }

        private static string _sessionId;

        //public static async Task<string> GenerateToken()
        //{
        //    if (_sessionId == null)
        //    {
        //        _sessionId = await GenerateB1SessionAsync();
        //        return _sessionId;
        //    }
        //    else
        //    {
        //        return _sessionId;
        //    }

        //}
        public static async Task<string> GenerateToken()
        {
            // Check if the sessionId is null or expired
            if (string.IsNullOrEmpty(_sessionId))
            {
                _sessionId = await GenerateB1SessionAsync();
            }
            return _sessionId;
        }
       
        public static string GetSessionId()
        {
            return _sessionId;
        }
        private static async Task<string> GenerateB1SessionAsync()
        {
            try
            {
                var loginRequestBody = new
                {
                    CompanyDB = "MLPLAPI",
                    Password = "9811",
                    UserName = "manager"
                };

                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("B1S-WCFCompatible", "true");
                    client.DefaultRequestHeaders.Add("B1S-MetadataWithoutSession", "true");
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));
                    client.DefaultRequestHeaders.ExpectContinue = false;

                    // Decompression
                    client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("gzip"));
                    client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("deflate"));
                    client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("br"));

                    var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(loginRequestBody);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("https://103.194.8.71:50000/b1s/v1/Login", content);

                    if (response.IsSuccessStatusCode)
                    {
                        if (response.Content.Headers.ContentEncoding.Contains("gzip"))
                        {
                            using (var gzipStream = new GZipStream(await response.Content.ReadAsStreamAsync(), CompressionMode.Decompress))
                            using (var streamReader = new StreamReader(gzipStream))
                            {
                                string responseBody = await streamReader.ReadToEndAsync();
                                B1Session obj = JsonConvert.DeserializeObject<B1Session>(responseBody);

                                Console.WriteLine($"New session generated: {obj.SessionId}");
                                return obj.SessionId;
                            }
                        }
                    }
                    else
                    {
                        // Log or handle specific status codes
                        LogError(response.StatusCode);
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception details for debugging purposes
                Console.WriteLine($"Session Manager Exception: {ex.Message}");
                return null;
            }

            return null;
        }
        public static async void LogError(HttpStatusCode statusCode)
        {
            switch (statusCode)
            {
                    case HttpStatusCode.BadRequest:
                    Console.WriteLine("Error: 400 Bad Request");
                    await GenerateB1SessionAsync();
                    break;
                    case HttpStatusCode.NotFound:
                    Console.WriteLine("Error: 404 Not Found");
                    await GenerateB1SessionAsync();
                    break;
                    case HttpStatusCode.InternalServerError:
                    Console.WriteLine("Error: 500 Internal Server Error");
                    break;
                    case HttpStatusCode.Conflict:
                    await GenerateB1SessionAsync();
                    break;
                    case HttpStatusCode.PreconditionFailed:
                    await GenerateB1SessionAsync();
                    break;                  
                default:
                    Console.WriteLine($"Error: {statusCode}");
                    break;
            }
        }

        //private static async Task<string> GenerateB1SessionAsync()
        //{
        //    try
        //    {
        //        var loginRequestBody = new
        //        {
        //            CompanyDB = "MLPLAPI",
        //            Password = "9811",
        //            UserName = "manager"
        //        };
        //        ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

        //        using (var client = new HttpClient())
        //        {
        //            client.DefaultRequestHeaders.Add("B1S-WCFCompatible", "true");
        //            client.DefaultRequestHeaders.Add("B1S-MetadataWithoutSession", "true");
        //            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));
        //            client.DefaultRequestHeaders.ExpectContinue = false;

        //            // decompression
        //            client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("gzip"));
        //            client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("deflate"));
        //            client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("br"));

        //            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(loginRequestBody);
        //            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        //            var response = await client.PostAsync("https://103.194.8.71:50000/b1s/v1/Login", content);
        //            var statusCode = response.StatusCode;

        //            if (response.IsSuccessStatusCode)
        //            {
        //                if (response.Content.Headers.ContentEncoding.Contains("gzip"))
        //                {
        //                    using (var gzipStream = new GZipStream(await response.Content.ReadAsStreamAsync(), CompressionMode.Decompress))
        //                    using (var streamReader = new StreamReader(gzipStream))
        //                    {
        //                        string responseBody = await streamReader.ReadToEndAsync();
        //                        B1Session obj = JsonConvert.DeserializeObject<B1Session>(responseBody);

        //                        string sessionId = obj.SessionId;
        //                        return sessionId;
        //                    }
        //                }
        //                else
        //                {
        //                    // Handle unsuccessful request (e.g., log, throw exception, return error response)
        //                    return null;
        //                }
        //            }
        //            else
        //            {
        //                string Response = "Data not get From SAP";
        //                return Response;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string Response = "Session Manager Exception : " + ex;
        //        return Response;
        //    }
        //}
        // ***************** Insert Bp Master *****************************


    }
}
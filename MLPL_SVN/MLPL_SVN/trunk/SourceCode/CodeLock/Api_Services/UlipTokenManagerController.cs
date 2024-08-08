using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Configuration;


namespace CodeLock.Api_Services
{
    // ULIP Token Generation
    public static class UlipTokenManagerController
    {
        public class TokenResponse
        {
            public class ResponseData
            {
                public string id { get; set; }
            }
            public ResponseData response { get; set; }
            public bool error { get; set; }
            public string code { get; set; }
            public string message { get; set; }
        }
        private static string _tokenId;
        public static async Task<string> GenerateToken()
        {
            _tokenId = await GenerateBearerTokenAsync();
            return _tokenId;
        }
        public static string GetTokenId()
        {
            return _tokenId;
        }
        private static async Task<string> GenerateBearerTokenAsync()
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;

            var jsonBody = new
            {
                username = "mahalakshmi_usr",
                password = "mahalakshmi@26072024"
            };

            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonBody);
            // Create the HTTP client
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");


                string ulipUrl = ConfigurationManager.AppSettings["UlipUrl"];

                var response = await httpClient.PostAsync($"{ulipUrl}/user/login", content);

                // Check if the request was successful
           //     var response = await httpClient.PostAsync("https://www.ulip.dpiit.gov.in/ulip/v1.0.0/user/login", content);
                if (response.IsSuccessStatusCode)
                {
                    var tokenResponse = await response.Content.ReadAsStringAsync();
                    var tokenData = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenResponse>(tokenResponse);
                    string tokenId = tokenData.response.id;
                    return tokenId;
                }
                else
                {
                    throw new Exception($"Failed to retrieve bearer token from API. Error: {response.StatusCode}");
                }
            }
        }
    }
}
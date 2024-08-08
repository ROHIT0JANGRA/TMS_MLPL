using System;
using System.Collections.Generic;
using System.Linq;
using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using System.Data;
using System.Threading.Tasks;
using CodeLock.Api_Services;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.IO.Compression;
using Brotli;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace CodeLock.Areas.Packaging.Repository
{
    public class RgpRepository : BaseRepository, IRgpRepository, IDisposable
    {

        public int InsertRGP(PackagingModel rgpChallan)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@XmlCustomer", (object)XmlUtility.XmlSerializeToString((object)rgpChallan), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@rgpId", (object)null, new DbType?(DbType.Int32), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                DataBaseFactory.QuerySP("Usp_MasterCustomer_Insert_Test", (object)dynamicParameters, "Rgp - Insert");

                return dynamicParameters.Get<int>("@rgpId");
            } catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);

            }

        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }


        Task<string> IRgpRepository.GetRGPData()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AutoCompleteResult> RGP_SeriesList()
        {
            var data = DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_RGP_SeriesList", (object)null, "Pkg RGP Master - GetPKGRgpSeriesList");
            return data;
        }

        // **********************  Rgp List Fetch StockTransfer List Data All Methods **************************

        // ******************** this FetchBPMasterPagination Method working for all get all details according to pagination in list table ****************
        public async Task<Dictionary<string, object>> FetchBPMasterPagination(int start, int length, string search = null)
        {
            var result = new Dictionary<string, object>();
            try
            {
                string countUrl = "/StockTransfers/$count";
                string FetchRgpmyurl = $"https://103.194.8.71:50000/b1s/v1/StockTransfers?$select=Series,CardCode,CardName,FromWarehouse,ToWarehouse,BPLName,DocDate,U_VehicleNo,U_TrnspName,Reference1&$skip={start}&$top={length}";
                if (!string.IsNullOrEmpty(search))
                {
                    // myurl += $"&$filter=contains(CardName,'{search}') or contains(CardCode,'{search}') or contains(U_VehicleNo,'{search}'or contains(Reference1,'{search}')";
                    FetchRgpmyurl += $"&$filter=contains(CardName,'{search}') or contains(CardCode,'{search}') or contains(U_VehicleNo,'{search}') or contains(Reference1,'{search}')";
                }

                int totalRecords = await FetchBPMasterCount(countUrl).ConfigureAwait(false);
                var BPMasterListResponse = await FetchBPMasterList(FetchRgpmyurl,start, length, search).ConfigureAwait(false);

                result["totalRecords"] = totalRecords;
                result["BPMasterList"] = BPMasterListResponse?.ContainsKey("value") == true ? BPMasterListResponse["value"] : new List<object>();
            }
            catch (Exception ex)
            {
                result["error"] = ex.Message;
            }

            return result;
        }

        public async Task<int> FetchBPMasterCount(string countUrl)
        {
            try
            {
                string sessionId = await GetSessionIdAsync().ConfigureAwait(false);
                using (var client = CreateHttpClient(sessionId))
                {
                    //HttpResponseMessage response = await client.GetAsync("https://103.194.8.71:50000/b1s/v1/StockTransfers/$count");
                    HttpResponseMessage response = await client.GetAsync("https://103.194.8.71:50000/b1s/v1" + countUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        using (var responseStream = await GetDecompressedStreamAsync(response))
                        using (var streamReader = new StreamReader(responseStream))
                        {
                            string responseBody = await streamReader.ReadToEndAsync();
                            return int.Parse(responseBody.Trim());
                        }
                    }
                    else
                    {
                        SapSessionManagerController.LogError(response.StatusCode);

                        string errorResponse = await response.Content.ReadAsStringAsync();
                        throw new HttpRequestException($"Failed to retrieve BPMaster count. Status code: {response.StatusCode}. Error: {errorResponse}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in FetchBPMasterCount: {ex.Message}", ex);
            }
        }

        public async Task<Dictionary<string, object>> FetchBPMasterList(string Fetchurl,int start, int length, string search)
        {
            try
            {
                string sessionId = await GetSessionIdAsync().ConfigureAwait(false);
                using (var client = CreateHttpClient(sessionId))
                {
                    // Construct the URL with optional search filter
                    //    string myurl = $"https://103.194.8.71:50000/b1s/v1/StockTransfers?$skip={start}&$top={length}";
                   // string myurl = $"https://103.194.8.71:50000/b1s/v1/StockTransfers?$select=Series,CardCode,CardName,FromWarehouse,ToWarehouse,BPLName,DocDate,U_VehicleNo,U_TrnspName,Reference1&$skip={start}&$top={length}";

                    //if (!string.IsNullOrEmpty(search))
                    //{
                    //    // myurl += $"&$filter=contains(CardName,'{search}') or contains(CardCode,'{search}') or contains(U_VehicleNo,'{search}'or contains(Reference1,'{search}')";
                    //    Fetchurl += $"&$filter=contains(CardName,'{search}') or contains(CardCode,'{search}') or contains(U_VehicleNo,'{search}') or contains(Reference1,'{search}')";
                    //}

                    // Make the GET request to the SAP endpoint
                    HttpResponseMessage response = await client.GetAsync(Fetchurl);
                  
                    if (response.IsSuccessStatusCode)
                    {
                        // Handle gzip encoding if present
                        using (var responseStream = await GetDecompressedStreamAsync(response))
                        using (var streamReader = new StreamReader(responseStream))
                        {
                            // Read and deserialize the response
                            string responseBody = await streamReader.ReadToEndAsync();
                            return JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);
                        }
                    }
                    else
                    {
                        // Capture and throw detailed error information
                        string errorResponse = await response.Content.ReadAsStringAsync();
                        SapSessionManagerController.LogError(response.StatusCode);
                        throw new HttpRequestException($"Failed to retrieve BPMaster list. Status code: {response.StatusCode}. Error: {errorResponse}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in FetchBPMasterList: {ex.Message}", ex);
            }
        }
      

        // Helper methods
        /// <summary>
        ///  This Methods GetSessionIdAsync() , CreateHttpClient(),GetDecompressedStreamAsync()  are Common random method for calling any Sap Api 
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetSessionIdAsync()
        {
            string sessionId =await SapSessionManagerController.GenerateToken();
            return string.IsNullOrEmpty(sessionId) ? await SapSessionManagerController.GenerateToken() : sessionId;
        }

        public HttpClient CreateHttpClient(string sessionId)
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("B1S-WCFCompatible", "true");
            client.DefaultRequestHeaders.Add("B1S-MetadataWithoutSession", "true");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");

            var cookies = new CookieContainer();
            cookies.Add(new Cookie("B1SESSION", sessionId) { Domain = "103.194.8.71" });
            cookies.Add(new Cookie("ROUTEID", ".node1") { Domain = "103.194.8.71" });
            handler.CookieContainer = cookies;

            return client;
        }

        public async Task<Stream> GetDecompressedStreamAsync(HttpResponseMessage response)
        {
            Stream responseStream = await response.Content.ReadAsStreamAsync();
            if (response.Content.Headers.ContentEncoding.Contains("gzip"))
            {
                return new GZipStream(responseStream, CompressionMode.Decompress);
            }
            return responseStream;
        }

        // ******************  this Function getRgpDetailsBySeriesNo working for get all details by series no to view details by series egp challan *******

        public async Task<Dictionary<string, object>> GetRgpDetailsBySeriesNo(int? rgpSeriesNo)
        {
            string sessionId = await GetSessionIdAsync().ConfigureAwait(false);
            using (var client = CreateHttpClient(sessionId))
            {
                // Base URL of the API
                string baseUrl = "https://103.194.8.71:50000/b1s/v1/StockTransfers";

                // Construct the query parameters dynamically
                string queryParameters = $"?$filter=contains(Reference1,'{rgpSeriesNo}')";

                // Full URL with query parameters
                string url = baseUrl + queryParameters;

                try
                {
                    // Send the GET request
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Ensure the request was successful
                    response.EnsureSuccessStatusCode();

                    // Read and return the response content
                    string responseBody = await GetResponseBodyAsync(response);
                    var jsonData = JsonConvert.DeserializeObject<dynamic>(responseBody);

                    var data = jsonData.value.ToObject<List<PackagingModel>>();
                    //   string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);
                }

                catch (HttpRequestException e)
                {
                    // Handle any HTTP request errors
                    Console.WriteLine($"Request error: {e.Message}");
                    return null;
                }
            }
        }
        public async Task<Dictionary<string, object>> FetchRGPDataBySeriesNo(int? rgpSeriesNo)
        {
            var result = new Dictionary<string, object>();
            try
            {
                var RgpSeriesListResponse = await GetRgpDetailsBySeriesNo(rgpSeriesNo).ConfigureAwait(false);

                result["RgpDataList"] = RgpSeriesListResponse?.ContainsKey("value") == true ? RgpSeriesListResponse["value"] : new List<object>();
            }
            catch (Exception ex)
            {
                result["error"] = ex.Message;
            }

            return result;
        }


        // *********************************** This method is given RGP Stock Item List According to that *************************

        private HttpClient CreateHttpClient()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };

            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("B1S-WCFCompatible", "true");
            client.DefaultRequestHeaders.Add("B1S-MetadataWithoutSession", "true");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");

            return client;
        }

        public async Task<List<Dictionary<string, object>>> GetTheRgpItemDetails(string cardCode,string FromWh)
        {
            //string warehouse = "NAW-WH";
            //string customer = "C0031";
            string url = $"http://mlpl.reedhamitsolution.com/GetStock.php?warehouse={Uri.EscapeDataString(FromWh)}&customer={Uri.EscapeDataString(cardCode)}";

            try
            {
                using (var client = CreateHttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();  // Raise an exception if the response status code is not successful

                    // Handle gzip encoding if present
                    string responseBody = await GetResponseContentAsync(response);
                    var dataList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(responseBody);

                    return dataList;
                }
            }
            catch (HttpRequestException ex)
            {
                // Log the exception details
                Console.WriteLine($"Request error: {ex.Message}");

                // Return a list with an error message
                return new List<Dictionary<string, object>>
        {
            new Dictionary<string, object>
            {
                { "error", $"Request error: {ex.Message}" }
            }
        };
            }
            catch (JsonException ex)
            {
                // Log JSON deserialization errors
                Console.WriteLine($"JSON error: {ex.Message}");

                // Return a list with an error message
                return new List<Dictionary<string, object>>
        {
            new Dictionary<string, object>
            {
                { "error", $"JSON error: {ex.Message}" }
            }
        };
            }
        }
    
        private async Task<string> GetResponseContentAsync(HttpResponseMessage response)
        {
            var contentEncoding = response.Content.Headers.ContentEncoding.FirstOrDefault();
            if (contentEncoding == "gzip")
            {
                using (var responseStream = new GZipStream(await response.Content.ReadAsStreamAsync(), CompressionMode.Decompress))
                using (var streamReader = new StreamReader(responseStream))
                {
                    return await streamReader.ReadToEndAsync();
                }
            }
            else if (contentEncoding == "deflate")
            {
                using (var responseStream = new DeflateStream(await response.Content.ReadAsStreamAsync(), CompressionMode.Decompress))
                using (var streamReader = new StreamReader(responseStream))
                {
                    return await streamReader.ReadToEndAsync();
                }
            }
            else if (contentEncoding == "br")
            {
                // Handle Brotli encoding
                using (var responseStream = new BrotliStream(await response.Content.ReadAsStreamAsync(), CompressionMode.Decompress))
                using (var streamReader = new StreamReader(responseStream))
                {
                    return await streamReader.ReadToEndAsync();
                }
            }
            else
            {
                return await response.Content.ReadAsStringAsync();
            }
        }
        //*********************************old wokring code ************************************
        public async Task<object> GetRGPDataListFromApi(int draw, int start, int length, string search)
        {
            string sessionId = SapSessionManagerController.GetSessionId()
                               ?? await SapSessionManagerController.GenerateToken();

            using (var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            })
            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Add("B1S-WCFCompatible", "true");
                client.DefaultRequestHeaders.Add("B1S-MetadataWithoutSession", "true");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");

                var cookies = new CookieContainer();
                cookies.Add(new Cookie("B1SESSION", sessionId) { Domain = "103.194.8.71" });
                cookies.Add(new Cookie("ROUTEID", ".node1") { Domain = "103.194.8.71" });
                handler.CookieContainer = cookies;

                var url = $"https://103.194.8.71:50000/b1s/v1/StockTransfers?$skip={start}&$top={length}";

                if (!string.IsNullOrEmpty(search))
                {
                    url += $"&$filter=substringof('{search}', CardCode) or substringof('{search}', CardName)";
                }

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await GetResponseBodyAsync(response);
                    var jsonData = JsonConvert.DeserializeObject<dynamic>(responseBody);

                    var data = jsonData.value.ToObject<List<PackagingModel>>();
                    var totalRecords = jsonData["@odata.count"] ?? data.Count;

                    // Ensure totalRecords is an integer
                    totalRecords = (int)(totalRecords ?? 0);

                    return new
                    {
                        draw = draw,
                        recordsTotal = totalRecords,
                        recordsFiltered = totalRecords, // Adjust this if you implement filtering logic
                        data = data
                    };
                }
                else
                {
                    return new { error = $"Failed to retrieve data. Status code: {response.StatusCode}" };
                }
            }
        }

        private async Task<string> GetResponseBodyAsync(HttpResponseMessage response)
        {
            if (response.Content.Headers.ContentEncoding.Contains("gzip"))
            {
                using (var gzipStream = new GZipStream(await response.Content.ReadAsStreamAsync(), CompressionMode.Decompress))
                using (var streamReader = new StreamReader(gzipStream))
                {
                    return await streamReader.ReadToEndAsync();
                }
            }
            else
            {
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
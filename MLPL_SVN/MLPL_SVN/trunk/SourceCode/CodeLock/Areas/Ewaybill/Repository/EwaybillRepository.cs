using CodeLock.Helper;
using CodeLock.Models;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CodeLock.Areas.Ewaybill.Repository
{
    public class EwaybillRepository : IEwaybillRepository, IDisposable
    {
        private readonly IEwaybillRepository ewayBillInterface;
        private readonly IDisposable disposable1;
        private EwaybillRepository(IEwaybillRepository ewayBillInterfaces, IDisposable disposable) { 
            this.ewayBillInterface = ewayBillInterfaces;
            this.disposable1 = disposable;
        }
        public EwaybillRepository() { }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string GenerateEwayBill()
        {
            throw new NotImplementedException();
        }
        public MasterLocation GetAPIUSER(short LocationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)LocationId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterLocation>("Usp_MasterLocation_GetById", (object)dynamicParameters, "MasterLocation - GetAPIUser").FirstOrDefault<MasterLocation>();
        }

        public IEnumerable<GetAllStateCredential> GetAllState()
        {
            return DataBaseFactory.QuerySP<GetAllStateCredential>("Usp_Webtel_API_Credential_Detail_Get", (object)null, "State Master - GetAll");
        }
        public IEnumerable<EwaybillSummary> GetSummary()
        {
            return DataBaseFactory.QuerySP<EwaybillSummary>("Usp_EWBDetail_Count_Get", (object)null, "Extend Ewaybill - GetAll");
        }

        public long Insert(EWBMain rootObj)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlData", (object)XmlUtility.XmlSerializeToString((object)rootObj), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@EWB_Header_Id", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            var result= DataBaseFactory.QuerySP("Usp_EWB_Insert", (object)dynamicParameters, "Ewaybill Detail - Insert");
            return dynamicParameters.Get<long>("@EWB_Header_Id");
        }

        public IEnumerable<EWBDetail> GetAllEwaybillDetailByPagination(int pageNo, int pageSize, string sorting, string search)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PageNo", (object)pageNo, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PageSize", (object)pageSize, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Sorting", (object)sorting, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Search", (object)search, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<EWBDetail>("Usp_EwaybillDetail_GetByPagination", (object)dynamicParameters, "Ewaybill - GetByPagination");
        }
        public bool GetUpdateIsSchedulerActiveOrUpdate(string schedulerName, string Type, bool IsActive)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@SchedulerName", (object)schedulerName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Type", (object)Type, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsActive", (object)IsActive, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsOutput", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("usp_Ewaybill_Scheduler_Status_Get_V1", (object)dynamicParameters, "Ewaybill - GetStatus");
            return dynamicParameters.Get<bool>("@IsOutput");
        }

        //*******************  Task Sechdular Methods ******************//
        private Timer timer;
        public void Start()
        {
            DateTime now = DateTime.Now;
            DateTime EwaybillFetchScheduledTime = new DateTime(now.Year, now.Month, now.Day, 22, 54, 0);
            if (now > EwaybillFetchScheduledTime)
            {
                EwaybillFetchScheduledTime = EwaybillFetchScheduledTime.AddDays(1); // If it's past 3:00 PM today, schedule for tomorrow
            }
            int dueTime = (int)(EwaybillFetchScheduledTime - DateTime.Now).TotalMilliseconds;

            timer = new Timer(ExecuteTask, null, dueTime, Timeout.Infinite);
        }

        public void Stop()
        {
            timer?.Dispose();
        }

        public async void ExecuteTask(object state)
        {
            bool isActive = GetUpdateIsSchedulerActiveOrUpdate("DailyEwaybillTaskScheduler", "GetIsActive", false);
            if (isActive)
            {
                try
                {
                    DateTime currentDate = DateTime.Now;
                    DateTime previousDay = currentDate.AddDays(-1);
                    string fetchEwbDate = previousDay.ToString("yyyyMMdd");
                    var model = new EwaybillGetDetailFromWebNoAndDate { EwbDate = fetchEwbDate, StateId = 0 };

                    await SubmitDataInDbAllStates(model);
                }
                catch (Exception ex)
                {
                    var response = ex.Message; // Handle exceptions (log or notify)
                }
                finally
                {
                    Start(); // Reschedule task for next day
                }
            }
            else
            {
                timer?.Dispose();
            }
        }

        public bool IsRunning()
        {
            bool isActive = GetUpdateIsSchedulerActiveOrUpdate("DailyEwaybillTaskScheduler", "GetIsActive", false);
            if (isActive)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<JsonResult> SubmitDataInDbAllStates(EwaybillGetDetailFromWebNoAndDate model)
        {
            try
            {
                IEnumerable<GetAllStateCredential> stateList = GetAllState();

                if (stateList != null)
                {
                    EWBMain rootObject = new EWBMain();

                    foreach (var item in stateList)
                    {
                        try
                        {
                            var httpClient = new HttpClient();
                            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Authorization", "IalkRmh3z4=:::ZH4TUvIeJ3A=");

                            dynamic requestBody = new System.Dynamic.ExpandoObject();
                            requestBody.Date = model.EwbDate;
                            requestBody.EWBUserName = item.API_USER;
                            requestBody.EWBPassword = item.API_PASSWORD;
                            requestBody.GSTIN = item.GstTinNo;

                            if (item.StateId == 4) // for testing scenario
                            {
                                requestBody.Year = 2017;
                                requestBody.Month = 1;
                                requestBody.EFUserName = "29AAACW3775F000";
                                requestBody.EFPassword = "Admin!23..";
                                requestBody.CDKey = 1000687;
                            }
                            else // live scenario
                            {
                                requestBody.Year = 2024;
                                requestBody.Month = 6;
                                requestBody.EFUserName = "039C10BA-5F49-4C9C-98B7-2B14AAFA38E8";
                                requestBody.EFPassword = "1D4331EF-1DFB-43D3-A065-4F24DBBEB1CD";
                                requestBody.CDKey = 1550859;
                            }

                            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
                            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                            string url = item.StateId == 4
                                ? "http://ewaysandbox.webtel.in/Sandbox/EWayBill/v1.3/GetEWBForTransporter"
                                : "http://ewayasp.webtel.in/EWayBill/v1.3/GetEWBForTransporter";

                            var response = await httpClient.PostAsync(url, content);

                            if (response.IsSuccessStatusCode)
                            {
                                var responseData = await response.Content.ReadAsStringAsync();

                                responseData = responseData.Replace("\\\"", "\""); // Replace \" with "
                                responseData = responseData.Replace("\\", ""); // Replace \\ with \
                                responseData = responseData.Replace("\"[", "[");
                                responseData = responseData.Replace("]\"", "]");

                                List<EWBMain> rootList = JsonConvert.DeserializeObject<List<EWBMain>>(responseData);
                                rootObject = rootList.FirstOrDefault(); // Assuming you want to process the first item

                                Insert(rootObject); // Example method to insert into database
                            }
                            else
                            {
                                Console.WriteLine($"Error: API request failed for state {item.StateName}. Status code: {response.StatusCode}");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error occurred for state: {item.StateName}. Error: {ex.Message}");
                            // Log the exception or handle it appropriately
                        }
                    }

                    // Optionally return a success message or data if needed
                     Console.WriteLine(new { success = true, message = "Data submitted successfully.", data = rootObject });
                }
                else
                {
                     Console.WriteLine(new { success = false, message = "Failed to fetch state list from repository.", data = (object)null });
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine(new { success = false, message = $"An error occurred while processing data: {ex.Message}", data = (object)null });
            }
            return null;
        }

    }
}
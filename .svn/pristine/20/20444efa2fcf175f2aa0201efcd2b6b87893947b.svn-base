//  
// Type: CodeLock.Areas.Master.Repository.DcrRepository
//  
//  
//  

using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static Dapper.SqlMapper;

namespace CodeLock.Areas.Master.Repository
{
    public class DcrRepository : BaseRepository, IDcrRepository, IDisposable
    {
        public IEnumerable<MasterDcr> GetAll()
        {
            return DataBaseFactory.QuerySP<MasterDcr>("Usp_Dcr_GetAll", (object)new DynamicParameters(), "Dcr Master - GetAll");
        }

        public bool IsDocumentNoExist(byte documentTypeId, string documentNo, short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocumentTypeId", (object)documentTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNo", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsExist", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterDcr_IsDocumentNoExist", (object)dynamicParameters, "Dcr Master - IsDocumentNoExist");
            return dynamicParameters.Get<bool>("@IsExist");
        }
        public MasterLocation IsDocumentNoDcrDumptcoExist(byte documentTypeId, string documentNo, short locationId, byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocumentTypeId", (object)documentTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNo", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterLocation>("Usp_MasterDcrDumptco_IsDocumentNoExist", (object)dynamicParameters, "Dcr Master - DocumentVoidInsert").FirstOrDefault<MasterLocation>();
        }
        //       return DataBaseFactory.QuerySP<Response>("Usp_DocumentVoid_Insert", (object) dynamicParameters, "Dcr Master - DocumentVoidInsert").FirstOrDefault<Response>();


        public bool IsBookCodeAvailable(byte documentTypeId, string bookCode)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocumentTypeId", (object)documentTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BookCode", (object)bookCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterDcr_IsBookCodeAvailable", (object)dynamicParameters, "Dcr Master - IsBookCodeAvailable");
            return dynamicParameters.Get<bool>("@IsAvailable");
        }

        public bool IsSeriesFromAvailable(byte documentTypeId, string seriesFrom, int totalLeaf)
        {
            string str = "";

            DynamicParameters dynamicParameters = new DynamicParameters();

            if (totalLeaf == 1)
            {
                dynamicParameters.Add("@DocumentTypeId", (object)documentTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@SeriesFrom", (object)seriesFrom, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@SeriesTo", (object)seriesFrom, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                DataBaseFactory.QuerySP("Usp_MasterDcr_IsSeriesFromAvailable", (object)dynamicParameters, "Dcr Master - IsSeriesFromAvailable");
                return dynamicParameters.Get<bool>("@IsAvailable");
            }
            else
            {
                string seriesTo = seriesFrom;
                for (int index = 0; index < totalLeaf - 1; ++index)
                    seriesTo = StringFunctions.NextKeyCode(seriesTo);
                dynamicParameters.Add("@DocumentTypeId", (object)documentTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@SeriesFrom", (object)seriesFrom, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@SeriesTo", (object)seriesTo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                DataBaseFactory.QuerySP("Usp_MasterDcr_IsSeriesFromAvailable", (object)dynamicParameters, "Dcr Master - IsSeriesFromAvailable");
                return dynamicParameters.Get<bool>("@IsAvailable");
            }
        }

        public MasterDcr GetDetailByDocumentTypeIdAndDocumentNumber(
      byte documentTypeId,
      string seriesFrom)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocumentTypeId", (object)documentTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@SeriesFrom", (object)seriesFrom, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterDcr>("Usp_MasterDcr_GetDetailByDocumentTypeIdAndDocumentNumber", (object)dynamicParameters, "Dcr Master - GetDetailByDocumentTypeIdAndDocumentNumber").FirstOrDefault<MasterDcr>();
        }

        public bool CheckValidSeriesFrom(string dcrSeriesFrom, string dcrSeriesTo, string seriesFrom)
        {
            return StringFunctions.IsBetween(seriesFrom, dcrSeriesFrom, dcrSeriesTo);
        }

        public string GetMaxDocumentNumber(long documentId, string dcrSeriesFrom, string seriesFrom)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocumentId", (object)documentId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@MaxDocumentNo", (object)null, new DbType?(DbType.String), new ParameterDirection?(ParameterDirection.Output), new int?(25));
            DataBaseFactory.QuerySP<MasterDcr>("Usp_MasterDcr_GetMaxDocumentNumber", (object)dynamicParameters, "Dcr Master - GetMaxDocumentNumber");
            string str = dynamicParameters.Get<string>("@MaxDocumentNo");
            string strTo = str == null ? string.Empty : str;
            if (StringFunctions.IsBetween(seriesFrom, dcrSeriesFrom, strTo))
                return strTo;
            return string.Empty;
        }

        public int GetTotalLeaf(string seriesFrom, string dcrSeriesTo)
        {
            return StringFunctions.GetDiff(seriesFrom, dcrSeriesTo).ConvertToInt();
        }

        public IEnumerable<MasterDcr> Insert(List<MasterDcr> objMasterDcr)
        {
            List<MasterDcr> masterDcrList = new List<MasterDcr>();
            foreach (MasterDcr masterDcr1 in objMasterDcr)
            {
                string str = masterDcr1.SeriesFrom;
                string KeyCode1 = masterDcr1.SeriesFrom;
                string KeyCode2 = ".";
                string[,] strArray = new string[(masterDcr1.Total / (Decimal)masterDcr1.PageSize).ConvertToInt(), 2];
                int index1 = 0;
                for (int index2 = 2; (Decimal)index2 <= masterDcr1.Total; ++index2)
                {
                    ////string prvkeycode = KeyCode1;
                    ////if(prvkeycode=="99999")
                    ////{
                    ////    KeyCode1 = StringFunctions.NextKeyCode(KeyCode1);
                    ////}
                    KeyCode1 = StringFunctions.NextKeyCode(KeyCode1);

                    ////if (KeyCode1.Contains("A"))
                    ////  {
                    ////             string findnumissue = prvkeycode;
                    ////  }
                    if (index2 % masterDcr1.PageSize == 0)
                    {
                        strArray[index1, 0] = str;
                        strArray[index1, 1] = KeyCode1;
                        str = StringFunctions.NextKeyCode(KeyCode1);
                        ++index1;
                    }
                }
                for (int index2 = 0; index2 <= strArray.GetUpperBound(0); ++index2)
                {
                    if (index2 == 1)
                        KeyCode2 = "Z";
                    if (index2 > 0)
                        KeyCode2 = StringFunctions.NextKeyCode(KeyCode2);
                    if (masterDcr1.Total == new Decimal(1))
                    {
                        strArray[index1, 0] = str;
                        strArray[index1, 1] = KeyCode1;
                    }
                    MasterDcr masterDcr2 = new MasterDcr();
                    masterDcr2.DocumentTypeId = masterDcr1.DocumentTypeId;
                    masterDcr2.BookCode = masterDcr1.BookCode;
                    masterDcr2.SeriesFrom = strArray[index2, 0];
                    masterDcr2.SeriesTo = strArray[index2, 1];
                    masterDcr2.LocationId = masterDcr1.LocationId;
                    masterDcr2.Total = (Decimal)masterDcr1.PageSize;
                    masterDcr2.BusinessTypeId = masterDcr1.BusinessTypeId;
                    masterDcr2.IsActive = true;
                    masterDcr2.Suffix = KeyCode2;
                    masterDcr2.SuffixBase = ".";
                    masterDcr2.EntryBy = masterDcr1.EntryBy;
                    masterDcr2.EntryDate = DateTime.Now;
                    masterDcr2.CompanyId = masterDcr1.CompanyId;
                    MasterDcr masterDcr3 = masterDcr2;
                    masterDcrList.Add(masterDcr3);
                }
            }
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDcr", (object)XmlUtility.XmlSerializeToString((object)masterDcrList), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterDcr>("Usp_MasterDcr_Insert", (object)dynamicParameters, "Dcr Master - Insert");
        }

        public IEnumerable<MasterDcr> DumtcoDcrInsert(List<MasterDcr> objMasterDcr)
        {
            List<MasterDcr> masterDcrList = new List<MasterDcr>();
            foreach (MasterDcr masterDcr1 in objMasterDcr)
            {
                string str = masterDcr1.SeriesFrom;
                string KeyCode1 = masterDcr1.SeriesFrom;
                string KeyCode2 = ".";
                string[,] strArray = new string[(masterDcr1.Total / (Decimal)masterDcr1.PageSize).ConvertToInt(), 2];
                int index1 = 0;
                for (int index2 = 2; (Decimal)index2 <= masterDcr1.Total; ++index2)
                {
                    ////string prvkeycode = KeyCode1;
                    ////if(prvkeycode=="99999")
                    ////{
                    ////    KeyCode1 = StringFunctions.NextKeyCode(KeyCode1);
                    ////}
                    KeyCode1 = StringFunctions.NextKeyCode(KeyCode1);

                    ////if (KeyCode1.Contains("A"))
                    ////  {
                    ////             string findnumissue = prvkeycode;
                    ////  }
                    if (index2 % masterDcr1.PageSize == 0)
                    {
                        strArray[index1, 0] = str;
                        strArray[index1, 1] = KeyCode1;
                        str = StringFunctions.NextKeyCode(KeyCode1);
                        ++index1;
                    }
                }
                for (int index2 = 0; index2 <= strArray.GetUpperBound(0); ++index2)
                {
                    if (index2 == 1)
                        KeyCode2 = "Z";
                    if (index2 > 0)
                        KeyCode2 = StringFunctions.NextKeyCode(KeyCode2);
                    if (masterDcr1.Total == new Decimal(1))
                    {
                        strArray[index1, 0] = str;
                        strArray[index1, 1] = KeyCode1;
                    }
                    MasterDcr masterDcr2 = new MasterDcr();
                    masterDcr2.DocumentTypeId = masterDcr1.DocumentTypeId;
                    masterDcr2.BookCode = masterDcr1.BookCode;
                    masterDcr2.SeriesFrom = strArray[index2, 0];
                    masterDcr2.SeriesTo = strArray[index2, 1];
                    masterDcr2.LocationId = masterDcr1.LocationId;
                    masterDcr2.Total = (Decimal)masterDcr1.PageSize;
                    masterDcr2.BusinessTypeId = masterDcr1.BusinessTypeId;
                    masterDcr2.IsActive = true;
                    masterDcr2.Suffix = KeyCode2;
                    masterDcr2.SuffixBase = ".";
                    masterDcr2.EntryBy = masterDcr1.EntryBy;
                    masterDcr2.EntryDate = DateTime.Now;
                    masterDcr2.CompanyId = masterDcr1.CompanyId;
                    MasterDcr masterDcr3 = masterDcr2;
                    masterDcrList.Add(masterDcr3);
                }
            }
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDcr", (object)XmlUtility.XmlSerializeToString((object)masterDcrList), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterDcr>("Usp_MasterDcrDumtco_Insert", (object)dynamicParameters, "Dcr Master - Insert");
        }

        public Response Split(MasterDcr objMasterDcr)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDcr", (object)XmlUtility.XmlSerializeToString((object)objMasterDcr), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_MasterDcr_Split", (object)dynamicParameters, "Dcr Master - Split").FirstOrDefault<Response>();
        }

        public Response Reallocate(MasterDcr objMasterDcr)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDcr", (object)XmlUtility.XmlSerializeToString((object)objMasterDcr), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_MasterDcr_Reallocate", (object)dynamicParameters, "Dcr Master - Reallocate").FirstOrDefault<Response>();
        }

        public IEnumerable<MasterDocumentControl> GetListByDocumentTypeId(
          byte documentTypeId,
          byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocumentTypeId", (object)documentTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterDocumentControl>("Usp_MasterDcr_GetListByDocumentTypeId", (object)dynamicParameters, "Dcr Master - GetListByDocumentTypeId");
        }

        public IEnumerable<DcrManagementHistory> GetManagementHistoryByDocumentTypeIdAndDocumentNumber(
          byte documentTypeId,
          string seriesFrom)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocumentTypeId", (object)documentTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@SeriesFrom", (object)seriesFrom, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DcrManagementHistory>("Usp_MasterDcr_GetManagementHistoryByDocumentTypeIdAndDocumentNumber", (object)dynamicParameters, "Dcr Master - GetManagementHistoryByDocumentTypeIdAndDocumentNumber");
        }

        public Response IsDocumentAvailableForVoid(
          byte documentTypeId,
          string documentNo,
          short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocumentTypeId", (object)documentTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNo", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_DocumentVoid_IsDocumentAvailable", (object)dynamicParameters, "Dcr Master - IsDocumentAvailableForVoid").FirstOrDefault<Response>();
        }

        public Response DocumentVoidInsert(
          long dcrId,
          string documentNo,
          short entryBy,
          byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DcrId", (object)dcrId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNo", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@EntryBy", (object)entryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_DocumentVoid_Insert", (object)dynamicParameters, "Dcr Master - DocumentVoidInsert").FirstOrDefault<Response>();
        }

        public bool IsSeriesFromAvailableAFC(byte documentTypeId, string seriesFrom, int totalLeaf)
        {
            string str = "";

            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@DocumentTypeId", (object)documentTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@SeriesFrom", (object)seriesFrom, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@SeriesTo", (object)totalLeaf, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterDcr_IsSeriesFromAvailable", (object)dynamicParameters, "Dcr Master - IsSeriesFromAvailable");
            return dynamicParameters.Get<bool>("@IsAvailable");
        }

        public IEnumerable<MasterDcr> InsertAFC(List<MasterDcr> objMasterDcr)
        {
            List<MasterDcr> masterDcrList = new List<MasterDcr>();
            foreach (MasterDcr masterDcr1 in objMasterDcr)
            {
                MasterDcr masterDcr2 = new MasterDcr();
                masterDcr2.DocumentTypeId = masterDcr1.DocumentTypeId;
                masterDcr2.BookCode = masterDcr1.BookCode;
                masterDcr2.SeriesFrom = masterDcr1.SeriesFrom;
                masterDcr2.SeriesTo = masterDcr1.Total.ToString();
                masterDcr2.LocationId = masterDcr1.LocationId;
                masterDcr2.Total = (Decimal)masterDcr1.Total;
                masterDcr2.BusinessTypeId = masterDcr1.BusinessTypeId;
                masterDcr2.IsActive = true;
                masterDcr2.Suffix = "";
                masterDcr2.SuffixBase = ".";
                masterDcr2.EntryBy = masterDcr1.EntryBy;
                masterDcr2.EntryDate = DateTime.Now;
                masterDcr2.CompanyId = masterDcr1.CompanyId;
                MasterDcr masterDcr3 = masterDcr2;
                masterDcrList.Add(masterDcr3);
            }
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDcr", (object)XmlUtility.XmlSerializeToString((object)masterDcrList), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterDcr>("Usp_MasterDcr_Insert", (object)dynamicParameters, "Dcr Master - Insert");
        }

        public short GetDcrNoLength(byte documentTypeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocumentTypeId", documentTypeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNoLength", (object)null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterDcr_GetDcrNoLength", (object)dynamicParameters, "Dcr Master - GetDcrNoLength");
            return dynamicParameters.Get<short>("@DocumentNoLength");
        }
    }
}

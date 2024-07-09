//  
// Type: FileUploadHelper
//  
//  
//  

using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

public class FileUploadHelper
{
  public FileUploadHelper()
  {
    this.RequiredColumnMapping = false;
  }

  public string strResultMessage { get; set; }

  public bool RequiredColumnMapping { get; set; }

  public HttpPostedFileBase fileUploadControl { get; set; }

  public string strFileNamePrefix { get; set; }

  public string strFilePath { get; set; }

  public DataTable dtFormat { get; set; }

  public string strModuleName { get; set; }

  public string strProcedureName { get; set; }

  public void CheckValidColumnName(
    DataTable dt,
    string strFieldName,
    string strFieldCaption,
    bool isChargeConsider)
  {
    string str = " column is missing";
    if (!dt.Columns.Contains(strFieldCaption))
    {
      if (!isChargeConsider && !strFieldCaption.Contains("Charge"))
        throw new Exception(strFieldCaption + str);
    }
    else
    {
      dt.Columns[strFieldCaption].ColumnName = strFieldName;
      if (strFieldName.ToLower().Contains("datetime") && dt.Columns[strFieldName].DataType == typeof (DateTime))
        dt.Columns[strFieldName].DateTimeMode = DataSetDateTime.Unspecified;
    }
  }

  public void SetCaption(DataTable dtResult, string strFieldName, string strFieldCaption)
  {
    if (!dtResult.Columns.Contains(strFieldName))
      return;
    dtResult.Columns[strFieldName].ColumnName = strFieldCaption;
  }

  public string Upload(bool isChargeConsider)
  {
    string str1 = string.Empty;
    if (this.fileUploadControl.ContentLength <= 0)
      throw new Exception("Please Select Excel File.");
    string str2 = new Regex("(?:.+)(.+)\\.(.+)").Match(this.fileUploadControl.FileName).Groups[2].Captures[0].ToString();
    string str3 = this.strFileNamePrefix + "_" + DateTime.Now.ToString("ddMMyyyy") + "." + str2;
    if (str2.ToLower() != "xls" && str2.ToLower() != "xlsx" && str2.ToLower() != "csv")
      throw new Exception("Invalid File");
    string path = HttpContext.Current.Server.MapPath(this.strFilePath);
    if (Directory.Exists(path))
    {
      if (File.Exists(path + "\\" + str3))
        File.Delete(path + "\\" + str3);
    }
    else
      Directory.CreateDirectory(path);
    this.fileUploadControl.SaveAs(path + "\\" + str3);
    ExcelUtilities excelUtilities = new ExcelUtilities();
    DataSet dataSet = new DataSet();
    DataSet excelData = excelUtilities.GetExcelData(path + "\\" + str3);
    if (excelData == null)
      throw new Exception("Invalid File. No Records Found");
    DataTable table = excelData.Tables[0];
    if (table.Columns.Count != table.Columns.Count)
      throw new Exception("Invalid no of columns.");
    if (table.Rows.Count < 1)
      throw new Exception("Please input at-least one record.");
    foreach (DataRow row in (InternalDataCollectionBase) this.dtFormat.Rows)
    {
        this.CheckValidColumnName(table, row["FieldName"].ToString(), row["FieldCaption"].ToString(), isChargeConsider);
    }
   label_20:
    for (int index = 0; index < table.Rows.Count; ++index)
    {
      if (table.Rows[index][0].ToString() == "")
      {
        table.Rows.RemoveAt(index);
        goto label_20;
      }
    }
    if (table.Rows.Count < 1)
      throw new Exception("Please input at-least one record.");
    excelData.DataSetName = this.strModuleName + "List";
    excelData.Tables[0].TableName = this.strModuleName;
    if (this.RequiredColumnMapping)
    {
      foreach (DataColumn column in (InternalDataCollectionBase) excelData.Tables[0].Columns)
        column.ColumnMapping = MappingType.Attribute;
    }
    if (File.Exists(path + "\\" + str3))
      File.Delete(path + "\\" + str3);
    str1 = excelData.GetXml();
    return excelData.GetXml().Replace("_x0020_", "_").Replace("_x0028_", "_").Replace("_x0029_", "");
  }
}

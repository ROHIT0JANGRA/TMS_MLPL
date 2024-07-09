//  
// Type: ExcelUtilities
//  
//  
//  

using Excel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

public class ExcelUtilities
{
  private string _Error_Message = "";

  public string Error_Message
  {
    get
    {
      return this._Error_Message;
    }
    set
    {
      this._Error_Message = value;
    }
  }

  public DataSet GetExcelData(string fileName)
  {
    DataSet dataSet = new DataSet();
    try
    {
      string str = new Regex("(?:.+)(.+)\\.(.+)").Match(fileName).Groups[2].Captures[0].ToString();
      if (str.ToLower() != "xls" && str.ToLower() != "xlsx")
        throw new Exception("Invalid File");
      FileStream fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read);
      try
      {
        if (str.ToLower() == "xls")
        {
          IExcelDataReader binaryReader = ExcelReaderFactory.CreateBinaryReader((Stream) fileStream);
          binaryReader.IsFirstRowAsColumnNames = true;
          dataSet = binaryReader.AsDataSet();
        }
        if (str.ToLower() == "xlsx")
        {
          IExcelDataReader openXmlReader = ExcelReaderFactory.CreateOpenXmlReader((Stream) fileStream);
          openXmlReader.IsFirstRowAsColumnNames = true;
          dataSet = openXmlReader.AsDataSet();
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        fileStream.Close();
        fileStream.Dispose();
      }
    }
    catch (Exception ex)
    {
      this.Error_Message = ex.Message;
      dataSet = (DataSet) null;
    }
    finally
    {
    }
    return dataSet;
  }

  public static DataSet ReadExcelData(string fileName)
  {
    DataSet dataSet = new DataSet();
    try
    {
      string str = new Regex("(?:.+)(.+)\\.(.+)").Match(fileName).Groups[2].Captures[0].ToString();
      if (str.ToLower() != "xls" && str.ToLower() != "xlsx")
        throw new Exception("Invalid File");
      FileStream fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read);
      try
      {
        if (str.ToLower() == "xls")
        {
          IExcelDataReader binaryReader = ExcelReaderFactory.CreateBinaryReader((Stream) fileStream);
          binaryReader.IsFirstRowAsColumnNames = true;
          dataSet = binaryReader.AsDataSet();
        }
        if (str.ToLower() == "xlsx")
        {
          IExcelDataReader openXmlReader = ExcelReaderFactory.CreateOpenXmlReader((Stream) fileStream);
          openXmlReader.IsFirstRowAsColumnNames = true;
          dataSet = openXmlReader.AsDataSet();
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        fileStream.Close();
        fileStream.Dispose();
      }
    }
    catch (Exception ex)
    {
      dataSet = (DataSet) null;
      throw ex;
    }
    finally
    {
    }
    return dataSet;
  }

  public void ExportExcel_XLSX(DataSet ds, string filename)
  {
    using (ExcelPackage excelPackage = new ExcelPackage())
    {
      foreach (DataTable table in (InternalDataCollectionBase) ds.Tables)
      {
        ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(table.TableName);
        int index1 = 1;
        foreach (DataColumn column in (InternalDataCollectionBase) table.Columns)
        {
          int index2 = 1;
          excelWorksheet.Cells[index2, index1].Value = (object) column.ColumnName;
          excelWorksheet.Cells[index2, index1].Style.Fill.PatternType = ExcelFillStyle.Solid;
          excelWorksheet.Cells[index2, index1].Style.Fill.BackgroundColor.SetColor(Color.LightSlateGray);
          excelWorksheet.Cells[index2, index1].Style.Font.Color.SetColor(Color.White);
          excelWorksheet.Cells[index2, index1].Style.Font.Bold = true;
          excelWorksheet.Cells[index2, index1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
          int index3 = 2;
          foreach (DataRow row in (InternalDataCollectionBase) table.Rows)
          {
            excelWorksheet.Cells[index3, index1].Value = (object) row[column.ColumnName].ToString();
            excelWorksheet.Cells[index3, index1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ++index3;
          }
          ++index1;
        }
      }
      HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
      HttpContext.Current.Response.AddHeader("content-disposition", "attachment;  filename=" + filename);
      HttpContext.Current.Response.BinaryWrite(excelPackage.GetAsByteArray());
    }
  }

  public void ExportExcel(DataSet ds, string fileName)
  {
    string str = HttpContext.Current.Server.MapPath("./" + fileName);
    if (File.Exists(str))
      File.Delete(str);
    using (ExcelPackage excelPackage = new ExcelPackage())
    {
      foreach (DataTable table in (InternalDataCollectionBase) ds.Tables)
      {
        ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(table.TableName);
        int index1 = 1;
        foreach (DataColumn column in (InternalDataCollectionBase) table.Columns)
        {
          int index2 = 1;
          excelWorksheet.Cells[index2, index1].Value = (object) column.ColumnName;
          excelWorksheet.Cells[index2, index1].Style.Fill.PatternType = ExcelFillStyle.Solid;
          excelWorksheet.Cells[index2, index1].Style.Fill.BackgroundColor.SetColor(Color.LightSlateGray);
          excelWorksheet.Cells[index2, index1].Style.Font.Color.SetColor(Color.White);
          excelWorksheet.Cells[index2, index1].Style.Font.Bold = true;
          excelWorksheet.Cells[index2, index1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
          int index3 = 2;
          foreach (DataRow row in (InternalDataCollectionBase) table.Rows)
          {
            excelWorksheet.Cells[index3, index1].Value = (object) row[column.ColumnName].ToString();
            excelWorksheet.Cells[index3, index1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ++index3;
          }
          ++index1;
        }
      }
      excelPackage.SaveAs(new FileInfo(str));
    }
    HttpContext.Current.Response.Redirect("./" + fileName, false);
  }
}

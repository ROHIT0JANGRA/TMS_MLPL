//  
// Type: ExceptionUtility
//  
//  
//  

using CodeLock.Helper;
using CodeLock.Models;
using Dapper;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

public sealed class ExceptionUtility
{
  public static int LogException(Exception exc, string source)
  {
    return ExceptionUtility.Log(exc, source, (short) 0, "");
  }

  public static int LogException(Exception exc, string source, short userId)
  {
    return ExceptionUtility.Log(exc, source, userId, "");
  }

  public static int LogException(Exception exc, string source, short userId, string PageName)
  {
    return ExceptionUtility.Log(exc, source, userId, PageName);
  }

  private static int Log(Exception exc, string source, short userId, string pageName)
  {
    ExceptionUtility.logConnectionTimeOut(exc, source, pageName);
    ErrorLog errorLog = new ErrorLog();
    if (exc.InnerException != null)
    {
      errorLog.InnerException = exc.InnerException.Message;
      errorLog.InnerExceptionType = exc.InnerException.GetType().ToString();
      errorLog.InnerSource = exc.InnerException.Source;
      errorLog.InnerStackTrace = exc.InnerException.StackTrace;
    }
    errorLog.ModuleName = source;
    errorLog.Exception = exc.Message;
    errorLog.ExceptionType = exc.GetType().ToString();
    errorLog.ExceptionSource = exc.Source;
    if (exc.StackTrace != null)
      errorLog.StackTrace = exc.StackTrace;
    DynamicParameters dynamicParameters = new DynamicParameters();
    dynamicParameters.Add("@XmlError", (object) XmlUtility.XmlSerializeToString((object) errorLog), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
    dynamicParameters.Add("@ErrorId", (object) null, new DbType?(DbType.Int32), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
    using (DbConnection cnn = DataBaseFactory.ConnString())
    {
      cnn.Open();
      cnn.Execute("Usp_Error_Insert", (object) dynamicParameters, (IDbTransaction) null, new int?(), new CommandType?(CommandType.StoredProcedure));
      cnn.Close();
    }
    return dynamicParameters.Get<int>("@ErrorId");
  }

  public static bool logConnectionTimeOut(Exception ex, string PageSource, string PageURL)
  {
    return ExceptionUtility.isConnectionTimeOut(ex);
  }

  public static bool isConnectionTimeOut(Exception ex)
  {
    SqlException sqlException = ex as SqlException ?? ex.InnerException as SqlException;
    return sqlException != null && sqlException.Number == -2;
  }

  public static void NotifySystemOps(Exception exc)
  {
  }
}

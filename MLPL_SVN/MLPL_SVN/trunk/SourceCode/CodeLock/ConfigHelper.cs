//  
// Type: ConfigHelper
//  
//  
//  

using System;
using System.Configuration;
using System.Web;

public class ConfigHelper
{
    public static string DateFormat
    {
        get
        {
            return ConfigurationManager.AppSettings[nameof(DateFormat)];
        }
    }

    public static string TimeFormat
    {
        get
        {
            return ConfigurationManager.AppSettings[nameof(TimeFormat)];
        }
    }

    public static string DateTimeFormat
    {
        get
        {
            return ConfigurationManager.AppSettings["DateFormat"].ToString() + " " + ConfigHelper.TimeFormat;
        }
    }

    public static string DisplayDateFormat
    {
        get
        {
            return ConfigurationManager.AppSettings[nameof(DisplayDateFormat)];
        }
    }

    public static string DisplayDateTimeFormat
    {
        get
        {
            return ConfigurationManager.AppSettings["DisplayDateFormat"].ToString() + " " + ConfigHelper.TimeFormat;
        }
    }

    public static string JsDateFormat
    {
        get
        {
            return ConfigurationManager.AppSettings[nameof(JsDateFormat)];
        }
    }

    public static string JsTimeFormat
    {
        get
        {
            return ConfigurationManager.AppSettings[nameof(JsTimeFormat)];
        }
    }

    public static string JsDateTimeFormat
    {
        get
        {
            return ConfigurationManager.AppSettings["JsDateFormat"].ToString() + " " + ConfigHelper.JsTimeFormat;
        }
    }

    public static string JsDisplayDateFormat
    {
        get
        {
            return ConfigurationManager.AppSettings[nameof(JsDisplayDateFormat)];
        }
    }

    public static string JsDisplayDateTimeFormat
    {
        get
        {
            return ConfigurationManager.AppSettings["JsDisplayDateFormat"].ToString() + " " + ConfigHelper.JsTimeFormat;
        }
    }

    public static string ReportServer
    {
        get
        {
            return ConfigurationManager.AppSettings[nameof(ReportServer)];
        }
    }

    public static string ReportServerUrl
    {
        get
        {
            return ConfigurationManager.AppSettings[nameof(ReportServerUrl)];
        }
    }

    public static string ReportServerUser
    {
        get
        {
            return ConfigurationManager.AppSettings[nameof(ReportServerUser)];
        }
    }

    public static string ReportServerPassword
    {
        get
        {
            return ConfigurationManager.AppSettings[nameof(ReportServerPassword)];
        }
    }

    public static string ReportServerPath
    {
        get
        {
            return ConfigurationManager.AppSettings[nameof(ReportServerPath)];
        }
    }

    public static DateTime GstDate
    {
        get
        {
            return Convert.ToDateTime(ConfigurationManager.AppSettings[nameof(GstDate)]);
        }
    }

    public static bool IsLocalStorage
    {
        get
        {
            return ConfigurationManager.AppSettings[nameof(IsLocalStorage)] == "Y";
        }
    }

    public static string LocalStoragePath
    {
        get
        {
            return HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings[nameof(LocalStoragePath)]);
        }
    }
    public static string JsLocalStoragePath
    {
        get { return ConfigurationManager.AppSettings[nameof(LocalStoragePath)].Replace("~", ""); }
    }

    public static string CloudStoragePath
    {
        get
        {
            return "http://" + ConfigurationManager.AppSettings["CloudStorageString"] + "/" + ConfigurationManager.AppSettings["SOPContainerName"] + "/";
        }
    }
}

//  
// Type: CodeLock.SessionUtility
//  
//  
//  

using System;
using System.Web;

namespace CodeLock
{
  public class SessionUtility
  {

        public static string LoginUserRoleName
        {
            get  
            {
                return SessionUtility.GetFromSession(nameof(LoginUserRoleName)).ConvertToString();
            }
            set
            {
                SessionUtility.SetToSession(nameof(LoginUserRoleName), (object)value);
            }
        }

        private static object GetFromSession(string key)
    {
            //if (HttpContext.Current.Session[key] == null)
            //{
            //    return null;
            //}
            //else
            //{
            //    return HttpContext.Current.Session[key];
            //}
            return HttpContext.Current.Session[key];
        }

    private static void SetToSession(string key, object value)
    {
      HttpContext.Current.Session[key] = value;
    }

    public static short LoginUserId
    {
      get
      {
        return SessionUtility.GetFromSession(nameof (LoginUserId)).ConvertToShort();
      }
      set
      {
        SessionUtility.SetToSession(nameof (LoginUserId), (object) value);
      }
    }

        public static short LocationHierarchyId
        {
            get
            {
                return SessionUtility.GetFromSession(nameof(LocationHierarchyId)).ConvertToShort();
            }
            set
            {
                SessionUtility.SetToSession(nameof(LocationHierarchyId), (object)value);
            }
        }
        

    public static string LoginUserName
    {
      get
      {
        return SessionUtility.GetFromSession(nameof (LoginUserName)).ConvertToString();
      }
      set
      {
        SessionUtility.SetToSession(nameof (LoginUserName), (object) value);
      }
    }

    public static short LoginLocationId
    {
      get
      {
        return SessionUtility.GetFromSession(nameof (LoginLocationId)).ConvertToShort();
      }
      set
      {
        SessionUtility.SetToSession(nameof (LoginLocationId), (object) value);
      }
    }

    public static string LoginLocationCode
    {
      get
      {
        return SessionUtility.GetFromSession(nameof (LoginLocationCode)).ConvertToString();
      }
      set
      {
        SessionUtility.SetToSession(nameof (LoginLocationCode), (object) value);
      }
    }

    public static string CompanyCode
    {
      get
      {
        return SessionUtility.GetFromSession(nameof (CompanyCode)).ConvertToString();
      }
      set
      {
        SessionUtility.SetToSession(nameof (CompanyCode), (object) value);
      }
    }

    public static string CompanyName
    {
      get
      {
        return SessionUtility.GetFromSession(nameof (CompanyName)).ConvertToString();
      }
      set
      {
        SessionUtility.SetToSession(nameof (CompanyName), (object) value);
      }
    }

    public static short LoginUserLocationId
    {
      get
      {
        return SessionUtility.GetFromSession(nameof (LoginUserLocationId)).ConvertToShort();
      }
      set
      {
        SessionUtility.SetToSession(nameof (LoginUserLocationId), (object) value);
      }
    }

    public static byte CompanyId
    {
      get
      {
        return SessionUtility.GetFromSession("DefaultCompanyCode").ConvertToByte();
      }
      set
      {
        SessionUtility.SetToSession("DefaultCompanyCode", (object) value);
      }
    }

    public static short WarehouseId
    {
      get
      {
        return SessionUtility.GetFromSession(nameof (WarehouseId)).ConvertToShort();
      }
      set
      {
        SessionUtility.SetToSession(nameof (WarehouseId), (object) value);
      }
    }

    public static string WarehouseName
    {
      get
      {
        return SessionUtility.GetFromSession(nameof (WarehouseName)).ConvertToString();
      }
      set
      {
        SessionUtility.SetToSession(nameof (WarehouseName), (object) value);
      }
    }

    public static string FinYear
    {
      get
      {
        return SessionUtility.GetFromSession(nameof (FinYear)).ConvertToString();
      }
      set
      {
        SessionUtility.SetToSession(nameof (FinYear), (object) value);
      }
    }

    public static DateTime FinStartDate
    {
      get
      {
        return SessionUtility.GetFromSession(nameof (FinStartDate)).ConvertToDateTime();
      }
      set
      {
        SessionUtility.SetToSession(nameof (FinStartDate), (object) value);
      }
    }

    public static DateTime FinEndDate
    {
      get
      {
        return SessionUtility.GetFromSession(nameof (FinEndDate)).ConvertToDateTime();
      }
      set
      {
        SessionUtility.SetToSession(nameof (FinEndDate), (object) value);
      }
    }

    public static DateTime CalYrStartDate
     {
            get
            {
                return SessionUtility.GetFromSession(nameof(CalYrStartDate)).ConvertToDateTime();
            }
            set
            {
                SessionUtility.SetToSession(nameof(CalYrStartDate), (object)value);
            }
    }

        public static DateTime CalYrEndDate
        {
            get
            {
                return SessionUtility.GetFromSession(nameof(CalYrEndDate)).ConvertToDateTime();
            }
            set
            {
                SessionUtility.SetToSession(nameof(CalYrEndDate), (object)value);
            }
        }


        public static string CalenderYear
    {
      get
      {
        return SessionUtility.GetFromSession(nameof (CalenderYear)).ToString();
      }
      set
      {
        SessionUtility.SetToSession(nameof (CalenderYear), (object) value);
      }
    }

    public static string DocketNomenClature
    {
      get
      {
        return SessionUtility.GetFromSession(nameof (DocketNomenClature)).ToString();
      }
      set
      {
        SessionUtility.SetToSession(nameof (DocketNomenClature), (object) value);
      }
    }

    public static string PrsNomenclature
    {
      get
      {
        return SessionUtility.GetFromSession(nameof (PrsNomenclature)).ToString();
      }
      set
      {
        SessionUtility.SetToSession(nameof (PrsNomenclature), (object) value);
      }
    }

    public static string LoadingSheetNomenclature
    {
      get
      {
        return SessionUtility.GetFromSession(nameof (LoadingSheetNomenclature)).ToString();
      }
      set
      {
        SessionUtility.SetToSession(nameof (LoadingSheetNomenclature), (object) value);
      }
    }

    public static string ManifestNomenclature
    {
      get
      {
        return SessionUtility.GetFromSession(nameof (ManifestNomenclature)).ToString();
      }
      set
      {
        SessionUtility.SetToSession(nameof (ManifestNomenclature), (object) value);
      }
    }

    public static string ThcNomenclature
    {
      get
      {
        return SessionUtility.GetFromSession(nameof (ThcNomenclature)).ToString();
      }
      set
      {
        SessionUtility.SetToSession(nameof (ThcNomenclature), (object) value);
      }
    }

    public static string DrsNomenclature
    {
      get
      {
        return SessionUtility.GetFromSession(nameof (DrsNomenclature)).ToString();
      }
      set
      {
        SessionUtility.SetToSession(nameof (DrsNomenclature), (object) value);
      }
    }

    public static DateTime Now
    {
      get
      {
        return SessionUtility.ConvertTimeFromUtc(DateTime.UtcNow);
      }
    }

    public static DateTime ConvertTimeFromUtc(DateTime utcdt)
    {
      return TimeZoneInfo.ConvertTimeFromUtc(utcdt, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
    }

    public static void ManageFinYear(string finYearValue, string finYearName)
    {
      SessionUtility.FinYear = finYearValue;
      SessionUtility.FinStartDate = ("01 Apr " + finYearName.Split('-')[0]).ConvertToDateTime();
      SessionUtility.FinEndDate = ("31 Mar " + finYearName.Split('-')[1]).ConvertToDateTime();

      SessionUtility.CalYrStartDate = ("01 Jan " + finYearName.Split('-')[0]).ConvertToDateTime();
      SessionUtility.CalYrEndDate = ("31 Dec " + finYearName.Split('-')[0]).ConvertToDateTime();
    
      SessionUtility.CalenderYear = finYearName.Split('-')[0];
    }
  }
}

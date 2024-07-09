
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

public static class ExtensionHelper
{
    public static string ToDisplayDate(this DateTime dt)
    {
        return dt.ToString("dd MMM yyyy");
    }

    public static string ToDisplayDate(this DateTime? dt)
    {
        string str;
        if (!dt.HasValue)
        {
            str = "";
        }
        else
        {
            DateTime? nullable = dt;
            DateTime dateTime = new DateTime(1900, 1, 1);
            str = (!nullable.HasValue ? 1 : (nullable.GetValueOrDefault() != dateTime ? 1 : 0)) != 0 ? Convert.ToDateTime((object)dt).ToString("dd MMM yyyy") : "";
        }
        return str;
    }

    public static string ToDisplayDateTime(this DateTime dt)
    {
        return dt.ToString("dd MMM yyyy HH:mm");
    }

    public static string ToDisplayDateTime(this DateTime? dt)
    {
        string str;
        if (!dt.HasValue)
        {
            str = "";
        }
        else
        {
            DateTime? nullable = dt;
            DateTime dateTime = new DateTime(1900, 1, 1);
            str = (!nullable.HasValue ? 1 : (nullable.GetValueOrDefault() != dateTime ? 1 : 0)) != 0 ? Convert.ToDateTime((object)dt).ToString("dd MMM yyyy HH:mm") : "";
        }
        return str;
    }

    public static string ConvertToString(this object obj)
    {
        return Convert.ToString(obj).Trim();
    }

    public static byte ConvertToByte(this object obj)
    {
        byte num;
        try
        {
            byte result;
            if (obj == null)
                result = (byte)0;
            else
                byte.TryParse(obj.ToString(), out result);
            num = result;
        }
        catch
        {
            num = (byte)0;
        }
        return num;
    }

    public static short ConvertToShort(this object obj)
    {
        short num;
        try
        {
            num = Convert.ToInt16(obj);
        }
        catch
        {
            num = (short)0;
        }
        return num;
    }

    public static int ConvertToInt(this object obj)
    {
        int num;
        try
        {
            num = Convert.ToInt32(obj);
        }
        catch
        {
            num = 0;
        }
        return num;
    }

    public static long ConvertToLong(this object obj)
    {
        long num;
        try
        {
            num = Convert.ToInt64(obj);
        }
        catch
        {
            num = 0L;
        }
        return num;
    }

    public static Decimal ConvertToDecimal(this object obj)
    {
        Decimal num;
        try
        {
            num = Convert.ToDecimal(obj);
        }
        catch (Exception ex)
        {
            num = new Decimal(0);
        }
        return num;
    }

    public static double ConvertToDouble(this object obj)
    {
        double num;
        try
        {
            num = Convert.ToDouble(obj);
        }
        catch (Exception ex)
        {
            num = 0.0;
        }
        return num;
    }

    public static float ConvertToFloat(this object obj)
    {
        float num;
        try
        {
            float result;
            float.TryParse(obj.ToString(), out result);
            num = result;
        }
        catch (Exception ex)
        {
            num = 0.0f;
        }
        return num;
    }

    public static bool ConvertToBool(this object obj)
    {
        bool flag;
        try
        {
            flag = Convert.ToBoolean(obj);
        }
        catch (Exception ex)
        {
            flag = false;
        }
        return flag;
    }

    public static DateTime ConvertToDateTime(this object obj)
    {
        DateTime now;
        try
        {
            DateTime result;
            if (DateTime.TryParse((obj ?? (object)"").ToString(), out result))
                return result;
            return DateTime.Now;
        }
        catch (Exception ex)
        {
            now = DateTime.Now;
        }
        return now;
    }

    public static DateTime? ConvertToNullableDateTime(this DateTime dt)
    {
        if (dt == DateTime.MinValue)
            return new DateTime?();
        return new DateTime?(dt);
    }

    public static string AbsoluteAction(
      this UrlHelper url,
      string actionName,
      string controllerName,
      object routeValues = null)
    {
        string scheme = url.RequestContext.HttpContext.Request.Url.Scheme;
        return url.Action(actionName, controllerName, routeValues, scheme);
    }

    public static T CopyPropertiesJson<T>(object source)
    {
        return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
    }
    public static T CloneData<T>(object source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        T instance = (T)Activator.CreateInstance(typeof(T));
        Type sourceType = source.GetType();
        Type targetType = typeof(T);

        foreach (PropertyInfo sourceProperty in sourceType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
        {
            try
            {
                PropertyInfo targetProperty = targetType.GetProperty(sourceProperty.Name, BindingFlags.Instance | BindingFlags.Public);
                if (targetProperty != null && targetProperty.CanWrite)
                {
                    targetProperty.SetValue(instance, sourceProperty.GetValue(source));
                }
            }
            catch (ArgumentException ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    return default(T);
                }
            }
        }
        return instance;
    }

    //public static T CloneData<T>(object source)
    //{
    //    T instance = (T)Activator.CreateInstance(typeof(T));
    //    Type type1 = source.GetType();
    //    Type type2 = instance.GetType();
    //    foreach (PropertyInfo property1 in type1.GetProperties(BindingFlags.Instance | BindingFlags.Public))
    //    {
    //        try
    //        {
    //            PropertyInfo property2 = type2.GetProperty(property1.Name, BindingFlags.Instance | BindingFlags.Public);
    //            if (property2 != (PropertyInfo)null)
    //                property2.SetValue((object)instance, property1.GetValue(source));
    //        }
    //        catch (ArgumentException ex)
    //        {
    //            if (!string.IsNullOrEmpty(ex.Message))
    //                return T ;
    //        }
    //        catch (Exception ex)
    //        {
    //            if (!string.IsNullOrEmpty(ex.Message))
    //                return default(T);
    //        }
    //    }
    //    return instance;
    //}

    //public static List<TSource> ToList<TSource>(this DataTable dataTable) where TSource : new()
    //{
    //    List<TSource> sourceList = new List<TSource>();
    //    List <\u003C\u003Ef__AnonymousType2a < string, Type >> list1 = typeof(TSource).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Cast<PropertyInfo>().Select(aProp =>
    //    {
    //        string name = aProp.Name;
    //        Type type = Nullable.GetUnderlyingType(aProp.PropertyType);
    //        if ((object)type == null)
    //            type = aProp.PropertyType;
    //        var data = new { Name = name, Type = type };
    //        return data;
    //    }).ToList();
    //    for (int index1 = 0; index1 < list1.Count; ++index1)
    //    {
    //        var data = list1[index1];
    //        for (int index2 = 0; index2 < dataTable.Columns.Count; ++index2)
    //        {
    //            if (data.Name.ToUpper() == dataTable.Columns[index2].ColumnName.ToUpper())
    //                dataTable.Columns[index2].ColumnName = data.Name;
    //        }
    //    }
    //    List <\u003C\u003Ef__AnonymousType2a < string, Type >> list2 = dataTable.Columns.Cast<DataColumn>().Select(aHeader =>
    //    {
    //        var data = new
    //        {
    //            Name = aHeader.ColumnName,
    //            Type = aHeader.DataType
    //        };
    //        return data;
    //    }).ToList();
    //    List <\u003C\u003Ef__AnonymousType2a < string, Type >> list3 = list1.Intersect(list2).ToList();
    //    foreach (DataRow dataRow in dataTable.AsEnumerable().ToList<DataRow>())
    //    {
    //        TSource source = new TSource();
    //        foreach (var data in list3)
    //        {
    //            PropertyInfo property = source.GetType().GetProperty(data.Name);
    //            if (dataRow[data.Name] == DBNull.Value)
    //            {
    //                switch (data.Type.FullName)
    //                {
    //                    case "System.DateTime":
    //                        property.SetValue((object)source, (object)DateTime.MinValue, (object[])null);
    //                        break;
    //                    case "System.String":
    //                        property.SetValue((object)source, (object)"", (object[])null);
    //                        break;
    //                    case "System.Decimal":
    //                    case "System.Double":
    //                    case "System.Int16":
    //                    case "System.Int32":
    //                    case "System.Int64":
    //                        property.SetValue((object)source, (object)0, (object[])null);
    //                        break;
    //                    case "System.Boolean":
    //                        property.SetValue((object)source, (object)false, (object[])null);
    //                        break;
    //                }
    //            }
    //            else
    //                property.SetValue((object)source, dataRow[data.Name], (object[])null);
    //        }
    //        sourceList.Add(source);
    //    }
    //    return sourceList;
    //}

    public static IEnumerable<TA> Except<TA, TB, TK>(
      this IEnumerable<TA> a,
      IEnumerable<TB> b,
      Func<TA, TK> selectKeyA,
      Func<TB, TK> selectKeyB,
      IEqualityComparer<TK> comparer = null)
    {
        return a.Where<TA>((Func<TA, bool>)(aItem => !b.Select<TB, TK>((Func<TB, TK>)(bItem => selectKeyB(bItem))).Contains<TK>(selectKeyA(aItem), comparer)));
    }

    //public static IEnumerable<T> Except<T, TKey>(
    //  this IEnumerable<T> items,
    //  IEnumerable<T> other,
    //  Func<T, TKey> getKey)
    //{
    //    return items.GroupJoin(other, (Func<T, TKey>)(item => getKey(item)), (Func<T, TKey>)(otherItem => getKey(otherItem)), (item, tempItems) =>
    //    {
    //        var data = new { item = item, tempItems = tempItems };
    //        return data;
    //    }).SelectMany(_param0 => _param0.tempItems.DefaultIfEmpty<T>(), (_param0, temp) =>
    //    {
    //        var data = new
    //        {
    //    \u003C\u003Eh__TransparentIdentifier6 = _param0,
    //            temp = temp
    //        };
    //        return data;
    //    }).Where(_param0 => object.ReferenceEquals((object)null, (object)_param0.temp) || _param0.temp.Equals((object)default(T))).Select(_param0 => _param0.\u003C\u003Eh__TransparentIdentifier6.item);
    //}

    public static DateTime ToDateTime(this string datetime, char dateSpliter = '/', char timeSpliter = ':', char millisecondSpliter = ',')
    {
        try
        {
            datetime = datetime.Trim();
            datetime = datetime.Replace("  ", " ");
            string[] body = datetime.Split(' ');
            string[] date = body[0].Split(dateSpliter);
            int year = Convert.ToInt16(date[2]);
            int month = Convert.ToInt16(date[1]);
            int day = Convert.ToInt16(date[0]);
            int hour = 0, minute = 0, second = 0, millisecond = 0;
            if (body.Length == 2)
            {
                string[] tpart = body[1].Split(millisecondSpliter);
                string[] time = tpart[0].Split(timeSpliter);
                hour = Convert.ToInt16(time[0]);
                minute = Convert.ToInt16(time[1]);
                if (time.Length == 3) second = Convert.ToInt16(time[2]);
                if (tpart.Length == 2) millisecond = Convert.ToInt16(tpart[1]);
            }
            return new DateTime(year, month, day, hour, minute, second, millisecond);
        }
        catch
        {
            return new DateTime();
        }
    }
}

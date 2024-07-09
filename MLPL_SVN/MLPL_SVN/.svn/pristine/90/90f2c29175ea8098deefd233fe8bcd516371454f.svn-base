//  
// Type: XmlSerializerHelper
//  
//  
//  

using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

public class XmlSerializerHelper
{
  public static object Deserialize(XmlDocument xml, Type type)
  {
    XmlSerializer xmlSerializer = new XmlSerializer(type);
    XmlReader xmlReader = (XmlReader) new XmlTextReader((Stream) new MemoryStream(Encoding.UTF8.GetBytes(xml.OuterXml)));
    Exception exception = (Exception) null;
    try
    {
      return xmlSerializer.Deserialize(xmlReader);
    }
    catch (Exception ex)
    {
      exception = ex;
    }
    finally
    {
      xmlReader.Close();
      if (exception != null)
        throw exception;
    }
    return (object) null;
  }

  public static XmlDocument Serialize(object o)
  {
    XmlSerializer xmlSerializer = new XmlSerializer(o.GetType());
    MemoryStream memoryStream = new MemoryStream();
    XmlTextWriter xmlTextWriter = new XmlTextWriter((Stream) memoryStream, (Encoding) new UTF8Encoding());
    xmlTextWriter.Formatting = Formatting.Indented;
    xmlTextWriter.IndentChar = ' ';
    xmlTextWriter.Indentation = 5;
    Exception exception = (Exception) null;
    try
    {
      xmlSerializer.Serialize((XmlWriter) xmlTextWriter, o);
      XmlDocument xmlDocument = new XmlDocument();
      string xml = Encoding.UTF8.GetString(memoryStream.ToArray());
      xmlDocument.LoadXml(xml);
      return xmlDocument;
    }
    catch (Exception ex)
    {
      exception = ex;
    }
    finally
    {
      xmlTextWriter.Close();
      memoryStream.Close();
      if (exception != null)
        throw exception;
    }
    return (XmlDocument) null;
  }
}

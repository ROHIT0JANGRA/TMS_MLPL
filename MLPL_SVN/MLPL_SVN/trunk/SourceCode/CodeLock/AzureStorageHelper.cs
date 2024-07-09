//  
// Type: AzureStorageHelper
//  
//  
//  

using CodeLock;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

public class AzureStorageHelper
{
  public static string AzureContainerName
  {
    get
    {
      return ConfigurationManager.AppSettings["SOPContainerName"];
    }
  }

  private static string DeploymentType
  {
    get
    {
      return ConfigurationManager.AppSettings[nameof (DeploymentType)];
    }
  }

  public static string CloudStorageString
  {
    get
    {
      return ConfigurationManager.AppSettings[nameof (CloudStorageString)];
    }
  }

  public static string AzureConnectionString
  {
    get
    {
      return ConfigurationManager.ConnectionStrings[AzureStorageHelper.DeploymentType + "StorageConnectionString"].ConnectionString;
    }
  }

  public static CloudBlobContainer GetBlobContainer(string containerName)
  {
    return CloudStorageAccount.Parse(AzureStorageHelper.AzureConnectionString).CreateCloudBlobClient().GetContainerReference(containerName);
  }

  public static bool IsBlobExists(CloudBlockBlob blob)
  {
    try
    {
      blob.FetchAttributes();
      return true;
    }
    catch (StorageClientException ex)
    {
      if (ex.ErrorCode == StorageErrorCode.ResourceNotFound)
        return false;
      throw;
    }
  }

  public static bool IsBlobExists(string containerName, string blobUri)
  {
    try
    {
      AzureStorageHelper.GetBlobContainer(AzureStorageHelper.AzureContainerName).GetBlobReference(blobUri).FetchAttributes();
      return true;
    }
    catch (StorageClientException ex)
    {
      if (ex.ErrorCode == StorageErrorCode.ResourceNotFound)
        return false;
      throw;
    }
  }

  public static void DeleteBlob(string containerName, string blobUri)
  {
    try
    {
      AzureStorageHelper.GetBlobContainer(AzureStorageHelper.AzureContainerName).GetBlobReference(blobUri).DeleteIfExists();
    }
    catch (StorageClientException ex)
    {
      ExceptionUtility.LogException((Exception) ex, nameof (DeleteBlob), SessionUtility.LoginUserId, nameof (AzureStorageHelper));
      throw;
    }
  }

  public static void CreateContainer()
  {
    try
    {
      AzureStorageHelper.GetBlobContainer(AzureStorageHelper.AzureContainerName).CreateIfNotExist();
    }
    catch (Exception ex)
    {
      ExceptionUtility.LogException(ex, nameof (CreateContainer), SessionUtility.LoginUserId, nameof (AzureStorageHelper));
    }
  }

  public static string UploadBlob(string documentType, FileUpload upLoadFile, string fileName)
  {
    AzureStorageHelper.DeleteOldFiles(documentType);
    string empty = string.Empty;
    string str1;
    try
    {
      str1 = documentType + "/" + SessionUtility.Now.ToString("yyyy/MMM") + "/" + fileName;
      if (!string.IsNullOrEmpty(upLoadFile.PostedFile.FileName))
      {
        if (AzureStorageHelper.IsBlobExists(AzureStorageHelper.AzureContainerName, str1))
          AzureStorageHelper.DeleteBlob(AzureStorageHelper.AzureContainerName, str1);
        CloudBlob blobReference = AzureStorageHelper.GetBlobContainer(AzureStorageHelper.AzureContainerName).GetBlobReference(str1);
        Match match = Regex.Match(upLoadFile.PostedFile.FileName, "(?'Name'[^\\\\]+)\\.(?'Ext'.*)");
        string str2 = match.Groups["Ext"].Value;
        string str3 = match.Groups["Name"].Value;
        string str4 = HttpContext.Current.Server.MapPath("~/UploadedFiles/" + documentType + "/" + str3 + "." + str2);
        upLoadFile.PostedFile.SaveAs(str4);
        blobReference.Properties.ContentType = IOHelper.GetContentType(Path.GetExtension(upLoadFile.PostedFile.FileName));
        blobReference.UploadFile(str4);
      }
    }
    catch (Exception ex)
    {
      ExceptionUtility.LogException(ex, "UploadBlob - " + fileName, SessionUtility.LoginUserId, nameof (AzureStorageHelper));
      str1 = string.Empty;
    }
    return str1;
  }

  public static string GetFileName(
    string documentType,
    string documentPrefix,
    string fileNameSuffix,
    string documentNo,
    string fileName)
  {
    documentNo = fileNameSuffix == "" ? documentNo : documentNo + "_" + fileNameSuffix;
    return documentType + "_" + SessionUtility.Now.ToString("yyyy/MMM").Replace("/", "_") + "_" + IOHelper.GetFileName(documentPrefix, documentNo, fileName);
  }

  public static string UploadBlob(
    string documentType,
    HttpPostedFileBase upLoadFile,
    string fileName)
  {
    return AzureStorageHelper.UploadBlob(documentType, upLoadFile, fileName, "");
  }

  public static string UploadBlob(
    string documentType,
    HttpPostedFileBase upLoadFile,
    string fileName,
    string finalFileName)
  {
    AzureStorageHelper.DeleteOldFiles(documentType);
    string empty = string.Empty;
    string str1;
    try
    {
      if (finalFileName == "")
        str1 = documentType + "/" + SessionUtility.Now.ToString("yyyy/MMM") + "/" + fileName;
      else
        str1 = finalFileName;
      if (!string.IsNullOrEmpty(upLoadFile.FileName))
      {
        if (AzureStorageHelper.IsBlobExists(AzureStorageHelper.AzureContainerName, str1))
          AzureStorageHelper.DeleteBlob(AzureStorageHelper.AzureContainerName, str1);
        CloudBlob blobReference = AzureStorageHelper.GetBlobContainer(AzureStorageHelper.AzureContainerName).GetBlobReference(str1);
        Match match = Regex.Match(upLoadFile.FileName, "(?'Name'[^\\\\]+)\\.(?'Ext'.*)");
        string str2 = match.Groups["Ext"].Value;
        string str3 = match.Groups["Name"].Value;
        string str4 = HttpContext.Current.Server.MapPath("~/UploadedFiles/" + documentType + "/" + str3 + "." + str2);
        upLoadFile.SaveAs(str4);
        blobReference.Properties.ContentType = IOHelper.GetContentType(Path.GetExtension(upLoadFile.FileName));
        blobReference.UploadFile(str4);
      }
    }
    catch (Exception ex)
    {
      ExceptionUtility.LogException(ex, "UploadBlob - " + fileName, SessionUtility.LoginUserId, nameof (AzureStorageHelper));
      str1 = string.Empty;
    }
    return str1;
  }

  public static string UploadBlob(
    string documentType,
    string fileBase64,
    string fileName,
    string finalFileName)
  {
    AzureStorageHelper.DeleteOldFiles(documentType);
    string empty = string.Empty;
    string str1;
    try
    {
      str1 = finalFileName;
      if (!string.IsNullOrEmpty(fileBase64))
      {
        if (AzureStorageHelper.IsBlobExists(AzureStorageHelper.AzureContainerName, str1))
          AzureStorageHelper.DeleteBlob(AzureStorageHelper.AzureContainerName, str1);
        CloudBlob blobReference = AzureStorageHelper.GetBlobContainer(AzureStorageHelper.AzureContainerName).GetBlobReference(str1);
        Match match = Regex.Match(fileName, "(?'Name'[^\\\\]+)\\.(?'Ext'.*)");
        string ext = match.Groups["Ext"].Value;
        string str2 = match.Groups["Name"].Value;
        string str3 = HttpContext.Current.Server.MapPath("~/UploadedFiles/" + documentType + "/" + str2 + "." + ext);
        byte[] bytes = Convert.FromBase64String(fileBase64);
        File.WriteAllBytes(str3, bytes);
        blobReference.Properties.ContentType = IOHelper.GetContentType(ext);
        blobReference.UploadFile(str3);
      }
    }
    catch (Exception ex)
    {
      ExceptionUtility.LogException(ex, "UploadBlob - " + fileName, SessionUtility.LoginUserId, nameof (AzureStorageHelper));
      str1 = string.Empty;
    }
    return str1;
  }

  public static void DownloadBlob(string blobUri, string fileLocation)
  {
    CloudBlobContainer blobContainer = AzureStorageHelper.GetBlobContainer(AzureStorageHelper.AzureContainerName);
    CloudBlockBlob blockBlobReference = blobContainer.GetBlockBlobReference(blobContainer.Uri.ToString() + "/" + blobUri);
    if (!AzureStorageHelper.IsBlobExists(blockBlobReference))
      return;
    blockBlobReference.DownloadToFile(fileLocation);
  }

  public static void DownloadBlob(string blobUri, HttpResponse response)
  {
    CloudBlobContainer blobContainer = AzureStorageHelper.GetBlobContainer(AzureStorageHelper.AzureContainerName);
    CloudBlockBlob blockBlobReference = blobContainer.GetBlockBlobReference(blobContainer.Uri.ToString() + "/" + blobUri);
    using (MemoryStream memoryStream = new MemoryStream())
    {
      blockBlobReference.DownloadToStream((Stream) memoryStream);
      response.Clear();
      response.ClearContent();
      response.ClearHeaders();
      response.Buffer = true;
      response.Expires = -1;
      response.ContentType = blockBlobReference.Properties.ContentType;
      response.AddHeader("Content-Disposition", "Attachment; filename=" + blockBlobReference.Name);
      response.AddHeader("Content-Length", blockBlobReference.Properties.Length.ToString());
      response.BinaryWrite(memoryStream.ToArray());
      response.Flush();
      response.Close();
      response.End();
    }
  }

  private static void DeleteOldFiles(string documentType)
  {
    try
    {
      string str = HttpContext.Current.Server.MapPath("~/UploadedFiles");
      if (Directory.Exists(str + "\\" + documentType))
      {
        DirectoryInfo directoryInfo = new DirectoryInfo(str + "\\" + documentType);
        foreach (FileInfo file in directoryInfo.GetFiles())
        {
          if (file.CreationTime <= SessionUtility.Now.AddHours(-1.0))
            file.Delete();
        }
        foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
        {
          if (directory.CreationTime <= SessionUtility.Now.AddHours(-1.0))
            directory.Delete(true);
        }
      }
      else
        Directory.CreateDirectory(str + "\\" + documentType);
    }
    catch (Exception ex)
    {
      ExceptionUtility.LogException(ex, nameof (DeleteOldFiles), SessionUtility.LoginUserId, nameof (AzureStorageHelper));
      throw;
    }
  }
}

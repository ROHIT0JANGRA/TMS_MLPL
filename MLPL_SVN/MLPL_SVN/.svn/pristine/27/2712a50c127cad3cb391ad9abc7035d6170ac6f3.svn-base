//  
// Type: CodeLock.Helper.GoogleStorageHelper
//  
//  
//  

using Google;
using Google.Api.Gax;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Storage.v1.Data;
using Google.Apis.Upload;
using Google.Cloud.Storage.V1;
using System;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace CodeLock.Helper
{
  public class GoogleStorageHelper
  {
    private readonly string _bucketName;
    private readonly StorageClient _storageClient;

    public GoogleStorageHelper()
    {
      this._bucketName = ConfigurationManager.AppSettings["BucketName"];
      GoogleCredential credential = (GoogleCredential) null;
      using (FileStream fileStream = new FileStream(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["GoogleCredentialPath"]), FileMode.Open, FileAccess.Read, FileShare.Read))
        credential = GoogleCredential.FromStream((Stream) fileStream);
      this._storageClient = StorageClient.Create(credential, (EncryptionKey) null);
    }

    public async Task<string> UploadFile(
      string documentType,
      HttpPostedFileBase upLoadFile,
      string fileName,
      string finalFileName)
    {
      try
      {
        if (string.IsNullOrEmpty(finalFileName))
          finalFileName = documentType + "/" + SessionUtility.Now.ToString("yyyy/MMM") + "/" + fileName;
        PredefinedObjectAcl upLoadFileAcl = PredefinedObjectAcl.PublicRead;
        PagedEnumerable<Buckets, Bucket> buckets = this._storageClient.ListBuckets(ConfigurationManager.AppSettings["ProjectId"], (ListBucketsOptions) null);
        foreach (Bucket bucket in buckets)
          Console.WriteLine(bucket.Name);
        Google.Apis.Storage.v1.Data.Object imageObject = await this._storageClient.UploadObjectAsync(this._bucketName, finalFileName, upLoadFile.ContentType, upLoadFile.InputStream, new UploadObjectOptions()
        {
          PredefinedAcl = new PredefinedObjectAcl?(PredefinedObjectAcl.PublicRead)
        }, new CancellationToken(), (IProgress<IUploadProgress>) null);
        return imageObject.MediaLink;
      }
      catch (Exception ex)
      {
        ExceptionUtility.LogException(ex, nameof (UploadFile) + fileName, SessionUtility.LoginUserId, nameof (GoogleStorageHelper));
        return string.Empty;
      }
    }

    public async Task DeleteUploadedFile(string fileName)
    {
      try
      {
        await this._storageClient.DeleteObjectAsync(this._bucketName, fileName, (DeleteObjectOptions) null, new CancellationToken());
      }
      catch (GoogleApiException ex)
      {
        if (ex.Error.Code != 404)
          throw;
      }
    }

    public static string GetFileName(
      string documentType,
      string documentPrefix,
      string fileNameSuffix,
      string documentNo,
      string fileName)
    {
      documentNo = fileNameSuffix == "" ? documentNo : documentNo + "_" + fileNameSuffix;
      return documentType + "/" + SessionUtility.Now.ToString("yyyy/MMM") + "/" + IOHelper.GetFileName(documentPrefix, documentNo, fileName);
    }
  }
}

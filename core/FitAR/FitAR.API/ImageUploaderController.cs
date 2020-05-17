using Direct;
using Direct.Fitardb.Models;
using FitAR.Database;
using FitAR.Web.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FitAR.Web.API
{
  [Route("api/imageUpload")]
  [Descriptor(Name ="ICRImageUploader", Description =
    "Користи се за постављање слика у едитору за потребе Интеракција-човјек рачунар")]
  public class ImageUploaderController : ARApiController
  {

    [HttpPost]
    [Route("send")]
    [Descriptor(Name = "Постављање слике", 
      Output = typeof(ImageUploaderResponse),
      Description = "Шаље се слика у пост-у, постаставља се на блоб азуре и враћа се урл за даљу употребу")]
    public async Task<ImageUploaderResponse> UploadImage(string upload)
    {
      try
      {
        string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=paywall;AccountKey=hDfRSqohMj3NdKjtJhYn2zAnxR7eAZ3dQidDviGnHDPBLEZwfp1ptbPFfvBdjfEqsfmZEboXOyd4s9wUJZDcfA==;EndpointSuffix=core.windows.net";
        CloudStorageAccount storageacc = CloudStorageAccount.Parse(storageConnectionString);
        CloudBlobClient client = storageacc.CreateCloudBlobClient();
        CloudBlobContainer cont = client.GetContainerReference("aco");

        await cont.SetPermissionsAsync(new BlobContainerPermissions
        {
          PublicAccess = BlobContainerPublicAccessType.Blob

        });

        string type = upload.Substring(0, upload.IndexOf(','));
        string content = upload.Substring(upload.IndexOf(',') + 1, upload.Length - upload.IndexOf(',') - 2);

        string extension = "";
        if (type.StartsWith("data:image/jpeg"))
          extension = ".jpg";
        else if (type.StartsWith("data:image/png;base64"))
          extension = ".png";
  
        Stream inputStream = new MemoryStream(DecodeUrlBase64(content));
        string ImageName = Guid.NewGuid().ToString().Replace("-", string.Empty) + extension;
        CloudBlockBlob cblob = cont.GetBlockBlobReference(ImageName);
        await cblob.UploadFromStreamAsync(inputStream);

        return new ImageUploaderResponse()
        {
          url = cblob.Uri.AbsoluteUri
        };
      }
      catch (Exception ex) 
      {
        return new ImageUploaderResponse()
        {
          Exception = ex.ToString()
        };
      }
    }


    public static byte[] DecodeUrlBase64(string s)
    {
      s = s.Replace('-', '+').Replace('_', '/').PadRight(4 * ((s.Length + 3) / 4), '=');
      return Convert.FromBase64String(s);
    }

  }
}

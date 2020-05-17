using Direct;
using Direct.Fitardb.Models;
using FitAR.Database;
using FitAR.Web.API.Code;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FitAR.Web.API
{

  [Route("api/profilepic")]
  [Descriptor(Name = "ProfileImageUploadController",
    Description = @"Контрол за постављање профилних слика са андроид клијента")]
  public class ProfileImageUploadController : ARApiController
  {
    [HttpPost("")]
    [Descriptor(Name = "Акција",
      Description = @"Главна метода за уплоад")]
    public async Task<ActionResult> UploadImage(IFormFile file, string username)
    {
      Console.WriteLine("--> ML:: Receiving file");

      if (file == null || file.Length == 0 || !CheckIfImageFile(file))
        return this.BadRequest();

      ClientDM clientDM = await ARDirect.Instance.Query<ClientDM>().Where("username={0}", username).LoadSingleAsync();
      if (clientDM == null)
        return this.BadRequest();

      try
      {
        byte[] fileBytes;
        var ms = new MemoryStream();
        file.CopyTo(ms);
        fileBytes = ms.ToArray();

        string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=paywall;AccountKey=hDfRSqohMj3NdKjtJhYn2zAnxR7eAZ3dQidDviGnHDPBLEZwfp1ptbPFfvBdjfEqsfmZEboXOyd4s9wUJZDcfA==;EndpointSuffix=core.windows.net";
        CloudStorageAccount storageacc = CloudStorageAccount.Parse(storageConnectionString);
        CloudBlobClient client = storageacc.CreateCloudBlobClient();
        CloudBlobContainer cont = client.GetContainerReference("aco");

        await cont.SetPermissionsAsync(new BlobContainerPermissions
        {
          PublicAccess = BlobContainerPublicAccessType.Blob

        });

        string extension = "";
        switch(ImageUploadHelper.GetImageFormat(fileBytes))
        {
          case ImageUploadHelper.ImageFormat.jpeg:
            extension = ".jpg";
            break;
          case ImageUploadHelper.ImageFormat.png:
            extension = ".png";
            break;
          default:
            return this.BadRequest();
        }

        Stream inputStream = ms;
        string ImageName = "profile_" + Guid.NewGuid().ToString().Replace("-", string.Empty) + extension;
        CloudBlockBlob cblob = cont.GetBlockBlobReference(ImageName);
        await cblob.UploadFromStreamAsync(inputStream);

        clientDM.profilePic = cblob.Uri.AbsoluteUri;
        await clientDM.UpdateAsync();

        return this.Ok();
      }
      catch (Exception e)
      {
        return this.BadRequest();
      }
    }

    private bool CheckIfImageFile(IFormFile file)
    {
      byte[] fileBytes;
      using (var ms = new MemoryStream())
      {
        file.CopyTo(ms);
        fileBytes = ms.ToArray();
      }

      var type = ImageUploadHelper.GetImageFormat(fileBytes);
      if (type != ImageUploadHelper.ImageFormat.jpeg && type != ImageUploadHelper.ImageFormat.png)
        return false;

      return true;
    }


  }
}

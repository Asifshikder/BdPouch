using BdPouch.Data.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace BdPouch.Web.Services
{
    public class MediaService : IMediaService
    {
        private IWebHostEnvironment webHost;
        string folder = "useruploads";
        public string ImageExtensions = " .jpg , .png , .jpeg, .ico , .gif , .webp , .tiff , .raw , .bmp , .heif , .jfif ";

        public MediaService(IWebHostEnvironment webHost)
        {
            this.webHost = webHost;
        }

        public void DeleteFile(string foldername)
        {
            string dbpath = foldername.Replace("~/", "").ToString();
            string uppath = dbpath.Replace("/", "\\").ToString();
            string fullpath = webHost.WebRootPath + "\\" + uppath;
            System.IO.File.Delete(fullpath);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public string UpdateFile(string property, IFormFile file)
        {
            if (property != null)
            {
                string dbpath = property.Replace("~/", "").ToString();
                string uppath = dbpath.Replace("/", "\\").ToString();
                string fullpath = webHost.WebRootPath + "\\" + uppath;
                System.IO.File.Delete(fullpath);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            Guid nameguid = Guid.NewGuid();
            string webrootpath = webHost.WebRootPath;
            string filename = nameguid.ToString();
            string extension = Path.GetExtension(file.FileName);
            filename = filename + extension;
            string path = Path.Combine(webrootpath, folder, filename);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            string fileUrl = "~/" + folder + "/" + filename;
            return fileUrl;

        }

        public string UploadFile(IFormFile file)
        {
            Guid nameguid = Guid.NewGuid();
            string webrootpath = webHost.WebRootPath;
            string filename = nameguid.ToString();
            string extension = Path.GetExtension(file.FileName);
            filename = filename + extension;
            string path = Path.Combine(webrootpath, folder, filename);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            string fileUrl = "~/" + folder + "/" + filename;
            return fileUrl;

        }


    }
}

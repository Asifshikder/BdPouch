using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Data.Extensions
{
    public interface IMediaService
    {
        string UploadFile(IFormFile file);
        string UpdateFile(string media, IFormFile file);
        void DeleteFile(string filename);
    }
}

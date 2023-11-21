using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.EF.Products
{
    public static class ImageAppServices
    {
        public static string UploadProcess(IFormFile formFile)
        {
            string filePath;
            string fileName;
            if (formFile != null)
            {
                fileName = Guid.NewGuid().ToString() +
                ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
                filePath = Path.Combine("wwwroot/img", fileName);
                try
                {
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        formFile.CopyTo(stream);
                    }
                }
                catch
                {
                    throw new Exception("Upload files operation failed");
                }
                return fileName;
            }
            else
                fileName = "";
            return fileName;
        }
    }
}

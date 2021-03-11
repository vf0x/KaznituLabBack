using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace KaznituLab.Helpers
{
    public class UploadImageHelper
    {
        public static string UploadFile(IFormFile file)
        {
            string uniqueFileName = null;
            if(file != null)
            {
                string uploadsFolder = Path.Combine(Environment.CurrentDirectory, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}

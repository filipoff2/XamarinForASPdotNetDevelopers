using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebZoomImages.Models
{
    public class UploadImage
    {
        public List<IFormFile> FileUpload { get; set; }
        public string Zoom { get; set; }
    }
}

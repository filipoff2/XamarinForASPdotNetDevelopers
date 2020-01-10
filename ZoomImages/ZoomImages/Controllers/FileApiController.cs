using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebZoomImages.Models;

namespace WebZoomImages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileApiController : ControllerBase
    {
        [Route("save")]
        [HttpPost]
        public async Task<HttpResponseMessage> Save()
        {
            // ***********************************************************************************************
            // This method has custom Swagger definition hidden in class SwaggerRequestFileContentTypeAttibute
            // ***********************************************************************************************
            if (!Request.Form.Files.Any())
            {
                UploadImage model = new UploadImage();
                foreach (string kvp in Request.Form.Keys)
                {
                    PropertyInfo pi = model.GetType().GetProperty(kvp, BindingFlags.Public | BindingFlags.Instance);
                    if (pi != null)
                    {
                        pi.SetValue(model, Request.Form[kvp], null);
                    }
                }

                foreach (var formFileTemp in Request.Form.Files)
                {
                    if (formFileTemp.Length > 0)
                    {
                        var filePath = Path.GetTempFileName();

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            await formFileTemp.CopyToAsync(stream);
                        }
                    }
                }
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
using ASP.NET_Practice.Controllers;
using ASP.NET_Practice.Helpers;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Practice.Areas.Default.Controllers
{
    public class FileController : ConfigBaseController
    {
        [HttpPost]
        public JsonResult Upload()
        {
            JsonResult result = null;

            foreach (string file in Request.Files)
            {
                var upload = Request.Files[file];

                if (upload != null)
                {
                    //TODO: использовать уникальное имя файла
                    ///или здесь сохранять во временное хранилище, а при сохранении юзера пересохранять файл с именем = email
                    var fileName = Path.GetFileName(upload.FileName);
                    var fileExt = Path.GetExtension(fileName);
                    var mimeType = Configuration.MimeTypes.FirstOrDefault(t => string.Equals(t.Extension, fileExt, StringComparison.OrdinalIgnoreCase));

                    if (mimeType != null && mimeType.Name.Contains("image"))
                    {
                        var fullFileName = Server.MapPath(@"~/Content/Photos/" + fileName);
                        upload.SaveAs(fullFileName);
                        result = JsonHelper.CreateFileUploadSuccess(fullFileName);
                    }
                    else
                    {
                        result = JsonHelper.CreateFailed("Incorrect file type", "");
                    }
                }
                else
                {
                    result = JsonHelper.CreateFailed("Error happened. Try again", "");
                }
            }

            return result;
        }
    }
}
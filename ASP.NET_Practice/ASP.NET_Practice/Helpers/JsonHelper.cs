using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Practice.Helpers
{
    public static class JsonHelper
    {
        public static JsonResult CreateFileUploadSuccess(string fullFileName)
        {
            return new JsonResult
            {
                Data = new
                {
                    success = true,
                    fullFileName
                }
            };
        }

        public static JsonResult CreateFailed(string errorMessage, string errorCode)
        {
            return new JsonResult
            {
                Data = new
                {
                    success = false,
                    errorMessage,
                    errorCode
                }
            };
        }
    }
}
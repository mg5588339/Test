using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Test.Application.Common.Response
{
    public static class JsonResponseStatus
    {
        public static JsonResult Success()
        {
            return new JsonResult(new { status = "Success" });
        }

        public static JsonResult Success(object returnData)
        {
            return new JsonResult(new { status = "Success", data = returnData });
        }

        public static JsonResult Success(object returnData, int totalItemCount)
        {
            return new JsonResult(new { status = "Success", data = returnData, totalItemCount = totalItemCount });
        }


        public static JsonResult Success(string message)
        {
            return new JsonResult(new { status = "Success", message });
        }


        public static JsonResult SuccessLogin(string token)
        {
            return new JsonResult(new { status = "Success", token = token });
        }

        public static JsonResult NotFound()
        {
            return new JsonResult(new { status = "NotFound" });
        }

        public static JsonResult NotFound(object returnData)
        {
            return new JsonResult(new { status = "NotFound", data = returnData });
        }

        public static JsonResult NotFound(string message)
        {
            return new JsonResult(new { status = "NotFound", message = message });
        }

        public static JsonResult Error()
        {
            return new JsonResult(new { status = "Error" });
        }

        public static JsonResult Error(object returnData)
        {
            return new JsonResult(new { status = "Error", data = returnData });
        }

        public static JsonResult Error(string message)
        {
            return new JsonResult(new { status = "Error", message = message });
        }

    }
}

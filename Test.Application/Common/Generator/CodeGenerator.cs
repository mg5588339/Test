using System;

namespace Test.Application.Common.Generator
{
    public static class CodeGenerator
    {
        public static int NewMobileActiveCode()
        {
            return new Random().Next(1000, 100000);
        }

        public static string NewGuidCode()
        {
            return Guid.NewGuid().ToString("N");
        }

        public static string OrderNumber(this long orderId)
        {
            var serialCount = 11 - orderId.ToString().Length;
            var zero = "";
            for (int i = 0; i < serialCount; i++)
                zero += "0";

            return $"MI{zero}{orderId}"; ;
        }
    }
}

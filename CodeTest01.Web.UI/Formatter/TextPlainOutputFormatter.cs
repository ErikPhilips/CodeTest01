using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CodeTest01.Business.ZipCodeInfo;
using Microsoft.AspNetCore.Http;

namespace CodeTest01.Web.UI.Formatter
{
   public class TextPlainOutputFormatter : TextOutputFormatter
   {
      public TextPlainOutputFormatter()
      {
         SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/plain"));

         SupportedEncodings.Add(Encoding.UTF8);
         SupportedEncodings.Add(Encoding.Unicode);
      }

      protected override bool CanWriteType(Type type)
      {
         if (typeof(IZipCodeInfoBO).IsAssignableFrom(type))
         {
            return base.CanWriteType(type);
         }
         return false;
      }

      public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
      {
         var serviceProvider = context.HttpContext.RequestServices;
         var response = context.HttpContext.Response;
         var result = string.Empty;

         if (context.Object is IZipCodeInfoBO zipCodeInfo)
         {
            result = $"At the location {zipCodeInfo.CityName}, the temperature is {zipCodeInfo.TemperatureInKelvin}, the timezone is {zipCodeInfo.TimeZone}, and the elevation is {zipCodeInfo.ElevationInMeters}.";
         }

         await response.WriteAsync(result);
      }
   }
}

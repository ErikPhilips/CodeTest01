using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CodeTest01.Business.ZipCodeInfo;
using Microsoft.AspNetCore.Http;
using CodeTest01.Web.UI.Models.API.Version1._0;

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
         if (typeof(ZipCodeInfoVM).IsAssignableFrom(type))
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

         if (context.Object is ZipCodeInfoVM zipCodeInfo)
         {
            result = $"In {zipCodeInfo.CityName}, the temperature is approximately {zipCodeInfo.TemperatureInFahrenheit:N0} degrees in Fahreneheight and the timezone is {zipCodeInfo.TimeZone}, and the elevation is approximately {zipCodeInfo.ElevationInFeet:N0} feet.";
         }

         await response.WriteAsync(result);
      }
   }
}

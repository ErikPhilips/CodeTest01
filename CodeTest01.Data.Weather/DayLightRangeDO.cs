using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest01.Data.Weather
{
   public interface IDayLightRangeDO
   {
      string CountryCode { get; }

      DateTime SunriseInUtc { get; }

      DateTime SunsetInUtc { get; }
   }

   internal class DayLightRangeDO : IDayLightRangeDO
   {
      [JsonProperty("country")]
      public string CountryCode { get; set; }

      [JsonConverter(typeof(UnixDateTimeConverter))]
      [JsonProperty("sunrise")]
      public DateTime SunriseInUtc { get; set; }

      [JsonConverter(typeof(UnixDateTimeConverter))]
      [JsonProperty("sunset")]
      public DateTime SunsetInUtc { get; set; }
   }
}

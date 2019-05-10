using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest01.Data.TimeZone
{
   public interface ITimeZoneDO
   {
      int OffsetForDaylightSavingsInSeconds { get; }

      int OffsetFromUTCInSeconds { get; }

      string CanonicalCLDRId { get; }

      string LongFormName { get; }

      string Status { get; }

      string ErrorMessage { get; }
   }

   internal class TimeZoneDO : ITimeZoneDO
   {
      [JsonProperty("dstOffset")]
      public int OffsetForDaylightSavingsInSeconds { get; set; }

      [JsonProperty("rawOffset")]
      public int OffsetFromUTCInSeconds { get; set; }

      /// <summary>
      /// This value is sourced from http://cldr.unicode.org/
      /// </summary>
      [JsonProperty("timeZoneId")]
      public string CanonicalCLDRId { get; set; }

      [JsonProperty("timeZoneName")]
      public string LongFormName { get; set; }

      [JsonProperty("status")]
      public string Status { get; set; }

      [JsonProperty("errorMessage")]
      public string ErrorMessage { get; set; }
   }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest01.Data.Weather
{
   public interface ICloudDO
   {
      long CoverInPercentage { get; }
   }

   internal class CloudDO : ICloudDO
   {
      [JsonProperty("all")]
      public long CoverInPercentage { get; set; }
   }
}

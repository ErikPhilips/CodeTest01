using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest01.Data.Weather
{
   public interface IWindDO
   {
      double SpeedInMetersPerSecond { get; }

      double DirectionInDegrees { get; }
   }

   internal class WindDO : IWindDO
   {
      [JsonProperty("speed")]
      public double SpeedInMetersPerSecond { get; set; }

      [JsonProperty("deg")]
      public double DirectionInDegrees { get; set; }
   }
}

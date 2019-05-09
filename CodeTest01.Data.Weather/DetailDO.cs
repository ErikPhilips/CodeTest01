using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest01.Data.Weather
{
   public interface IDetailDO
   {
      double TemperatureInKelvin { get; }

      long HumidityInPercentage { get; }

      double PressureInHpa { get; }

      double MinimumTemperature { get; }

      double MaximumTemperature { get; }
   }

   internal class DetailDO : IDetailDO
   {
      [JsonProperty("temp")]
      public double TemperatureInKelvin { get; set; }

      [JsonProperty("humidity")]
      public long HumidityInPercentage { get; set; }

      [JsonProperty("pressure")]
      public double PressureInHpa { get; set; }

      [JsonProperty("temp_min")]
      public double MinimumTemperature { get; set; }

      [JsonProperty("temp_max")]
      public double MaximumTemperature { get; set; }
   }
}

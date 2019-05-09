using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest01.Data.Weather
{
   public interface IWeatherDescriptionDO
   {
      long Id { get; }

      string ShortDescription { get; }

      string Description { get; }

      string Icon { get; }
   }

   public class WeatherDescriptionDO : IWeatherDescriptionDO
   {
      [JsonProperty("id")]
      public long Id { get; set; }

      [JsonProperty("main")]
      public string ShortDescription { get; set; }

      [JsonProperty("description")]
      public string Description { get; set; }

      [JsonProperty("icon")]
      public string Icon { get; set; }
   }
}

using Microsoft.Spatial;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest01.Data.Weather
{
   public interface IWeatherDO
   {
      GeographyPoint Coordinate { get; }

      IDayLightRangeDO DayLightRange { get; }

      IEnumerable<IWeatherDescriptionDO> WeatherDescriptions { get; }

      string StationName { get; }

      IDetailDO Detail { get; }

      IWindDO Wind { get; }

      ICloudDO Cloud { get;  }

      DateTime RecordedOnInUtc { get; }

      long CityId { get; }

      string Name { get; }
   }

   internal class WeatherDO : IWeatherDO
   {
      [JsonProperty("coord")]
      public GeographyPoint Coordinate { get; set; }

      [JsonProperty("sys")]
      public DayLightRangeDO DayLightRange { get; set; }

      [JsonProperty("weather")]
      public List<WeatherDescriptionDO> WeatherDescriptions { get; set; }

      [JsonProperty("base")]
      public string StationName { get; set; }

      [JsonProperty("main")]
      public DetailDO Detail { get; set; }

      [JsonProperty("wind")]
      public WindDO Wind { get; set; }

      [JsonProperty("clouds")]
      public CloudDO Clouds { get; set; }

      [JsonConverter(typeof(UnixDateTimeConverter))]
      [JsonProperty("dt")]
      public DateTime RecordedOnInUtc { get; set; }

      [JsonProperty("id")]
      public long CityId { get; set; }

      [JsonProperty("name")]
      public string Name { get; set; }

      IDayLightRangeDO IWeatherDO.DayLightRange => DayLightRange;

      IEnumerable<IWeatherDescriptionDO> IWeatherDO.WeatherDescriptions => WeatherDescriptions;

      IDetailDO IWeatherDO.Detail => Detail;

      IWindDO IWeatherDO.Wind => Wind;

      ICloudDO IWeatherDO.Cloud => Clouds;
   }
}

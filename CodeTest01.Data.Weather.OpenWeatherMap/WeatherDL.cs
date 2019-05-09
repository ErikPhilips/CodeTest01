using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest01.Data.Weather
{
   public class WeatherConfiguration
   {
      public string ApiKey { get; set; }
   }

   public interface IWeatherDL
   {
      Task<IWeatherDO> GetAsync(string zipcode);
   }

   public class WeatherDL : IWeatherDL
   {
      private readonly string apiFormat = "https://api.openweathermap.org/data/2.5/weather?zip={0},us&appid={1}";

      private readonly WeatherConfiguration _configuration;
      private readonly HttpClient _httpClient;

      public WeatherDL(WeatherConfiguration configuration, HttpClient httpClient)
      {
         _configuration = configuration;
         _httpClient = httpClient;
      }

      public async Task<IWeatherDO> GetAsync(string zipcode)
      {
         var url = string.Format(apiFormat, zipcode, _configuration.ApiKey);
         var jsonResponse = await _httpClient.GetStringAsync(url);
         var deserializeSettings = new JsonSerializerSettings();
         deserializeSettings.Converters.Add(new GeographyPointConverter());
         var result = JsonConvert.DeserializeObject<WeatherDO>(jsonResponse, deserializeSettings);
         return result;
      }
   }

}

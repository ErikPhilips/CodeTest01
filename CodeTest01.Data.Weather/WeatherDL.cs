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

      private WeatherConfiguration _configuration;
      private HttpClient _httpclient;

      public WeatherDL(WeatherConfiguration configuration, HttpClient httpclient)
      {
         _configuration = configuration;
         _httpclient = httpclient;
      }

      public async Task<IWeatherDO> GetAsync(string zipcode)
      {
         var url = string.Format(apiFormat, zipcode, _configuration.ApiKey);
         var jsonResponse = await _httpclient.GetStringAsync(url);
         var result = JsonConvert.DeserializeObject<WeatherDO>(jsonResponse);
         return result;
      }
   }

}

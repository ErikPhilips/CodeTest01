using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Spatial;
using Microsoft.Extensions.Options;

namespace CodeTest01.Data.TimeZone
{
   public class TimeZoneConfiguration
   {
      public string ApiKey { get; set; }
   }

   public interface ITimeZoneDL
   {
      Task<ITimeZoneDO> GetAsync(GeographyPoint point);
   }

   public class TimeZoneDL : ITimeZoneDL
   {
      private readonly string apiFormat = "https://maps.googleapis.com/maps/api/timezone/json?location={0},{1}&timestamp={2}&key={3}";

      private readonly TimeZoneConfiguration _configuration;
      private readonly HttpClient _httpClient;

      public TimeZoneDL(IOptions<TimeZoneConfiguration> configuration, HttpClient httpClient)
      {
         _configuration = configuration.Value;
         _httpClient = httpClient;
      }
      public async Task<ITimeZoneDO> GetAsync(GeographyPoint point)
      {

#warning this should be dependency injected with a datetime factory for testing - Erik
         var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

         var url = string.Format(apiFormat, point.Latitude, point.Longitude, timestamp, _configuration.ApiKey);
         var jsonResponse = await _httpClient.GetStringAsync(url);
         var result = JsonConvert.DeserializeObject<TimeZoneDO>(jsonResponse);
         return result;
      }
   }
}

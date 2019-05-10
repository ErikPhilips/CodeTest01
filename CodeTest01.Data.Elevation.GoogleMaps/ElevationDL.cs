using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Spatial;
using System.Linq;
using Microsoft.Extensions.Options;

namespace CodeTest01.Data.Elevation
{
   public class ElevationConfiguration
   {
      public string ApiKey { get; set; }
   }

   public interface IElevationDL
   {
      Task<IElevationDO> GetSingleOrDefaultAsync(GeographyPoint point);
   }

   public class ElevationDL : IElevationDL
   {
      private readonly string apiFormat = "https://maps.googleapis.com/maps/api/elevation/json?locations={0},{1}&key={2}";

      private readonly ElevationConfiguration _configuration;
      private readonly HttpClient _httpClient;

      public ElevationDL(IOptions<ElevationConfiguration> configuration, HttpClient httpClient)
      {
         _configuration = configuration.Value;
         _httpClient = httpClient;
      }
      public async Task<IElevationDO> GetSingleOrDefaultAsync(GeographyPoint point)
      {

         var url = string.Format(apiFormat, point.Latitude, point.Longitude, _configuration.ApiKey);
         var jsonResponse = await _httpClient.GetStringAsync(url);
         var result = JsonConvert.DeserializeObject<GoogleResponse>(jsonResponse);
         return result.Elevations.FirstOrDefault();
      }
   }
}

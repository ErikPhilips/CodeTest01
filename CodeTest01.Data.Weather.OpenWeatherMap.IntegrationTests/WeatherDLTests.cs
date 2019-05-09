using CodeTest01.IntegrationTesting;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CodeTest01.Data.Weather.Integration
{
   public class WeatherDLTests 
   {
      private static readonly HttpClient HttpClient = new HttpClient();
      private const string WhiteHouseZipCode = "20500";
      private readonly WeatherConfiguration _weatherConfiguration;

      public WeatherDLTests()
      {
         _weatherConfiguration = Configuration.GetSection<WeatherConfiguration>("WeatherConfiguration");
      }


      [Test]
      public async Task GetAsync_WithValidZipcode_DoesNotThrow()
      {
         var weatherDL = new WeatherDL(_weatherConfiguration, HttpClient);

         var result = await weatherDL.GetAsync(WhiteHouseZipCode);

         Assert.That(result, Is.Not.Null);
      }

      [Test]
      public void GetAsync_WithInvalidZipcode_ThrowsException()
      {
         var weatherDL = new WeatherDL(_weatherConfiguration, HttpClient);

         Assert.ThrowsAsync<HttpRequestException>(async () => await weatherDL.GetAsync("NotAZipCode"));
      }
   }
}

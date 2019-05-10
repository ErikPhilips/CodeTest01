using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Spatial;
using Microsoft.Extensions.Options;

namespace CodeTest01.Data.TimeZone.GoogleMaps.IntegrationTests
{
   public class TimeZoneDLTests
   {
      private static readonly HttpClient HttpClient = new HttpClient();
      private readonly IOptions<TimeZoneConfiguration> _timeZoneConfiguration;
      private const double WhiteHouseLatitude = 38.8977;
      private const double WhiteHouseLongitude = -77.0365;

      private const string Status_Ok = "OK";

      public TimeZoneDLTests()
      {
         _timeZoneConfiguration =  Configuration.GetOptions<TimeZoneConfiguration>("TimeZoneConfiguration");
      }


      [Test]
      public async Task GetAsync_WithValidPoint_ReturnsStatusOfOk()
      {
         var timeZoneDL = new TimeZoneDL(_timeZoneConfiguration, HttpClient);
         var point = GeographyPoint.Create(WhiteHouseLatitude, WhiteHouseLongitude);

         var result = await timeZoneDL.GetAsync(point);

         Assert.That(result.Status, Is.EqualTo(Status_Ok));
      }
   }
}

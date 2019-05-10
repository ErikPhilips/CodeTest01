using CodeTest01.IntegrationTesting;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Spatial;
using Microsoft.Extensions.Options;

namespace CodeTest01.Data.Elevation.GoogleMaps.IntegrationTests
{
   public class ElevationDLTests
   {
      private static readonly HttpClient HttpClient = new HttpClient();
      private readonly IOptions<ElevationConfiguration> _timeZoneConfiguration;
      private const double WhiteHouseLatitude = 38.8977;
      private const double WhiteHouseLongitude = -77.0365;

      private const string Status_Ok = "OK";

      public ElevationDLTests()
      {
         _timeZoneConfiguration = Configuration.GetOptions<ElevationConfiguration>("ElevationConfiguration");
      }


      [Test]
      public async Task GetAsync_WithValidPoint_ReturnsStatusOfOk()
      {
         var elevationDL = new ElevationDL(_timeZoneConfiguration, HttpClient);
         var point = GeographyPoint.Create(WhiteHouseLatitude, WhiteHouseLongitude);

         var result = await elevationDL.GetSingleOrDefaultAsync(point);

         Assert.That(result, Is.Not.Null);
      }
   }
}

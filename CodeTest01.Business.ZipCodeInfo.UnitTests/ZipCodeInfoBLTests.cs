using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Spatial;
using CodeTest01.Data.TimeZone;
using CodeTest01.Data.Elevation;
using CodeTest01.Data.Weather;
using NSubstitute;

namespace CodeTest01.Business.ZipCodeInfo.UnitTests
{
   public class ZipCodeInfoBLTests
   {
      private ITimeZoneDL _timeZoneDL;
      private IElevationDL _elevationDL;
      private IWeatherDL _weatherDL;

      private ITimeZoneDO _timeZoneDO;
      private IElevationDO _elevationDO;
      private IWeatherDO _weatherDO;

      private ZipCodeInfoBL _zipCodeInfoBL;

      [SetUp]
      public void Setup()
      {
         _timeZoneDL = Substitute.For<ITimeZoneDL>();
         _elevationDL = Substitute.For<IElevationDL>();
         _weatherDL = Substitute.For<IWeatherDL>();

         _zipCodeInfoBL = new ZipCodeInfoBL(_timeZoneDL, _elevationDL, _weatherDL);

         _timeZoneDO = Substitute.For<ITimeZoneDO>();
         _elevationDO = Substitute.For<IElevationDO>();
         _weatherDO = Substitute.For<IWeatherDO>();
      }

      [Test]
      public void GetAsync_WeatherReturnNull_DoesNotThrow()
      {
         _timeZoneDL.GetAsync(Arg.Any<GeographyPoint>()).Returns(_timeZoneDO);
         _elevationDL.GetSingleOrDefaultAsync(Arg.Any<GeographyPoint>()).Returns(_elevationDO);
         _weatherDL.GetAsync(Arg.Any<string>()).Returns(null as IWeatherDO);

         Assert.DoesNotThrowAsync(async () => await _zipCodeInfoBL.GetAsync(null));
      }

      [Test]
      public void GetAsync_ElevationReturnNull_DoesNotThrow()
      {
         _timeZoneDL.GetAsync(Arg.Any<GeographyPoint>()).Returns(_timeZoneDO);
         _elevationDL.GetSingleOrDefaultAsync(Arg.Any<GeographyPoint>()).Returns(null as IElevationDO);
         _weatherDL.GetAsync(Arg.Any<string>()).Returns(_weatherDO);

         Assert.DoesNotThrowAsync(async () => await _zipCodeInfoBL.GetAsync(null));
      }

      [Test]
      public void GetAsync_TimeZoneReturnNull_DoesNotThrow()
      {
         _timeZoneDL.GetAsync(Arg.Any<GeographyPoint>()).Returns(null as ITimeZoneDO);
         _elevationDL.GetSingleOrDefaultAsync(Arg.Any<GeographyPoint>()).Returns(_elevationDO);
         _weatherDL.GetAsync(Arg.Any<string>()).Returns(_weatherDO);

         Assert.DoesNotThrowAsync(async () => await _zipCodeInfoBL.GetAsync(null));
      }
   }
}

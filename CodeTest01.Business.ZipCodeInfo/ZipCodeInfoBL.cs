using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CodeTest01.Data.Elevation;
using CodeTest01.Data.TimeZone;
using CodeTest01.Data.Weather;

namespace CodeTest01.Business.ZipCodeInfo
{
   public class ZipCodeInfoBL : IZipCodeInfoBL
   {
      private readonly ITimeZoneDL _timeZoneDL;
      private readonly IElevationDL _elevationDL;
      private readonly IWeatherDL _weatherDL;

      public ZipCodeInfoBL(ITimeZoneDL timeZoneDL,
         IElevationDL elevationDL,
         IWeatherDL weatherDL)
      {
         _timeZoneDL = timeZoneDL;
         _elevationDL = elevationDL;
         _weatherDL = weatherDL;
      }

      public async Task<IZipCodeInfoBO> GetAsync(string zipCode)
      {
         var result = new ZipCodeInfoBO();

         try
         {
            var weather = await _weatherDL.GetAsync(zipCode);
            var elevationTask = _elevationDL.GetSingleOrDefaultAsync(weather.Coordinate);
            var timeZoneTask = _timeZoneDL.GetAsync(weather.Coordinate);

            await Task.WhenAll(elevationTask, timeZoneTask);

            var elevation = await elevationTask;
            var timeZone = await timeZoneTask;

            result.CityName = weather.Name;
            result.ElevationInMeters = elevation.ElevationInMeters;
            result.TemperatureInKelvin = weather.Detail.TemperatureInKelvin;
            result.TimeZone = timeZone.LongFormName;
         }
         catch
         {
            result = null;
         }

         return result;
      }
   }
}

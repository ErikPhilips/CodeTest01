using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest01.Business.ZipCodeInfo
{
   public interface IZipCodeInfoBO
   {
      string CityName { get; }
      string TimeZone { get; }
      double TemperatureInKelvin { get; }
      double ElevationInMeters { get; }
   }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest01.Business.ZipCodeInfo
{
   public class ZipCodeInfoBO : IZipCodeInfoBO
   {
      public string CityName { get; set; }
      public string TimeZone { get; set; }
      public double TemperatureInKelvin { get; set; }
      public double ElevationInMeters { get; set; }
   }
}

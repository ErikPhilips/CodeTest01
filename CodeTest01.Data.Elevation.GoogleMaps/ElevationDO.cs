using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest01.Data.Elevation
{
   public interface IElevationDO
   {
      double ElevationInMeters { get; }
   }

   internal class ElevationDO : IElevationDO
   {
      [JsonProperty("elevation")]
      public double ElevationInMeters { get; set; }

   }
}


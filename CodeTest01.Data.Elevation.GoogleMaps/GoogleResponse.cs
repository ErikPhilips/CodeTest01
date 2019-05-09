using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest01.Data.Elevation
{
   internal class GoogleResponse
   {
      [JsonProperty("results")]
      public List<ElevationDO> Elevations { get; set; }

      [JsonProperty("status")]
      public string Status { get; set; }
   }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest01.Data.Weather
{
   public interface ICoordinateDO
   {
      double Longitude { get; }

      double Latitude { get; }
   }


   internal class CoordinateDO : ICoordinateDO
   {
      [JsonProperty("lon")]
      public double Longitude { get; set; }

      [JsonProperty("lat")]
      public double Latitude { get; set; }
   }

}

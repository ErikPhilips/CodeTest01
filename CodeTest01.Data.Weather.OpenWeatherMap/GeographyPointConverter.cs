using Microsoft.Spatial;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest01.Data.Weather
{
   internal class GeographyPointConverter : JsonConverter
   {
      public override bool CanConvert(Type objectType)
      {
         return (objectType == typeof(GeographyPoint));
      }

      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
         JObject jo = JObject.Load(reader);

         double latitude = (double)jo["lat"];
         double longitude = (double)jo["lon"];

         var result = GeographyPoint.Create(latitude, longitude);

         return result;
      }

      public override bool CanWrite
      {
         get { return false; }
      }

      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
      {
         throw new NotImplementedException();
      }
   }
}

using CodeTest01.Business.ZipCodeInfo;
using CodeTest01.Web.UI.API.Version1_0;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace CodeTest01.Web.UI.IntegrationTests
{

   public class FormattersTest
   {
      private const string WhiteHouseZipCode = "20500";
      private WebApplicationFactory<Startup> _server;

      [SetUp]
      public void SetUp()
      {
         _server = new WebApplicationFactory<Startup>();
      }

      [Test]
      public async Task HttpRequest_ForAllValid_ReturnsAStringThatIsNotJson()
      {
         var httpClient = _server.CreateClient();
         httpClient.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("*/*"));

         var actual = await httpClient.GetStringAsync($"/api/v1.0/zipcode/{WhiteHouseZipCode}");

         Assert.Throws<JsonReaderException>(() => JToken.Parse(actual));
      }

      [Test]
      public async Task HttpRequest_ForTextPlain_ReturnsAStringThatIsNotJson()
      {
         var httpClient = _server.CreateClient();
         httpClient.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("text/plain"));

         var actual = await httpClient.GetStringAsync($"/api/v1.0/zipcode/{WhiteHouseZipCode}");

         Assert.Throws<JsonReaderException>(() => JToken.Parse(actual));
      }

      [Test]
      public async Task HttpRequest_ForApplicationJson_ReturnsAStringThatIsJson()
      {
         var httpClient = _server.CreateClient();
         httpClient.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));

         var actual = await httpClient.GetStringAsync($"/api/v1.0/zipcode/{WhiteHouseZipCode}");

         Assert.DoesNotThrow(() => JToken.Parse(actual));
      }
   }
}

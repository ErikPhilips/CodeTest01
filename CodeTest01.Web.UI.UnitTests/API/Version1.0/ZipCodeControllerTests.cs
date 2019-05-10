using CodeTest01.Business.ZipCodeInfo;
using CodeTest01.Web.UI.API.Version1_0;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest01.Web.UI.UnitTests.API.Version1._0
{

   public class ZipCodeControllerTests
   {
      [Test]
      public async Task GetZipCodeInformation_WithValidZipCode_ReturnsOK()
      {
         var zipCodeInfoBL = Substitute.For<IZipCodeInfoBL>();
         zipCodeInfoBL.GetAsync(Arg.Any<string>()).Returns(Substitute.For<IZipCodeInfoBO>());
         var controller = new ZipCodeController(zipCodeInfoBL);

         var result = await controller.GetZipCodeInformation(string.Empty);

         Assert.That(result, Is.InstanceOf<OkObjectResult>());
      }

      [Test]
      public async Task GetZipCodeInformation_WithInvalidZipCode_ReturnsNotFound()
      {
         var zipCodeInfoBL = Substitute.For<IZipCodeInfoBL>();
         zipCodeInfoBL.GetAsync(Arg.Any<string>()).Returns(null as IZipCodeInfoBO);
         var controller = new ZipCodeController(zipCodeInfoBL);

         var result = await controller.GetZipCodeInformation(string.Empty);

         Assert.That(result, Is.InstanceOf<NotFoundResult>());
      }
   }
}

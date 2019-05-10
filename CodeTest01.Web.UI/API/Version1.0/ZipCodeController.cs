using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using CodeTest01.Business.ZipCodeInfo;
using CodeTest01.Web.UI.Models.API.Version1._0;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest01.Web.UI.API.Version1_0
{
   [ApiVersion(Startup.API_VERSION_1_0)]
   [Route("api/v{version:apiVersion}/[controller]")]
   public class ZipCodeController : Controller, IAutoMapper
   {
      private readonly IZipCodeInfoBL _zipCodeInfoBL;

      public ZipCodeController(IZipCodeInfoBL zipCodeInfoBL)
      {
         _zipCodeInfoBL = zipCodeInfoBL;
      }

      public void CreateMap(IMapperConfigurationExpression config)
      {
         config.CreateMap<IZipCodeInfoBO, ZipCodeInfoVM>()
            .ForMember(vm => vm.TemperatureInFahrenheit, 
               m => m.MapFrom(bo => (bo.TemperatureInKelvin - 273.15) * (9/5) + 32 ))
            .ForMember(vm => vm.ElevationInFeet,
               m => m.MapFrom(bo => bo.ElevationInMeters * 3.28084));
      }

      [HttpGet("{zipcode}")]
      public async Task<IActionResult> GetZipCodeInformation(string zipCode)
      {
         var zipCodeInfoBO = await _zipCodeInfoBL.GetAsync(zipCode);

         var result = zipCodeInfoBO != null
            ? Ok(this.Mapper().Map<ZipCodeInfoVM>(zipCodeInfoBO)) as IActionResult
            : NotFound();

         return result;
      }
   }
}

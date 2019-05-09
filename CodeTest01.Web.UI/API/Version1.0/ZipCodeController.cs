using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CodeTest01.Business.ZipCodeInfo;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest01.Web.UI.API.Version1_0
{
   public class ZipCodeController : Controller
   {
      [ApiVersion(Startup.API_VERSION_1_0)]
      [Route("api/v{version:apiVersion}/[controller]")]
      public IActionResult ZipcodeInformation()
      {
         return Ok(new ZipCodeInfoBO());
      }
   }
}

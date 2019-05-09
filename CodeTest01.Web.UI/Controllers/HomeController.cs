using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CodeTest01.Business.ZipCodeInfo;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest01.Web.UI.Controllers
{
   public class HomeController : Controller
   {
      private readonly IZipCodeInfoBL _zipCodeInfoBL;

      public HomeController(IZipCodeInfoBL zipCodeInfoBL)
      {
         _zipCodeInfoBL = zipCodeInfoBL;
      }

      public IActionResult Index()
      {
         return View();
      }
   }
}

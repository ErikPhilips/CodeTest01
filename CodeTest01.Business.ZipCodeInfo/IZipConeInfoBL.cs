using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest01.Business.ZipCodeInfo
{
   public interface IZipCodeInfoBL
   {
      Task<IZipCodeInfoBO> GetAsync(int zipCode);
   }
}

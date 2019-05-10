using AutoMapper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest01.Web.UI
{
   public interface IAutoMapper
   {
      void CreateMap(IMapperConfigurationExpression config);
   }

   public static class IAutoMappingExtensions
   {
      private static ConcurrentDictionary<Type, IMapper> _cache = new ConcurrentDictionary<Type, IMapper>();

      public static IMapper Mapper<TIAutoMapper>(this TIAutoMapper instance)
         where TIAutoMapper : IAutoMapper
      {
         var result = _cache.GetOrAdd(typeof(TIAutoMapper),
            (t) =>
            {
               var config = new MapperConfiguration(cfg =>
               {
                  instance.CreateMap(cfg);
               });

               var mapperInstance = config.CreateMapper();

               return mapperInstance;
            });

         return result;
      }
   }

}

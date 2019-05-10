using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;

namespace CodeTest01
{
   public static class Configuration
   {
      private static readonly IConfigurationRoot ConfigurationRoot;

      static Configuration()
      {
         var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("secrets.json", optional: true);

         ConfigurationRoot = builder.Build();
      }

      public static IOptions<TConfiguration> GetOptions<TConfiguration>(string sectionName)
         where TConfiguration : class, new()
      {
         var configuration =  ConfigurationRoot.GetSection(sectionName).Get<TConfiguration>();
         var result = Options.Create(configuration);
         return result;
      }
   }
}

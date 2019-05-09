using Microsoft.Extensions.Configuration;
using System;

namespace CodeTest01.IntegrationTesting
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

      public static TConfiguration GetSection<TConfiguration>(string sectionName)
      {
         var result = ConfigurationRoot.GetSection(sectionName).Get<TConfiguration>();
         return result;
      }
   }
}

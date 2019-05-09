using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CodeTest01.Business.ZipCodeInfo;
using CodeTest01.Data.Weather;
using CodeTest01.Web.UI.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeTest01.Web.UI
{
   public class Startup
   {
      private const int DEFAULT_API_VERSION_MAJOR = 1;
      private const int DEFAULT_API_VERSION_MINOR = 0;
      internal const string API_VERSION_1_0 = "1.0";

      internal const string DEFAULT_API_VERSION = API_VERSION_1_0;

      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      public void ConfigureServices(IServiceCollection services)
      {
         services.Configure<CookiePolicyOptions>(options =>
         {
            // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            options.CheckConsentNeeded = context => false;
            options.MinimumSameSitePolicy = SameSiteMode.None;
         });


         services.AddResponseCompression();

         services
            .AddMvc(options => {
               options.OutputFormatters.Insert(0, new TextPlainOutputFormatter());
               options.RespectBrowserAcceptHeader = true;
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

         services.AddApiVersioning((ApiVersioningOptions v) =>
         {
            v.AssumeDefaultVersionWhenUnspecified = true;
            v.DefaultApiVersion = new ApiVersion(DEFAULT_API_VERSION_MAJOR, DEFAULT_API_VERSION_MINOR);
         });

         ConfigureDependencies(services);
      }

      private void ConfigureDependencies(IServiceCollection services)
      {
         services.AddSingleton<HttpClient>();

         services.AddTransient<IWeatherDL, WeatherDL>();

         services.AddTransient<IZipCodeInfoBL, ZipCodeInfoBL>();

      }

      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }
         else
         {
            // app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
         }

         app.UseResponseCompression();
         app.UseHttpsRedirection();
         app.UseStaticFiles();
         // app.UseCookiePolicy();

         app.UseMvc(routes =>
         {
            routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");
         });
      }
   }
}

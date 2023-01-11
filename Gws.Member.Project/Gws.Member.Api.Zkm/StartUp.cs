using System.Text.Encodings.Web;
using System.Text.Unicode;
using Gws.Common.Global;
using Gws.Common.Services;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.WebEncoders;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.IdentityModel.Logging;

namespace Gws.Member.Api.Zkm
{
    #nullable disable
    public class StartUp
    {
        public IWebHostEnvironment _env { get; }

        public IConfiguration _cfg { get; }

        public StartUp(IConfiguration cfg)// , IWebHostEnvironment env
        {
            _cfg = cfg;
            // _env = env;
        }

         public void ConfigureServices(IServiceCollection services)
        {
            JsonConvert.DefaultSettings = (() =>
            {
                var settings = new JsonSerializerSettings();
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                settings.Converters.Add(new StringEnumConverter());
                return settings;
            });
            
            GlobalStatic.Init();

            services.AddCors();

            services.Configure<WebEncoderOptions>(options =>
            {
                options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
            });

            var globalAppSection = _cfg.GetSection("GlobalAppConfig");
            services.Configure<GlobalAppConfig>(globalAppSection);

            var appSettings = globalAppSection.Get<GlobalAppConfig>();

            GlobalStatic.DI(services, appSettings, true);
        }

        
          public void Configure(
            IApplicationBuilder app,
             ISysService sys
            )
        {
            if (_env.IsDevelopment())
            {
                IdentityModelEventSource.ShowPII = true;
            }
            else
            {
                app.UseRewriter(new RewriteOptions().AddRedirectToHttps(StatusCodes.Status301MovedPermanently, 443));
            }

            // //맨앞?????
            // app.UseMiddleware<ExceptionHandlingMiddleware>();

            // // app.UseExceptionHandler("/error/500");
            // // app.UseStatusCodePagesWithReExecute("/error/{0}");

            //     app.UseCors(options => options
            //     .WithOrigins(siteList.ToArray())
            //     .SetIsOriginAllowed(origin => {
            //         origin = origin.ToLower();

            //         if (origin.EndsWith(".goodsflow.com"))
            //             return true;
            //         else if (siteList.Contains(origin))
            //             return true;

            //         string host = new Uri(origin).Host.ToLower();
            //         if (host == "localhost" || host.StartsWith("192.168.20.") || host.StartsWith("192.168.10."))
            //             return true;

            //         return false;
            //     })
            //     .AllowAnyMethod()
            //     .AllowAnyHeader()
            //     .AllowCredentials()
            // );


            app.UseFileServer();
            app.UseRouting();

         

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
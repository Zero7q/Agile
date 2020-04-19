using Agile.Core;
using Agile.Core.Infrastructure;
using Agile.Web.Framework.ViewLocationExpander;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agile.Web.Framework.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IEngine ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            CommonHelper.DefaultFileProvider = new AgileFileProvider(webHostEnvironment);

            var mvcCoreBuilder = services.AddMvcCore();

            mvcCoreBuilder.PartManager.InitializePlugins();

            var engine = EngineContext.Create();

            engine.ConfigureServices(services, configuration);

            return engine;
        }

        public static IMvcBuilder AddAgileMvc(this IServiceCollection services)
        {
            var mvcBuilder = services.AddControllersWithViews();

            mvcBuilder.AddRazorRuntimeCompilation();

            return mvcBuilder;
        }

        public static void AddHttpSession(this IServiceCollection services)
        {
            services.AddSession();
        }

        public static void AddViewLocationExpander(this IServiceCollection services)
        {
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new AgileViewLocationExpander());
            });
        }
    }
}

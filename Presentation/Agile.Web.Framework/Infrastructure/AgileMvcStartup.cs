﻿using Agile.Core.Infrastructure;
using Agile.Web.Framework.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Web.Framework.Infrastructure
{
    public class AgileMvcStartup : IAgileStartup
    {
        public int Order => 1000;

        public void Configure(IApplicationBuilder application)
        {
            application.UseAgileEndpoints();
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAgileMvc();
        }
    }
}

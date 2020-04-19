using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Core.Infrastructure
{
    public interface IEngine
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);

        void ConfigureRequestPipeline(IApplicationBuilder application);

        void RegisterDependencies(ContainerBuilder containerBuilder);

        T Resolve<T>() where T : class;

        IEnumerable<T> ResolveAll<T>();

        object ResolveUnregistered(Type type);
    }
}

using Agile.Core;
//using Agile.Core.Caching;
//using Agile.Core.Configuration;
//using Agile.Core.Domain.Stores;
using Agile.Core.Infrastructure;
using Agile.Core.Infrastructure.DependencyManagement;
//using Agile.Data;
//using Agile.Services.Configuration;
//using Agile.Services.Events;
//using Agile.Services.Logging;
using Agile.Web.Framework.Mvc.Routing;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Agile.Web.Framework.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 0;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterType<AgileFileProvider>().As<IAgileFileProvider>().InstancePerLifetimeScope();

            //builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerLifetimeScope();

            //builder.RegisterType<DataProviderManager>().As<IDataProviderManager>().InstancePerDependency();
            //builder.Register(context => context.Resolve<IDataProviderManager>().DataProvider).As<IAgileDataProvider>().InstancePerDependency();

            //builder.RegisterGeneric(typeof(EntityRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            //builder.RegisterType<MemoryCacheManager>()
            //       .As<ILocker>()
            //       .As<IStaticCacheManager>()
            //       .SingleInstance();

            builder.RegisterType<RoutePublisher>().As<IRoutePublisher>().SingleInstance();

            //builder.RegisterType<EventPublisher>().As<IEventPublisher>().SingleInstance();

            //builder.RegisterType<SettingService>().As<ISettingService>().InstancePerLifetimeScope();

            //builder.RegisterType<ActionContextAccessor>().As<IActionContextAccessor>().InstancePerLifetimeScope();

            //builder.RegisterSource(new SettingsSource());
        }
    }

    //public class SettingsSource : IRegistrationSource
    //{
    //    private static readonly MethodInfo _buildMethod =
    //        typeof(SettingsSource).GetMethod("BuildRegistration", BindingFlags.Static | BindingFlags.NonPublic);

    //    /// <summary>
    //    /// Registrations for
    //    /// </summary>
    //    /// <param name="service">Service</param>
    //    /// <param name="registrations">Registrations</param>
    //    /// <returns>Registrations</returns>
    //    public IEnumerable<IComponentRegistration> RegistrationsFor(Service service,
    //        Func<Service, IEnumerable<IComponentRegistration>> registrations)
    //    {
    //        var ts = service as TypedService;
    //        if (ts != null && typeof(ISettings).IsAssignableFrom(ts.ServiceType))
    //        {
    //            var buildMethod = _buildMethod.MakeGenericMethod(ts.ServiceType);
    //            yield return (IComponentRegistration)buildMethod.Invoke(null, null);
    //        }
    //    }

    //    private static IComponentRegistration BuildRegistration<TSettings>() where TSettings : ISettings, new()
    //    {
    //        return RegistrationBuilder
    //            .ForDelegate((c, p) =>
    //            {
    //                Store store;

    //                try
    //                {
    //                    store = c.Resolve<IStoreContext>().CurrentStore;
    //                }
    //                catch
    //                {
    //                    if (!DataSettingsManager.DatabaseIsInstalled)
    //                        store = null;
    //                    else
    //                        throw;
    //                }

    //                var currentStoreId = store?.Id ?? 0;

    //                //uncomment the code below if you want load settings per store only when you have two stores installed.
    //                //var currentStoreId = c.Resolve<IStoreService>().GetAllStores().Count > 1
    //                //    c.Resolve<IStoreContext>().CurrentStore.Id : 0;

    //                //although it's better to connect to your database and execute the following SQL:
    //                //DELETE FROM [Setting] WHERE [StoreId] > 0
    //                try
    //                {
    //                    return c.Resolve<ISettingService>().LoadSetting<TSettings>(currentStoreId);
    //                }
    //                catch
    //                {
    //                    if (DataSettingsManager.DatabaseIsInstalled)
    //                        throw;
    //                }

    //                return default;
    //            })
    //            .InstancePerLifetimeScope()
    //            .CreateRegistration();
    //    }

    //    /// <summary>
    //    /// Is adapter for individual components
    //    /// </summary>
    //    public bool IsAdapterForIndividualComponents => false;
    //}
}

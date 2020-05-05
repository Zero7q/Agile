using Agile.Core;
//using Agile.Core.Caching;
//using Agile.Core.Configuration;
//using Agile.Core.Domain.Stores;
using Agile.Core.Infrastructure;
using Agile.Core.Infrastructure.DependencyManagement;
using Agile.Data;
using Agile.Services;
using Agile.Services.Menus;
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

            builder.RegisterType<DataProviderManager>().As<IDataProviderManager>().InstancePerDependency();

            builder.RegisterGeneric(typeof(EntityRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EntityRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<RoutePublisher>().As<IRoutePublisher>().SingleInstance();

            builder.RegisterType<MenuParseService>().As<IMenuParseService>().SingleInstance();

            builder.RegisterType<MenuService>().As<IMenuService>().SingleInstance();

            builder.RegisterType<SysDepartmentService>().As<ISysDepartmentService>().SingleInstance();

            builder.RegisterType<SysRoleService>().As<ISysRoleService>().SingleInstance();

            builder.RegisterType<UserDepartmentService>().As<IUserDepartmentService>().SingleInstance();

            
        }
    }
}

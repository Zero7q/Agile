using Agile.Core.Infrastructure;
using Agile.Core.Logging;
using Agile.Web.Framework.Mvc.Routing;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Web.Framework.Infrastructure.Extensions
{
    /// <summary>
    /// IApplicationBuilder扩展
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// 配置应用程序HTTP请求管道
        /// </summary>
        /// <param name="application">用于配置应用程序的请求管道的生成器</param>
        public static void ConfigureRequestPipeline(this IApplicationBuilder application)
        {
            EngineContext.Current.ConfigureRequestPipeline(application);
        }

        /// <summary>
        /// 启动引擎
        /// </summary>
        /// <param name="application">管道构建</param>
        public static void StartEngine(this IApplicationBuilder application)
        {
            EngineContext.Current.Resolve<ILogger>().Information("系统引擎正在启动..", typeof(ApplicationBuilderExtensions));
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="application">用于配置应用程序的请求管道的生成器</param>
        public static void UseAgileExceptionHandler(this IApplicationBuilder application)
        {
            application.UseExceptionHandler(handler =>
            {
                handler.Run(context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                    if (exception == null)
                    {
                        return Task.CompletedTask;
                    }

                    List<string> messageLists = new List<string>();
                    messageLists.Add($"请求路径：{context.Request.Path}");
                    messageLists.Add($" 异常类型：{exception.GetType().Name}");
                    messageLists.Add($" 异常方法：{exception.TargetSite.Name}");
                    messageLists.Add($" 异常信息：{exception.Message}");

                    string message = $"全局异常捕获{Environment.NewLine} {string.Join(Environment.NewLine, messageLists)}";

                    EngineContext.Current.Resolve<ILogger>().Error(message, exception.GetType(), exception);

                    context.Response.Redirect("/admin/common/error");

                    return Task.CompletedTask;
                });
            });
        }

        /// <summary>
        /// 添加一个特殊的处理程序，用于检查404状态代码中没有正文的响应
        /// </summary>
        /// <param name="application"></param>
        public static void UsePageNotFound(this IApplicationBuilder application)
        {
            application.UseStatusCodePages(async context =>
            {
                if (context.HttpContext.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    context.HttpContext.Response.Redirect("/admin/common/notfoundpage");

                    await Task.CompletedTask;
                }
            });
        }

        /// <summary>
        /// 配置静态文件服务
        /// </summary>
        /// <param name="application"></param>
        public static void UseAgileStaticFiles(this IApplicationBuilder application)
        {
            application.UseStaticFiles();
        }

        /// <summary>
        /// 配置路由
        /// </summary>
        /// <param name="application"></param>
        public static void UseAgileEndpoints(this IApplicationBuilder application)
        {
            application.UseRouting();

            application.UseEndpoints(endpoints =>
            {
                EngineContext.Current.Resolve<IRoutePublisher>().RegisterRoutes(endpoints);
            });
        }
    }
}

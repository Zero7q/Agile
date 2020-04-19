using Agile.Core.Infrastructure;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Agile.Core.Logging
{
    public partial class DefaultLogger : ILogger
    {
        #region Methods

        public DefaultLogger()
        {
            IAgileFileProvider fileProvider = EngineContext.Current.Resolve<IAgileFileProvider>();

            var log4configPath = fileProvider.MapPath(AgileLoggerDefaults.Log4netConfigPath);

            var repository = LogManager.CreateRepository(AgileLoggerDefaults.NETCoreRepository);

            XmlConfigurator.Configure(repository, new FileInfo(log4configPath));
        }

        /// <summary>
        /// Inserts a log item
        /// </summary>
        /// <param name="logLevel">Log level</param>
        /// <param name="shortMessage">The short message</param>
        /// <param name="fullMessage">The full message</param>
        /// <param name="customer">The customer to associate log record with</param>
        /// <returns>A log item</returns>
        public virtual void InsertLog(LogLevel logLevel, Type type, string message, Exception exception = null)
        {
            var logger = LogManager.GetLogger(AgileLoggerDefaults.NETCoreRepository, type);
            switch (logLevel)
            {
                case LogLevel.Debug:
                    logger.Debug(message, exception);
                    break;
                case LogLevel.Information:
                    logger.Info(message, exception);
                    break;
                case LogLevel.Warning:
                    logger.Warn(message, exception);
                    break;
                case LogLevel.Error:
                    logger.Error(message, exception);
                    break;
                case LogLevel.Fatal:
                    logger.Fatal(message, exception);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Information
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="exception">Exception</param>
        /// <param name="customer">Customer</param>
        public virtual void Information(string message, Type type, Exception exception = null)
        {
            InsertLog(LogLevel.Information, type, message, exception);
        }

        /// <summary>
        /// Warning
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="exception">Exception</param>
        /// <param name="customer">Customer</param>
        public virtual void Warning(string message, Type type, Exception exception = null)
        {
            InsertLog(LogLevel.Warning, type, message, exception);
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="exception">Exception</param>
        /// <param name="customer">Customer</param>
        public virtual void Error(string message, Type type, Exception exception = null)
        {
            InsertLog(LogLevel.Error, type, message, exception);
        }

        #endregion
    }
}

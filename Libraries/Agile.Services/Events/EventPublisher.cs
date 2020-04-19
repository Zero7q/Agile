﻿using Agile.Core.Infrastructure;
using Agile.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agile.Services.Events
{
    public partial class EventPublisher : IEventPublisher
    {
        #region Methods

        /// <summary>
        /// Publish event to consumers
        /// </summary>
        /// <typeparam name="TEvent">Type of event</typeparam>
        /// <param name="event">Event object</param>
        public virtual void Publish<TEvent>(TEvent @event)
        {
            //get all event consumers
            var consumers = EngineContext.Current.ResolveAll<IConsumer<TEvent>>().ToList();

            foreach (var consumer in consumers)
            {
                try
                {
                    //try to handle published event
                    consumer.HandleEvent(@event);
                }
                catch (Exception exception)
                {
                    //log error, we put in to nested try-catch to prevent possible cyclic (if some error occurs)
                    try
                    {
                        EngineContext.Current.Resolve<ILogger>()?.Error(exception.Message, exception);
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Services.Events
{
    public partial interface IEventPublisher
    {
        /// <summary>
        /// Publish event to consumers
        /// </summary>
        /// <typeparam name="TEvent">Type of event</typeparam>
        /// <param name="event">Event object</param>
        void Publish<TEvent>(TEvent @event);
    }
}

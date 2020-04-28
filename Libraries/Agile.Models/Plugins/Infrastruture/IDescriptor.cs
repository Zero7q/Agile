using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Plugins.Infrastruture
{
    public interface IDescriptor
    {
        /// <summary>
        /// Gets or sets the system name
        /// </summary>
        string SystemName { get; set; }

        /// <summary>
        /// Gets or sets the friendly name
        /// </summary>
        string FriendlyName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Plugins.Infrastruture
{
    public interface IPluginsInfo
    {
        void Save();
        bool LoadPluginInfo();

        IList<PluginDescriptorBaseInfo> InstalledPlugins { get; set; }

        IList<(string SystemName, Guid? CustomerGuid)> PluginNamesToInstall { get; set; }

        IList<string> PluginNamesToDelete { get; set; }

        IList<PluginDescriptor> PluginDescriptors { get; set; }

        IList<string> IncompatiblePlugins { get; set; }

        IList<PluginLoadedAssemblyInfo> AssemblyLoadedCollision { get; set; }
    }
}

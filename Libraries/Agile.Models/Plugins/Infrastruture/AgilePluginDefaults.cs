using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Plugins.Infrastruture
{
    public static class AgilePluginDefaults
    {
        public static string Path => "~/Plugins";

        public static string ShadowCopyPath => "~/Plugins/bin";

        public static string ReserveShadowCopyPathNamePattern => "reserve_bin_*";

        public static string DescriptionFileName => "plugin.json";

        public static string PathName => "Plugins";

        public static string ReserveShadowCopyPathName => "reserve_bin_";

        public static string PluginsInfoFilePath => "~/App_Data/plugins.json";

        public static string ObsoleteInstalledPluginsFilePath => "~/App_Data/InstalledPlugins.txt";

        public static string InstalledPluginsFilePath => "~/App_Data/installedPlugins.json";

        public static string RefsPathName => "refs";
    }
}

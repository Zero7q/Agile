using Agile.Core.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Agile.Models.Plugins.Infrastruture
{
    public class PluginsInfo : IPluginsInfo
    {
        private const string OBSOLETE_FIELD = "Obsolete field, using only for compatibility";
        private List<string> _installedPluginNames = new List<string>();
        private IList<PluginDescriptorBaseInfo> _installedPlugins = new List<PluginDescriptorBaseInfo>();
        protected readonly IAgileFileProvider _fileProvider;

        public PluginsInfo(IAgileFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public virtual IList<PluginDescriptorBaseInfo> InstalledPlugins
        {
            get
            {
                if ((_installedPlugins?.Any() ?? false) || !_installedPluginNames.Any())
                    return _installedPlugins;

                if (PluginDescriptors?.Any() ?? false)
                    _installedPlugins = PluginDescriptors
                        .Where(pd => _installedPluginNames.Any(pn =>
                            pn.Equals(pd.SystemName, StringComparison.InvariantCultureIgnoreCase)))
                        .Select(pd => pd as PluginDescriptorBaseInfo).ToList();
                else
                    return _installedPluginNames
                        .Where(name => !name.Equals(OBSOLETE_FIELD, StringComparison.InvariantCultureIgnoreCase))
                        .Select(systemName => new PluginDescriptorBaseInfo { SystemName = systemName }).ToList();

                return _installedPlugins;
            }
            set => _installedPlugins = value;
        }

        public bool LoadPluginInfo()
        {
            var filePath = _fileProvider.MapPath(AgilePluginDefaults.PluginsInfoFilePath);
            if (!_fileProvider.FileExists(filePath))
            {
                //file doesn't exist, so try to get only installed plugin names from the obsolete file
                _installedPluginNames.AddRange(GetObsoleteInstalledPluginNames());

                //and save info into a new file if need
                if (_installedPluginNames.Any())
                    Save();
            }

            //try to get plugin info from the JSON file
            var text = _fileProvider.FileExists(filePath)
                ? _fileProvider.ReadAllText(filePath, Encoding.UTF8)
                : string.Empty;
            return !string.IsNullOrEmpty(text) && DeserializePluginInfo(text);
        }

        public virtual IList<string> InstalledPluginNames
        {
            get
            {
                if (_installedPlugins.Any())
                    _installedPluginNames.Clear();

                return _installedPluginNames.Any() ? _installedPluginNames : new List<string> { OBSOLETE_FIELD };
            }
            set
            {
                if (value?.Any() ?? false)
                    _installedPluginNames = value.ToList();
            }
        }
        protected virtual bool DeserializePluginInfo(string json)
        {
            var pluginsInfo = JsonConvert.DeserializeObject<PluginsInfo>(json);

            InstalledPluginNames = pluginsInfo.InstalledPluginNames;
            InstalledPlugins = pluginsInfo.InstalledPlugins;
            PluginNamesToUninstall = pluginsInfo.PluginNamesToUninstall;
            PluginNamesToDelete = pluginsInfo.PluginNamesToDelete;
            PluginNamesToInstall = pluginsInfo.PluginNamesToInstall;

            return InstalledPlugins.Any() || PluginNamesToUninstall.Any() || PluginNamesToDelete.Any() ||
                   PluginNamesToInstall.Any();
        }

        protected virtual IList<string> GetObsoleteInstalledPluginNames()
        {
            //check whether file exists
            var filePath = _fileProvider.MapPath(AgilePluginDefaults.InstalledPluginsFilePath);
            if (!_fileProvider.FileExists(filePath))
            {
                //if not, try to parse the file that was used in previous nopCommerce versions
                filePath = _fileProvider.MapPath(AgilePluginDefaults.ObsoleteInstalledPluginsFilePath);
                if (!_fileProvider.FileExists(filePath))
                    return new List<string>();

                //get plugin system names from the old txt file
                var pluginSystemNames = new List<string>();
                using (var reader = new StringReader(_fileProvider.ReadAllText(filePath, Encoding.UTF8)))
                {
                    string pluginName;
                    while ((pluginName = reader.ReadLine()) != null)
                        if (!string.IsNullOrWhiteSpace(pluginName))
                            pluginSystemNames.Add(pluginName.Trim());
                }

                //and delete the old one
                _fileProvider.DeleteFile(filePath);

                return pluginSystemNames;
            }

            var text = _fileProvider.ReadAllText(filePath, Encoding.UTF8);
            if (string.IsNullOrEmpty(text))
                return new List<string>();

            //delete the old file
            _fileProvider.DeleteFile(filePath);

            //get plugin system names from the JSON file
            return JsonConvert.DeserializeObject<IList<string>>(text);
        }

        public void Save()
        {
            var filePath = _fileProvider.MapPath(AgilePluginDefaults.PluginsInfoFilePath);
            var text = JsonConvert.SerializeObject(this, Formatting.Indented);
            _fileProvider.WriteAllText(filePath, text, Encoding.UTF8);
        }

        public virtual IList<string> PluginNamesToUninstall { get; set; } = new List<string>();

        [JsonIgnore]
        public virtual IList<PluginDescriptor> PluginDescriptors { get; set; }
        public virtual IList<(string SystemName, Guid? CustomerGuid)> PluginNamesToInstall { get; set; } =
             new List<(string SystemName, Guid? CustomerGuid)>();

        public virtual IList<string> PluginNamesToDelete { get; set; } = new List<string>();
        [JsonIgnore]
        public virtual IList<string> IncompatiblePlugins { get; set; }
        [JsonIgnore]
        public virtual IList<PluginLoadedAssemblyInfo> AssemblyLoadedCollision { get; set; }
    }
}

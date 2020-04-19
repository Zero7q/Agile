using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Agile.Services.Plugins
{
    public class PluginDescriptor : PluginDescriptorBaseInfo, IDescriptor, IComparable<PluginDescriptor>
    {
        

        public int CompareTo([AllowNull] PluginDescriptor other)
        {
            if (DisplayOrder != other.DisplayOrder)
                return DisplayOrder.CompareTo(other.DisplayOrder);

            return string.Compare(SystemName, other.SystemName, StringComparison.InvariantCultureIgnoreCase);
        }

       

        public static PluginDescriptor GetPluginDescriptorFromText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return new PluginDescriptor();

            //get plugin descriptor from the JSON file
            var descriptor = JsonConvert.DeserializeObject<PluginDescriptor>(text);

            //nopCommerce 2.00 didn't have 'SupportedVersions' parameter, so let's set it to "2.00"
            if (!descriptor.SupportedVersions.Any())
                descriptor.SupportedVersions.Add("2.00");

            return descriptor;
        }

        [JsonProperty(PropertyName = "FriendlyName")]
        public virtual string FriendlyName { get; set; }

        [JsonProperty(PropertyName = "DisplayOrder")]
        public virtual int DisplayOrder { get; set; }

        [JsonProperty(PropertyName = "SupportedVersions")]
        public virtual IList<string> SupportedVersions { get; set; }

        [JsonProperty(PropertyName = "FileName")]
        public virtual string AssemblyFileName { get; set; }

        [JsonIgnore]
        public virtual string OriginalAssemblyFile { get; set; }

        [JsonIgnore]
        public virtual Assembly ReferencedAssembly { get; set; }

        [JsonIgnore]
        public virtual bool Installed { get; set; }

        [JsonIgnore]
        public virtual Type PluginType { get; set; }
    }
}

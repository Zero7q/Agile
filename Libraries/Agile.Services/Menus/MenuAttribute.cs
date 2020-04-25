using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Services.Menus
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MenuAttribute : Attribute
    {
        public MenuAttribute(string name, string icon, string url)
        {
            Name = name;
            Icon = icon;
            Url = url;
        }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
    }
}

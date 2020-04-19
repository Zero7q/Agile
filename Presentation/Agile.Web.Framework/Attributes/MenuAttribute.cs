using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Web.Framework.Attributes
{
    public class MenuAttribute : Attribute
    {
        public MenuAttribute(string name, string icon, string url)
        {

        }
        public bool IsRoot { get; set; }

        public string Url { get; set; }

        public string ParentMenu { get; set; }
    }
}

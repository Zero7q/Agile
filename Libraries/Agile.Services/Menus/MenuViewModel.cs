using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Services.Menus
{
    public class MenuViewModel
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public List<MenuViewModel> SubMenus { get; set; }
    }
}

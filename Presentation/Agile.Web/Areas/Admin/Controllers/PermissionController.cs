using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Models.Menus.Infrastructure;
using Agile.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Agile.Web.Areas.Admin.Controllers
{
    [MenuAttribute(MenuType.Display, "系统管理|权限管理", "/admin/permission/list")]
    public class PermissionController : BasePluginController
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
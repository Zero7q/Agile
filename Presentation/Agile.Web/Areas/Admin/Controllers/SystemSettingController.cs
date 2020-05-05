using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Models.Infrastructure;
using Agile.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Agile.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 系统设置控制器
    /// </summary>
    [Menu(MenuType.Page, "系统管理|系统设置", "/admin/systemsetting/list")]
    public class SystemSettingController : BasePluginController
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
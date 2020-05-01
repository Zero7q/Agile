using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Models.Infrastructure;
using Agile.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Agile.Web.Areas.Admin.Controllers
{
    [MenuAttribute(MenuType.Page, "系统管理|用户管理", "/admin/user/list")]
    public class UserController : BasePluginController
    {

        public IActionResult List()
        {
            return View();
        }
    }
}
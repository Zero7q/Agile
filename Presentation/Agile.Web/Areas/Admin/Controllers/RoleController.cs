using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Core.Domain;
using Agile.Data;
using Agile.Models.Domain;
using Agile.Models.Infrastructure;
using Agile.Models.ViewModels;
using Agile.Services;
using Agile.Web.Framework.Controllers;
using DapperExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Agile.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 角色控制器
    /// </summary>
    [Menu(MenuType.Page, "系统管理|角色管理", "/admin/role/list")]
    public class RoleController : BaseTemplateController<SysRole, SysRoleViewModel>
    {
        private readonly ISysRoleService _sysRoleService;

        public RoleController(ISysRoleService sysRoleService, IRepository<SysRole> repository) : base(repository)
        {
            _sysRoleService = sysRoleService;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agile.Core.Domain;
using Agile.Data;
using Agile.Models.Domain;
using Agile.Models.Infrastructure;
using Agile.Models.ViewModels;
using Agile.Services.Menus;
using Agile.Web.Framework.Controllers;
using DapperExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Agile.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 菜单控制器
    /// </summary>
    [MenuAttribute(MenuType.Page, "系统管理|菜单管理", "/admin/menu/list")]
    public class MenuController : BaseTemplateController<SysMenu, SysMenuViewModel>
    {
        private readonly IMenuService _menuService;
        private readonly IRepository<SysMenu> _repository;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="menuService"></param>
        public MenuController(IMenuService menuService, IRepository<SysMenu> repository)
            : base(repository)
        {
            _menuService = menuService;
            _repository = repository;
        }

        /// <summary>
        /// 菜单列表
        /// </summary>
        /// <returns></returns>
        [PermissionAttribute("view")]
        public override IActionResult List()
        {
            var model = new SysMenuViewModel();
            model.ParentSelectItems = _menuService.ParentSelectItems();
            return View(model);
        }

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <returns></returns>
        [PermissionAttribute("view")]
        public IActionResult GetSideData()
        {
            var result = _menuService.GetMenus();

            return SuccessJson(result);
        }

        /// <summary>
        /// 获取菜单侧边栏列表数据
        /// </summary>
        /// <returns></returns>
        [PermissionAttribute("view")]
        public IActionResult GetTreeData()
        {
            var result = _menuService.GetTreeMenus();

            return SuccessJson(result);
        }


        [PermissionAttribute("view")]
        public override IActionResult GetData(SysMenuViewModel model)
        {
            var sort = ListSortFilter(model);
            if (sort == null)
            {
                throw new ArgumentNullException(nameof(sort));
            }
            var predicate = ListWhereFilter(model);
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            var datas = _repository.GetList(predicate, sort);
            var lists = new List<SysMenuViewModel>();
            foreach (var data in datas)
            {
                lists.Add(ParseToModel(data));
            }
            return SuccessJson(lists, lists.Count);
        }

    }
}
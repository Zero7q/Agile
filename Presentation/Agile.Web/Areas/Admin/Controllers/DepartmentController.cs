using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agile.Core.Domain;
using Agile.Models.Domain;
using Agile.Models.Infrastructure;
using Agile.Models.ViewModels;
using Agile.Services;
using Agile.Web.Framework.Controllers;
using DapperExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Agile.Web.Areas.Admin.Controllers
{
    [MenuAttribute(MenuType.Page, "系统管理|部门管理", "/admin/department/list")]
    public class DepartmentController : BasePluginController
    {
        private readonly ISysDepartmentService _sysDepartmentService;
        public DepartmentController(ISysDepartmentService sysDepartmentService)
        {
            _sysDepartmentService = sysDepartmentService;
        }

        /// <summary>
        /// 列表页
        /// </summary>
        /// <returns></returns>
        [PermissionAttribute("view")]
        public IActionResult List()
        {
            var model = new SysDepartmentViewModel();
            return View(model);
        }

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <returns>数据列表</returns>
        [PermissionAttribute("view")]
        public IActionResult GetData()
        {
            object predicate = Predicates.Field<SysDepartment>(f => f.IsEnabled, Operator.Eq, EnabledType.True);

            IList<ISort> sort = new List<ISort>();
            sort.Add(new Sort { PropertyName = "id", Ascending = false });

            int page = 0;

            int resultsPerPage = 0;

            int total;

            var result = _sysDepartmentService.GetPage(predicate, sort, page, resultsPerPage, out total);

            return Success(result, total);
        }

        /// <summary>
        /// 获取树列表数据
        /// </summary>
        /// <returns>数据列表</returns>
        [PermissionAttribute("view")]
        public IActionResult GetTreeData()
        {
            var result = _sysDepartmentService.GetTreeData();

            return Success(result);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns>视图</returns>
        [PermissionAttribute("add")]
        public IActionResult Add()
        {
            var model = new SysDepartmentViewModel();

            return View(model);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [PermissionAttribute("add")]
        public IActionResult Add(SysDepartmentViewModel sysDepartmentViewModel)
        {
            if (sysDepartmentViewModel == null)
            {
                throw new ArgumentNullException(nameof(sysDepartmentViewModel));
            }
            if (string.IsNullOrWhiteSpace(sysDepartmentViewModel.DepartmentName))
            {
                return Error("部门名称不能为空！");
            }

            _sysDepartmentService.Insert(new SysDepartment() { DepartmentName = sysDepartmentViewModel.DepartmentName, CreateTime = DateTime.Now });

            return Success();
        }
    }
}
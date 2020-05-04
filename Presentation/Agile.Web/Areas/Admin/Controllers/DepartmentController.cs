using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agile.Core.Domain;
using Agile.Core.Extensions;
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
    [MenuAttribute(MenuType.Page, "系统管理|部门管理", "/admin/department/list")]
    public class DepartmentController : BaseTemplateController<SysDepartment, SysDepartmentViewModel>
    {
        private readonly IRepository<SysDepartment> _repository;
        public DepartmentController(IRepository<SysDepartment> repository) : base(repository)
        {
            _repository = repository;
        }

        public override void OnAddLoading(SysDepartmentViewModel model)
        {
            Request.Query["parentid"].ToString().TryStringToInt(out int parentId);

            model.ParentId = parentId;
        }

        public override void OnEditloading(SysDepartmentViewModel model)
        {
            Request.Query["parentid"].ToString().TryStringToInt(out int parentId);

            model.ParentId = parentId;
        }

        public override string OnAdding(SysDepartmentViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var department = _repository.GetByCondition(Predicates.Field<SysDepartment>(f => f.ParentId, Operator.Eq, -1));
            if (department != null && model.ParentId == -1)
            {
                return "只允许一个顶级节点！";
            }
            if (string.IsNullOrWhiteSpace(model.DepartmentName))
            {
                return "部门名称不能为空！";
            }
            if (department != null && department.DepartmentName.Equals(model.DepartmentName))
            {
                return "部门名称和顶级节点不能相同！";
            }
            var predicate = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            predicate.Predicates.Add(Predicates.Field<SysDepartment>(f => f.DepartmentName, Operator.Eq, model.DepartmentName));
            predicate.Predicates.Add(Predicates.Field<SysDepartment>(f => f.ParentId, Operator.Eq, model.ParentId));
            if (_repository.GetByCondition(predicate) != null)
            {
                return "部门名称已存在！";
            }
            return string.Empty;
        }

        public override IActionResult GetData(SysDepartmentViewModel model)
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
            var lists = new List<SysDepartmentViewModel>();
            foreach (var data in datas)
            {
                lists.Add(ParseToModel(data));
            }
            return SuccessJson(lists, lists.Count);
        }

        public override void OnDeleteAfter(string ids)
        {
            string[] deleteIds = ids.Split(',');
            foreach (var id in deleteIds)
            {
                var departments = _repository.GetList(Predicates.Field<SysDepartment>(f => f.ParentId, Operator.Eq, id));
                if (departments != null)
                {
                    foreach (var department in departments)
                    {
                        _repository.Delete(department);
                        OnDeleteAfter($"{department.Id}");
                    }
                }
            }
        }

        public override IPredicateGroup ListWhereFilter(SysDepartmentViewModel model)
        {
            var predicate = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            predicate.Predicates.Add(Predicates.Field<SysDepartment>(f => f.IsEnabled, Operator.Eq, EnabledType.True));
            if (!string.IsNullOrWhiteSpace(model.DepartmentName))
            {
                predicate.Predicates.Add(Predicates.Field<SysDepartment>(f => f.DepartmentName, Operator.Like, $"%{model.DepartmentName}%"));
            }
            return predicate;
        }
    }
}
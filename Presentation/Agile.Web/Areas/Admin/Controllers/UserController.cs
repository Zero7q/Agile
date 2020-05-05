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
    [MenuAttribute(MenuType.Page, "系统管理|用户管理", "/admin/user/list")]
    public class UserController : BaseTemplateController<SysUser, SysUserViewModel>
    {
        private readonly IUserDepartmentService _userDepartmentService;
        private readonly IRepository<SysUserDepartment> _userDepartmentRepository;
        public UserController(IRepository<SysUser> repository, IRepository<SysUserDepartment> userDepartmentRepository, IUserDepartmentService userDepartmentService) : base(repository)
        {
            _userDepartmentRepository = userDepartmentRepository;
            _userDepartmentService = userDepartmentService;
        }

        public override IPredicateGroup ListWhereFilter(SysUserViewModel model)
        {
            var predicate = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            predicate.Predicates.Add(Predicates.Field<SysUser>(f => f.IsEnabled, Operator.Eq, EnabledType.True));
            if (!string.IsNullOrWhiteSpace(model.LoginId))
            {
                predicate.Predicates.Add(Predicates.Field<SysUser>(f => f.LoginId, Operator.Like, $"%{model.LoginId}%"));
            }
            return predicate;
        }

        public override void OnEditloading(SysUserViewModel model)
        {
            var sysUserDepartment = _userDepartmentRepository.GetByCondition(Predicates.Field<SysUserDepartment>(f => f.UserId, Operator.Eq, model.Id));
            if (sysUserDepartment != null)
            {
                model.DepartmentId = sysUserDepartment.DepartmentId;
            }
        }

        public override void OnAddLoading(SysUserViewModel model)
        {
            model.DepartmentId = -1;
        }

        public override string OnAdding(SysUserViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrWhiteSpace(model.LoginId))
            {
                return "登录账号不能为空！";
            }
            if (string.IsNullOrWhiteSpace(model.LoginPassword))
            {
                return "登录密码不能为空！";
            }
            if (model.DepartmentId == -1)
            {
                return "请选择所属部门！";
            }
            return string.Empty;
        }

        public override void OnAddAfter(SysUserViewModel model, SysUser domain)
        {
            SysUserDepartment sysUserDepartment = new SysUserDepartment();

            sysUserDepartment.DepartmentId = model.DepartmentId;

            sysUserDepartment.UserId = domain.Id;

            _userDepartmentRepository.Insert(sysUserDepartment);
        }

        public override void OnEditAfter(SysUserViewModel model, SysUser domain)
        {
            var sysUserDepartment = _userDepartmentRepository.GetByCondition(Predicates.Field<SysUserDepartment>(f => f.UserId, Operator.Eq, domain.Id));
            if (sysUserDepartment != null)
            {
                sysUserDepartment.DepartmentId = model.DepartmentId;
                _userDepartmentRepository.Update(sysUserDepartment);
            }
        }
        public IActionResult GetDepartments(int departmentId)
        {
            var result = _userDepartmentService.GetDepartments(departmentId);
            return Json(result);
        }

        public override void OnDeleteAfter(string ids)
        {
            string[] deleteIds = ids.Split(',');
            foreach (var id in deleteIds)
            {
                var datas = _userDepartmentRepository.GetList(Predicates.Field<SysUserDepartment>(f => f.UserId, Operator.Eq, id));
                if (datas != null)
                {
                    foreach (var data in datas)
                    {
                        _userDepartmentRepository.Delete(data);
                    }
                }
            }
        }
    }
}
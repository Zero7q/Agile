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
        public UserController(IRepository<SysUser> repository) : base(repository)
        {

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
    }
}
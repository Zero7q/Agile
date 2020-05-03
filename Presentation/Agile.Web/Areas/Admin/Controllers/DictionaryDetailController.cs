using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Core.Domain;
using Agile.Core.Extensions;
using Agile.Data;
using Agile.Models.Domain;
using Agile.Models.Infrastructure;
using Agile.Models.ViewModels;
using Agile.Web.Framework.Controllers;
using DapperExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Agile.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 数据字典详情控制器
    /// </summary>
    [Menu(MenuType.Api, "系统管理|数据字典", "/admin/dictionarydetail/list")]
    public class DictionaryDetailController : BaseTemplateController<SysDictionaryDetail, SysDictionaryDetailViewModel>
    {
        private readonly IRepository<SysDictionaryDetail> _repository;

        public DictionaryDetailController(IRepository<SysDictionaryDetail> repository)
             : base(repository)
        {
            _repository = repository;
        }

        public override IPredicateGroup ListWhereFilter(SysDictionaryDetailViewModel model)
        {
            var predicate = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            predicate.Predicates.Add(Predicates.Field<SysDictionaryDetail>(f => f.IsEnabled, Operator.Eq, EnabledType.True));
            predicate.Predicates.Add(Predicates.Field<SysDictionaryDetail>(f => f.DictionaryId, Operator.Eq, model.DictionaryId));
            return predicate;
        }

        public override void OnAddLoading(SysDictionaryDetailViewModel model)
        {
            model.DictionaryId = Request.Query["dictionaryid"].ToString().StringToInt();
        }

        public override void OnEditloading(SysDictionaryDetailViewModel model)
        {
            model.DictionaryId = Request.Query["dictionaryid"].ToString().StringToInt();
        }

        public override string OnAdding(SysDictionaryDetailViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrWhiteSpace(model.DictionaryKey))
            {
                return "字典名称不能为空！";
            }
            if (string.IsNullOrWhiteSpace(model.DictionaryValue))
            {
                return "字典代码不能为空！";
            }
            var predicate = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            predicate.Predicates.Add(Predicates.Field<SysDictionaryDetail>(f => f.DictionaryId, Operator.Eq, model.DictionaryId));
            predicate.Predicates.Add(Predicates.Field<SysDictionaryDetail>(f => f.DictionaryKey, Operator.Eq, model.DictionaryKey));
            if (_repository.GetByCondition(predicate) != null)
            {
                return "字典名称已存在！";
            }
            return string.Empty;
        }
    }
}
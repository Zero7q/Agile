using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Core.Domain;
using Agile.Core.Infrastructure;
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
    /// 数据字典控制器
    /// </summary>
    [Menu(MenuType.Page, "系统管理|数据字典", "/admin/dictionary/list")]
    public class DictionaryController : BaseTemplateController<SysDictionary, SysDictionaryViewModel>
    {
        private readonly IRepository<SysDictionary> _dictionaryRepository;

        public DictionaryController(IRepository<SysDictionary> dictionaryRepository)
            : base(dictionaryRepository)
        {
            _dictionaryRepository = dictionaryRepository;
        }

        public override IPredicateGroup ListWhereFilter(SysDictionaryViewModel model)
        {
            var predicate = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            predicate.Predicates.Add(Predicates.Field<SysDictionary>(f => f.IsEnabled, Operator.Eq, EnabledType.True));
            if (!string.IsNullOrWhiteSpace(model.DictionaryName))
            {
                predicate.Predicates.Add(Predicates.Field<SysDictionary>(f => f.DictionaryName, Operator.Like, $"%{model.DictionaryName}%"));
            }
            return predicate;
        }

        public override string OnAdding(SysDictionaryViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrWhiteSpace(model.DictionaryName))
            {
                return "字典名称不能为空！";
            }
            if (string.IsNullOrWhiteSpace(model.DictionaryCode))
            {
                return "字典代码不能为空！";
            }
            if (_dictionaryRepository.GetByCondition(Predicates.Field<SysDictionary>(f => f.DictionaryName, Operator.Eq, model.DictionaryName)) != null)
            {
                return "字典名称已存在！";
            }
            if (_dictionaryRepository.GetByCondition(Predicates.Field<SysDictionary>(f => f.DictionaryCode, Operator.Eq, model.DictionaryCode)) != null)
            {
                return "字典代码已存在！";
            }
            return string.Empty;
        }

        public override void OnDeleteAfter(string ids)
        {
            var dictionaryDetailRepository = EngineContext.Current.Resolve<IRepository<SysDictionaryDetail>>();
            string[] deleteIds = ids.Split(',');
            foreach (var id in deleteIds)
            {
                var sysDictionaryDetails = dictionaryDetailRepository.GetList(Predicates.Field<SysDictionaryDetail>(f => f.DictionaryId, Operator.Eq, id));
                if (sysDictionaryDetails != null)
                {
                    foreach (var sysDictionaryDetail in sysDictionaryDetails)
                    {
                        dictionaryDetailRepository.Delete(sysDictionaryDetail);
                    }
                }
            }
        }
    }
}
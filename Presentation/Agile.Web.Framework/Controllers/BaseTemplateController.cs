using Agile.Core;
using Agile.Data;
using Agile.Models;
using Agile.Models.Infrastructure;
using DapperExtensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agile.Web.Framework.Controllers
{
    public class BaseTemplateController<T, K> : BaseTemplateAbstractController<T, K>
        where T : BaseEntity, new()
        where K : BaseViewModel, new()
    {
        private readonly IRepository<T> _repository;


        public BaseTemplateController(IRepository<T> repository)
        {
            _repository = repository;
        }

        [Permission("view")]
        public virtual IActionResult List()
        {
            var model = OnListLoading();
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            return View(model);
        }

        [PermissionAttribute("view")]
        public virtual IActionResult GetData(K model)
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
            int total;
            var datas = _repository.GetPage(predicate, sort, model.Page -= 1, model.Limit, out total);
            var lists = new List<K>();
            foreach (var data in datas)
            {
                lists.Add(ParseToModel(data));
            }
            return SuccessJson(lists, total);
        }

        [PermissionAttribute("add")]
        public virtual IActionResult Add(int id)
        {
            var model = new K();
            OnAddLoading(model);
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            return View(model);
        }

        [HttpPost]
        [PermissionAttribute("add")]
        public virtual IActionResult Add(K model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var message = OnAddBefore(model);
            if (!string.IsNullOrWhiteSpace(message))
            {
                return ErrorJson(message);
            }
            var domain = ParseToDomain(model);
            if (domain.CreateTime.Date.Year == 1)
            {
                domain.CreateTime = DateTime.Now;
            }
            var result = OnAdding(model);
            if (!string.IsNullOrWhiteSpace(result))
            {
                return ErrorJson(result);
            }
            _repository.Insert(domain);
            OnAddAfter(model, domain);
            return SuccessJson();
        }

        [Permission("edit")]
        public virtual IActionResult Edit(int id)
        {
            var domain = _repository.GetByCondition(Predicates.Field<T>(f => f.Id, Operator.Eq, id));
            if (domain == null)
            {
                return ErrorJson("记录不存在！");
            }
            var model = ParseToModel(domain);

            OnEditloading(model);

            return View(model);
        }

        [HttpPost]
        [Permission("edit")]
        public virtual IActionResult Edit(K model)
        {
            var domain = _repository.GetByCondition(Predicates.Field<T>(f => f.Id, Operator.Eq, model.Id));
            if (domain == null)
            {
                return ErrorJson("记录不存在！");
            }
            var info = ParseToDomain(model);
            info.UpdateTime = DateTime.Now;
            _repository.Update(info);
            OnEditAfter(model, info);
            return SuccessJson();
        }

        [HttpPost]
        [PermissionAttribute("delete")]
        public virtual IActionResult Delete(string ids)
        {
            if (string.IsNullOrWhiteSpace(ids))
            {
                return ErrorJson("参数不能为空！");
            }
            string[] deleteIds = ids.Split(',');
            foreach (var id in deleteIds)
            {
                var info = _repository.GetByCondition(Predicates.Field<T>(f => f.Id, Operator.Eq, id));
                if (info != null)
                {
                    _repository.Delete(info);
                }
            }
            OnDeleteAfter(ids);
            return SuccessJson();
        }
    }
}

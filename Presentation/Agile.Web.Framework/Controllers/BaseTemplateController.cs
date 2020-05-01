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
    public class BaseTemplateController<T, K> : BaseTemplateAbstractController<T, K>//, ITemplateController<T,K>
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
        public IActionResult GetData(K model)
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
            int page = model.Page - 1;
            int resultsPerPage = model.Limit;
            int total;
            var datas = _repository.GetPage(predicate, sort, page, resultsPerPage, out total);
            var lists = new List<K>();
            foreach (var data in datas)
            {
                lists.Add(ParseToModel(data));
            }
            return Success(lists, total);
        }

        [PermissionAttribute("add")]
        public IActionResult Add(int id)
        {
            var model = OnAddLoading();
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            return View(model);
        }

        [HttpPost]
        [PermissionAttribute("add")]
        public IActionResult Add(K model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var message = OnAddLoaded(model);
            if (!string.IsNullOrWhiteSpace(message))
            {
                return Error(message);
            }
            var domain = ParseToDomain(model);
            if (domain.CreateTime.Date.Year == 1)
            {
                domain.CreateTime = DateTime.Now;
            }
            var result = OnAdding(model);
            if (!string.IsNullOrWhiteSpace(result))
            {
                return Error(result);
            }
            _repository.Insert(domain);
            OnAdded(domain);
            return Success();
        }

        [Permission("edit")]
        public IActionResult Edit(int id)
        {
            var domain = _repository.GetByCondition(Predicates.Field<T>(f => f.Id, Operator.Eq, id));
            if (domain == null)
            {
                return Error("记录不存在！");
            }
            var model = ParseToModel(domain);

            OnEditloading(model);

            return View(model);
        }

        [HttpPost]
        [Permission("edit")]
        public IActionResult Edit(K model)
        {
            var domain = _repository.GetByCondition(Predicates.Field<T>(f => f.Id, Operator.Eq, model.Id));
            if (domain == null)
            {
                return Error("记录不存在！");
            }
            var info = ParseToDomain(model);
            info.UpdateTime = DateTime.Now;
            _repository.Update(info);
            OnEdited(info);
            return Success();
        }

        [HttpPost]
        [PermissionAttribute("delete")]
        public IActionResult Delete(string ids)
        {
            if (string.IsNullOrWhiteSpace(ids))
            {
                return Error("参数不能为空！");
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
            return Success();
        }
    }
}

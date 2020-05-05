using Agile.Core;
using Agile.Core.Domain;
using Agile.Models;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agile.Web.Framework.Controllers
{
    public abstract class BaseTemplateAbstractController<T, K> : BasePluginController
        where T : BaseEntity, new()
        where K : BaseViewModel, new()
    {
        public virtual K OnListLoading()
        {
            return new K();
        }

        public virtual void OnAddLoading(K model)
        {

        }

        public virtual string OnAddBefore(K model)
        {
            return string.Empty;
        }

        public virtual void OnDeleteAfter(string ids) { }

        public virtual string OnAdding(K model)
        {
            return string.Empty;
        }

        public virtual void OnAddAfter(K model, T domain)
        {

        }

        public virtual void OnEditloading(K model)
        {

        }
        public virtual void OnEditAfter(K model,T domain)
        {

        }

        public virtual IPredicateGroup ListWhereFilter(K model)
        {
            var predicate = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            predicate.Predicates.Add(Predicates.Field<T>(f => f.IsEnabled, Operator.Eq, EnabledType.True));
            return predicate;
        }

        public virtual IList<ISort> ListSortFilter(K model)
        {
            var sort = new List<ISort>();
            sort.Add(new Sort { PropertyName = "id", Ascending = false });
            return sort;
        }

        public virtual T ParseToDomain(K model)
        {
            return (T)Parse(model, new T());
        }

        public virtual K ParseToModel(T info)
        {
            return (K)Parse(info, new K());
        }
    }
}

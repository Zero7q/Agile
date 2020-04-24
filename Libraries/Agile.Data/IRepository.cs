using Agile.Core;
using DapperExtensions;
using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Agile.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        bool HasActiveTransaction { get; }
        IDbConnection Connection { get; }
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void Commit();
        void Rollback();
        void RunInTransaction(Action action);
        TEntity RunInTransaction(Func<TEntity> func);
        TEntity Get(dynamic id, IDbTransaction transaction, int? commandTimeout = null) ;
        TEntity Get(dynamic id, int? commandTimeout = null) ;
        void Insert(IEnumerable<TEntity> entities, IDbTransaction transaction, int? commandTimeout = null);
        void Insert(IEnumerable<TEntity> entities, int? commandTimeout = null) ;
        dynamic Insert(TEntity entity, IDbTransaction transaction, int? commandTimeout = null) ;
        dynamic Insert(TEntity entity, int? commandTimeout = null) ;
        bool Update(TEntity entity, IDbTransaction transaction, int? commandTimeout = null, bool ignoreAllKeyProperties = false) ;
        bool Update(TEntity entity, int? commandTimeout = null, bool ignoreAllKeyProperties = false) ;
        bool Delete(TEntity entity, IDbTransaction transaction, int? commandTimeout = null) ;
        bool Delete(TEntity entity, int? commandTimeout = null) ;
        bool Delete(object predicate, IDbTransaction transaction, int? commandTimeout = null) ;
        bool Delete(object predicate, int? commandTimeout = null) ;
        IEnumerable<TEntity> GetList(object predicate, IList<ISort> sort, IDbTransaction transaction, int? commandTimeout = null, bool buffered = true) ;
        IEnumerable<TEntity> GetList(object predicate = null, IList<ISort> sort = null, int? commandTimeout = null, bool buffered = true) ;
        IEnumerable<TEntity> GetPage(object predicate, IList<ISort> sort, int page, int resultsPerPage, IDbTransaction transaction, int? commandTimeout = null, bool buffered = true) ;
        IEnumerable<TEntity> GetPage(object predicate, IList<ISort> sort, int page, int resultsPerPage, int? commandTimeout = null, bool buffered = true) ;
        IEnumerable<TEntity> GetSet(object predicate, IList<ISort> sort, int firstResult, int maxResults, IDbTransaction transaction, int? commandTimeout, bool buffered) ;
        IEnumerable<TEntity> GetSet(object predicate, IList<ISort> sort, int firstResult, int maxResults, int? commandTimeout, bool buffered) ;
        int Count(object predicate, IDbTransaction transaction, int? commandTimeout = null) ;
        int Count(object predicate, int? commandTimeout = null) ;
        IMultipleResultReader GetMultiple(GetMultiplePredicate predicate, IDbTransaction transaction, int? commandTimeout = null);
        IMultipleResultReader GetMultiple(GetMultiplePredicate predicate, int? commandTimeout = null);
        void ClearCache();
        Guid GetNextGuid();
        IClassMapper GetMap() ;

        IEnumerable<T> ExecuteSql<T>(string sql);
    }
}

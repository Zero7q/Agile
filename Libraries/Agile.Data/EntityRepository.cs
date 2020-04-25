using Agile.Core;
using Agile.Core.Extensions;
using Dapper;
using DapperExtensions;
using DapperExtensions.Mapper;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Agile.Data
{
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private IDatabase _database;

        private readonly IDataProviderManager _dataProviderManager;

        public EntityRepository(IDataProviderManager dataProviderManager)
        {
            _dataProviderManager = dataProviderManager;
        }

        public IDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    Type type = typeof(TEntity);
                    if (!type.IsDefined(typeof(DataBaseProviderAttrobute), false))
                    {
                        throw new Exception("数据库类型配置未定义！");
                    }
                    Attribute attribute = Attribute.GetCustomAttribute(type, typeof(DataBaseProviderAttrobute), false);
                    if (attribute == null)
                    {
                        throw new AgileException("数据库类型配置获取失败！");
                    }
                    DataBaseProviderAttrobute dataBaseAttrobute = (DataBaseProviderAttrobute)attribute;
                    if (dataBaseAttrobute == null)
                    {
                        throw new Exception("数据库类型配置获取失败！");
                    }
                    _database = _dataProviderManager.AgileDataProvider(dataBaseAttrobute.DataProviderType).CreateConnection();
                }
                return _database;
            }
        }

        public bool HasActiveTransaction { get { return Database.HasActiveTransaction; } }

        public IDbConnection Connection { get { return Database.Connection; } }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            Database.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            Database.Commit();
        }

        public void Rollback()
        {
            Database.Rollback();
        }

        public void RunInTransaction(Action action)
        {
            Database.RunInTransaction(action);
        }

        public TEntity RunInTransaction(Func<TEntity> func)
        {
            return Database.RunInTransaction(func);
        }


        public T RunInTransaction<T>(Func<T> func)
        {
            return Database.RunInTransaction<T>(func);
        }

        public TEntity Get(dynamic id, IDbTransaction transaction, int? commandTimeout = null)
        {
            return Database.Get(id, transaction, commandTimeout);
        }

        public TEntity Get(dynamic id, int? commandTimeout = null)
        {
            return Database.Get(id, commandTimeout);
        }

        public TEntity GetByCondition(object predicate, IDbTransaction transaction, int? commandTimeout = null)
        {
            return Database.GetList<TEntity>(predicate, null, transaction, commandTimeout).FirstOrDefault();
        }

        public TEntity GetByCondition(object predicate, int? commandTimeout = null)
        {
            return Database.GetList<TEntity>(predicate, null, commandTimeout).FirstOrDefault();
        }
        public void Insert(IEnumerable<TEntity> entities, IDbTransaction transaction, int? commandTimeout = null)
        {
            Database.Insert(entities, transaction, commandTimeout);
        }

        public void Insert(IEnumerable<TEntity> entities, int? commandTimeout = null)
        {
            Database.Insert(entities, commandTimeout);
        }

        public dynamic Insert(TEntity entity, IDbTransaction transaction, int? commandTimeout = null)
        {
            Database.Insert(entity, transaction, commandTimeout);
            return entity;
        }

        public dynamic Insert(TEntity entity, int? commandTimeout = null)
        {
            Database.Insert(entity, commandTimeout);
            return entity;
        }

        public bool Update(TEntity entity, IDbTransaction transaction, int? commandTimeout = null, bool ignoreAllKeyProperties = false)
        {
            return Database.Update(entity, transaction, commandTimeout, ignoreAllKeyProperties);
        }

        public bool Update(TEntity entity, int? commandTimeout = null, bool ignoreAllKeyProperties = false)
        {
            return Database.Update(entity, commandTimeout, ignoreAllKeyProperties);
        }

        public bool Delete(TEntity entity, IDbTransaction transaction, int? commandTimeout = null)
        {
            return Database.Delete(entity, transaction, commandTimeout);
        }

        public bool Delete(TEntity entity, int? commandTimeout = null)
        {
            return Database.Delete(entity, commandTimeout);
        }

        public bool Delete(object predicate, IDbTransaction transaction, int? commandTimeout = null)
        {
            return Database.Delete(predicate, transaction, commandTimeout);
        }

        public bool Delete(object predicate, int? commandTimeout = null)
        {
            return Database.Delete(predicate, commandTimeout);
        }

        public IEnumerable<TEntity> GetList(object predicate, IList<ISort> sort, IDbTransaction transaction, int? commandTimeout = null, bool buffered = true)
        {
            return Database.GetList<TEntity>(predicate, sort, transaction, commandTimeout, buffered);
        }

        public IEnumerable<TEntity> GetList(object predicate = null, IList<ISort> sort = null, int? commandTimeout = null, bool buffered = true)
        {
            return Database.GetList<TEntity>(predicate, sort, commandTimeout, buffered);
        }

        public IEnumerable<TEntity> GetPage(object predicate, IList<ISort> sort, int page, int resultsPerPage, IDbTransaction transaction, int? commandTimeout = null, bool buffered = true)
        {
            return Database.GetPage<TEntity>(predicate, sort, page, resultsPerPage, transaction, commandTimeout, buffered);
        }

        public IEnumerable<TEntity> GetPage(object predicate, IList<ISort> sort, int page, int resultsPerPage, int? commandTimeout = null, bool buffered = true)
        {
            return Database.GetPage<TEntity>(predicate, sort, page, resultsPerPage, commandTimeout, buffered);
        }

        public int Count(object predicate, IDbTransaction transaction, int? commandTimeout = null)
        {
            return Database.Count<TEntity>(predicate, transaction, commandTimeout);
        }

        public int Count(object predicate, int? commandTimeout = null)
        {
            return Database.Count<TEntity>(predicate, commandTimeout);
        }
        public void ClearCache()
        {
            Database.ClearCache();
        }

        public Guid GetNextGuid()
        {
            return Database.GetNextGuid();
        }

        public IClassMapper GetMap()
        {
            return Database.GetMap<TEntity>();
        }

        public void Dispose()
        {
            if (_database != null)
            {
                _database.Dispose();
                _database = null;
            }
        }

        public IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Database.Connection.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
        }
    }
}

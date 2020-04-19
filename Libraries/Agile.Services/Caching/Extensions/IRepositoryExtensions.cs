using Agile.Core;
using Agile.Core.Caching;
using Agile.Core.Infrastructure;
using Agile.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Services.Caching.Extensions
{
    public static class IRepositoryExtensions
    {
        public static TEntity ToCachedGetById<TEntity>(this IRepository<TEntity> repository, object id) where TEntity : BaseEntity
        {
            var cacheManager = EngineContext.Current.Resolve<IStaticCacheManager>();

            return cacheManager.Get(new CacheKey(BaseEntity.GetEntityCacheKey(typeof(TEntity), id)), () => repository.GetById(id));
        }
    }
}

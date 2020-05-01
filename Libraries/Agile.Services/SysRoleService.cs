using Agile.Data;
using Agile.Models.Domain;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agile.Services
{
    public class SysRoleService : ISysRoleService
    {
        private readonly IRepository<SysRole> _repository;
        public SysRoleService(IRepository<SysRole> repository)
        {
            _repository = repository;
        }

        public bool Delete(SysRole entity)
        {
            return _repository.Delete(entity);
        }

        public SysRole GetByCondition(object predicate)
        {
            return _repository.GetByCondition(predicate);
        }

        public List<SysRole> GetList(object predicate = null, IList<ISort> sort = null)
        {
            return _repository.GetList(predicate, sort).ToList();
        }

        public List<SysRole> GetPage(object predicate, IList<ISort> sort, int page, int resultsPerPage, out int total)
        {
            return _repository.GetPage(predicate, sort, page, resultsPerPage, out total).ToList();
        }

        public void Insert(IEnumerable<SysRole> entities)
        {
            _repository.Insert(entities);
        }

        public SysRole Insert(SysRole entity)
        {
            return this._repository.Insert(entity);
        }

        public bool Update(SysRole entity)
        {
            return _repository.Update(entity);
        }
    }
}

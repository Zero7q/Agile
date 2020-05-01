using Agile.Models.Domain;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Services
{
    public interface ISysRoleService
    {
        void Insert(IEnumerable<SysRole> entities);

        SysRole Insert(SysRole entity);

        bool Delete(SysRole entity);

        SysRole GetByCondition(object predicate);

        bool Update(SysRole entity);

        List<SysRole> GetList(object predicate = null, IList<ISort> sort = null);

        List<SysRole> GetPage(object predicate, IList<ISort> sort, int page, int resultsPerPage, out int total);
    }
}

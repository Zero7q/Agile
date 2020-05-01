using Agile.Models.Domain;
using Agile.Models.ViewModels;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Services
{
    public interface ISysDepartmentService
    {
        void Insert(IEnumerable<SysDepartment> entities);

        SysDepartment Insert(SysDepartment entity);

        bool Delete(object predicate);

        SysDepartment GetByCondition(object predicate);

        bool Update(SysDepartment entity);

        List<SysDepartment> GetList(object predicate = null, IList<ISort> sort = null);

        List<SysDepartment> GetPage(object predicate, IList<ISort> sort, int page, int resultsPerPage, out int total);

        List<SysDepartmentViewModel> GetTreeData();
    }
}

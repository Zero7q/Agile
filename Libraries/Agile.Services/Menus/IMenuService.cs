using Agile.Models.Domain;
using Agile.Models.ViewModels;
using DapperExtensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Services.Menus
{
    public interface IMenuService
    {
        void Insert(IEnumerable<SysMenu> entities);

        SysMenu Insert(SysMenu entity);

        bool Delete(object predicate);

        SysMenu GetByCondition(object predicate);

        bool Update(SysMenu entity);

        IEnumerable<SysMenu> GetList(object predicate = null, IList<ISort> sort = null);

        IEnumerable<SysMenu> GetPage(object predicate, IList<ISort> sort, int page, int resultsPerPage, out int total);

        List<SysMenuViewModel> GetMenus();

        IEnumerable<SelectListItem> ParentSelectItems();

        List<SysMenuViewModel> GetTreeMenus();
    }
}

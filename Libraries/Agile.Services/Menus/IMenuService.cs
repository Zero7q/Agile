using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Services.Menus
{
    public interface IMenuService
    {
        void Insert(IEnumerable<Menu> entities);

        Menu Insert(Menu entity);

        bool Delete(object predicate);

        Menu GetByCondition(object predicate);

        bool Update(Menu entity);

        IEnumerable<Menu> GetList(object predicate = null, IList<ISort> sort = null);

        IEnumerable<Menu> GetPage(object predicate, IList<ISort> sort, int page, int resultsPerPage);
        List<MenuViewModel> GetMenus();
    }
}

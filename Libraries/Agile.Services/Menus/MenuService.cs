using Agile.Data;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Services.Menus
{
    public class MenuService : IMenuService
    {
        private readonly IRepository<Menu> _repository;
        public MenuService(IRepository<Menu> repository)
        {
            _repository = repository;
        }

        public bool Delete(object predicate)
        {
            return _repository.Delete(predicate);
        }

        public Menu GetByCondition(object predicate)
        {
            return _repository.GetByCondition(predicate);
        }

        public IEnumerable<Menu> GetList(object predicate = null, IList<ISort> sort = null)
        {
            return _repository.GetList(predicate, sort);
        }

        public IEnumerable<Menu> GetPage(object predicate, IList<ISort> sort, int page, int resultsPerPage)
        {
            return _repository.GetPage(predicate, sort, page, resultsPerPage);
        }

        public void Insert(IEnumerable<Menu> entities)
        {
            _repository.Insert(entities);
        }

        public Menu Insert(Menu entity)
        {
            return this._repository.Insert(entity);
        }

        public bool Update(Menu entity)
        {
            return _repository.Update(entity);
        }

        public List<MenuViewModel> GetMenus()
        {
            List<MenuViewModel> menuViewModel = new List<MenuViewModel>();
            var parentMenus = GetList(Predicates.Field<Menu>(f => f.ParentId, Operator.Eq, -1));
            if (parentMenus != null)
            {
                foreach (var menu in parentMenus)
                {
                    MenuViewModel menuViewModelItem = new MenuViewModel();
                    menuViewModelItem.Name = menu.Name;
                    menuViewModelItem.Icon = menu.Icon;
                    menuViewModelItem.Url = menu.Url;
                    menuViewModel.Add(menuViewModelItem);

                    GetChildMenus(menu.Id, menuViewModelItem);
                }
            }
            return menuViewModel;
        }

        private void GetChildMenus(int parentId, MenuViewModel menuViewModelItem)
        {
            var childMenus = GetList(Predicates.Field<Menu>(f => f.ParentId, Operator.Eq, parentId));
            if (childMenus != null)
            {
                foreach (var childMenu in childMenus)
                {
                    MenuViewModel childMenuViewModelItem = new MenuViewModel();
                    childMenuViewModelItem.Name = childMenu.Name;
                    childMenuViewModelItem.Icon = childMenu.Icon;
                    childMenuViewModelItem.Url = childMenu.Url;
                    menuViewModelItem.SubMenus = new List<MenuViewModel>();
                    menuViewModelItem.SubMenus.Add(childMenuViewModelItem);

                    GetChildMenus(childMenu.Id, childMenuViewModelItem);
                }
            }
        }
    }
}

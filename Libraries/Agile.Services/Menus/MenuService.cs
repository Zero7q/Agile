using Agile.Data;
using Agile.Models.Menus.Domain;
using Agile.Models.Menus.ViewModel;
using DapperExtensions;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var menuViewModel = new List<MenuViewModel>();
            var parentMenus = GetList(Predicates.Field<Menu>(f => f.ParentId, Operator.Eq, -1));
            if (parentMenus != null)
            {
                foreach (var menu in parentMenus)
                {
                    MenuViewModel menuViewModelItem = new MenuViewModel();
                    menuViewModelItem.Name = menu.Name;
                    menuViewModelItem.Icon = menu.Icon;
                    menuViewModelItem.OpenUrl = menu.OpenUrl;
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
                    childMenuViewModelItem.OpenUrl = childMenu.OpenUrl;
                    if (menuViewModelItem.SubMenus == null)
                    {
                        menuViewModelItem.SubMenus = new List<MenuViewModel>();
                    }
                    menuViewModelItem.SubMenus.Add(childMenuViewModelItem);
                    GetChildMenus(childMenu.Id, childMenuViewModelItem);
                }
            }
        }

        public IEnumerable<SelectListItem> ParentSelectItems()
        {
            var selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Value = "-1", Text = "请选择上级菜单" });
            var menus = GetList(Predicates.Field<Menu>(f => f.ParentId, Operator.Eq, -1));
            if (menus != null)
            {
                foreach (var menu in menus)
                {
                    selectListItems.Add(new SelectListItem() { Value = menu.Id.ToString(), Text = menu.Name });
                }
            }
            return selectListItems;
        }

        public List<MenuViewModel> GetTreeMenus()
        {
            var menuViewModel = new List<MenuViewModel>();
            var parentMenus = GetList();
            if (parentMenus != null)
            {
                foreach (var menu in parentMenus)
                {
                    MenuViewModel menuViewModelItem = new MenuViewModel();
                    menuViewModelItem.Name = menu.Name;
                    menuViewModelItem.Icon = menu.Icon;
                    menuViewModelItem.OpenUrl = menu.OpenUrl;
                    menuViewModelItem.ParentId = menu.ParentId;
                    menuViewModel.Add(menuViewModelItem);
                }
            }
            return menuViewModel;
        }
    }
}

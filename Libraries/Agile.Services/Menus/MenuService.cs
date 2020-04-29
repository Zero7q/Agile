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
        private readonly IRepository<SysMenu> _repository;
        public MenuService(IRepository<SysMenu> repository)
        {
            _repository = repository;
        }

        public bool Delete(object predicate)
        {
            return _repository.Delete(predicate);
        }

        public SysMenu GetByCondition(object predicate)
        {
            return _repository.GetByCondition(predicate);
        }

        public IEnumerable<SysMenu> GetList(object predicate = null, IList<ISort> sort = null)
        {
            return _repository.GetList(predicate, sort);
        }

        public IEnumerable<SysMenu> GetPage(object predicate, IList<ISort> sort, int page, int resultsPerPage)
        {
            return _repository.GetPage(predicate, sort, page, resultsPerPage);
        }

        public void Insert(IEnumerable<SysMenu> entities)
        {
            _repository.Insert(entities);
        }

        public SysMenu Insert(SysMenu entity)
        {
            return this._repository.Insert(entity);
        }

        public bool Update(SysMenu entity)
        {
            return _repository.Update(entity);
        }

        public List<SysMenuViewModel> GetMenus()
        {
            var menuViewModel = new List<SysMenuViewModel>();
            var parentMenus = GetList(Predicates.Field<SysMenu>(f => f.ParentId, Operator.Eq, -1));
            if (parentMenus != null)
            {
                foreach (var menu in parentMenus)
                {
                    SysMenuViewModel menuViewModelItem = new SysMenuViewModel();
                    menuViewModelItem.Name = menu.Name;
                    menuViewModelItem.Icon = menu.Icon;
                    menuViewModelItem.Url = menu.OpenUrl;
                    menuViewModel.Add(menuViewModelItem);

                    GetChildMenus(menu.Id, menuViewModelItem);
                }
            }
            return menuViewModel;
        }

        private void GetChildMenus(int parentId, SysMenuViewModel menuViewModelItem)
        {
            var childMenus = GetList(Predicates.Field<SysMenu>(f => f.ParentId, Operator.Eq, parentId));
            if (childMenus != null)
            {
                foreach (var childMenu in childMenus)
                {
                    SysMenuViewModel childMenuViewModelItem = new SysMenuViewModel();
                    childMenuViewModelItem.Name = childMenu.Name;
                    childMenuViewModelItem.Icon = childMenu.Icon;
                    childMenuViewModelItem.Url = childMenu.OpenUrl;
                    if (menuViewModelItem.SubMenus == null)
                    {
                        menuViewModelItem.SubMenus = new List<SysMenuViewModel>();
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
            var menus = GetList(Predicates.Field<SysMenu>(f => f.ParentId, Operator.Eq, -1));
            if (menus != null)
            {
                foreach (var menu in menus)
                {
                    selectListItems.Add(new SelectListItem() { Value = menu.Id.ToString(), Text = menu.Name });
                }
            }
            return selectListItems;
        }

        public List<SysMenuViewModel> GetTreeMenus()
        {
            var menuViewModel = new List<SysMenuViewModel>();
            var parentMenus = GetList();
            if (parentMenus != null)
            {
                foreach (var menu in parentMenus)
                {
                    SysMenuViewModel menuViewModelItem = new SysMenuViewModel();
                    menuViewModelItem.Id = menu.Id;
                    menuViewModelItem.Name = menu.Name;
                    menuViewModelItem.Icon = menu.Icon;
                    menuViewModelItem.Url = menu.OpenUrl;
                    menuViewModelItem.ParentId = menu.ParentId;
                    menuViewModelItem.Open = true;
                    menuViewModel.Add(menuViewModelItem);
                }
            }
            return menuViewModel;
        }
    }
}

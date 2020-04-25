using Agile.Core.Infrastructure;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agile.Services.Menus
{
    public class MenuParseService : IMenuParseService
    {
        private readonly ITypeFinder _typeFinder;
        private readonly IMenuService _menuService;

        public MenuParseService(ITypeFinder typeFinder, IMenuService menuService)
        {
            _typeFinder = typeFinder;
            _menuService = menuService;
        }

        public void InitializeMenus()
        {
            var assemblies = ((WebAppTypeFinder)_typeFinder).GetAssemblies();
            if (assemblies == null)
            {
                throw new ArgumentNullException(nameof(assemblies));
            }
            var allAssemblyTypes = assemblies.Select(assembly => assembly.GetTypes());
            foreach (var assemblyTypes in allAssemblyTypes)
            {
                foreach (var assemblyType in assemblyTypes)
                {
                    if (assemblyType.IsDefined(typeof(MenuAttribute), false))
                    {
                        var attribute = Attribute.GetCustomAttribute(assemblyType, typeof(MenuAttribute), false);
                        if (attribute != null)
                        {
                            var menuAttribute = (MenuAttribute)attribute;
                            if (menuAttribute != null)
                            {
                                Menu parentMenu = null;
                                var menusItems = menuAttribute.Name.Split('|');
                                for (int i = 0; i < menusItems.Length; i++)
                                {
                                    bool isLastNode = i == menusItems.Length - 1 ? true : false;
                                    string menu = menusItems[i];
                                    string node = (menu + i).ToString();
                                    var predicate = Predicates.Field<Menu>(f => f.Node, Operator.Eq, node);
                                    var menuModel = _menuService.GetByCondition(predicate);
                                    if (menuModel != null)
                                    {
                                        parentMenu = menuModel;
                                    }
                                    else
                                    {
                                        var menuItem = new Menu();
                                        menuItem.ParentId = parentMenu == null ? -1 : parentMenu.Id;
                                        menuItem.Node = node;
                                        menuItem.Name = menu;
                                        menuItem.Icon = menuAttribute.Icon;
                                        menuItem.Url = isLastNode == true ? menuAttribute.Url : "javascript:;";
                                        menuItem.CreateTime = DateTime.Now;
                                        menuItem.IsEnabled = Core.Domain.EnabledType.True;
                                        _menuService.Insert(menuItem);
                                        parentMenu = menuItem;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

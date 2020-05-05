using Agile.Data;
using Agile.Models.Domain;
using Agile.Models.ViewModels;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Services
{
    public class UserDepartmentService : IUserDepartmentService
    {
        private readonly IRepository<SysDepartment> _repository;
        public UserDepartmentService(IRepository<SysDepartment> repository)
        {
            _repository = repository;
        }

        public List<SysDepartmentSelectTreeViewModel> GetDepartments(int departmentId)
        {
            List<SysDepartmentSelectTreeViewModel> sysDepartmentSelectTreeViewModels = new List<SysDepartmentSelectTreeViewModel>();
            var datas = _repository.GetList(Predicates.Field<SysDepartment>(f => f.ParentId, Operator.Eq, -1));

            if (datas != null)
            {
                foreach (var item in datas)
                {
                    SysDepartmentSelectTreeViewModel sysDepartmentSelectTreeViewModel = new SysDepartmentSelectTreeViewModel();
                    sysDepartmentSelectTreeViewModel.Name = item.DepartmentName;
                    sysDepartmentSelectTreeViewModel.Value = item.Id;
                    sysDepartmentSelectTreeViewModel.Selected = false;
                    sysDepartmentSelectTreeViewModel.Disabled = true;
                    sysDepartmentSelectTreeViewModels.Add(sysDepartmentSelectTreeViewModel);
                    GetChildDepartment(sysDepartmentSelectTreeViewModel.Value, departmentId, sysDepartmentSelectTreeViewModel);
                }
            }
            return sysDepartmentSelectTreeViewModels;
        }

        private void GetChildDepartment(int parentId, int departmentId, SysDepartmentSelectTreeViewModel Childrens)
        {
            var childMenus = _repository.GetList(Predicates.Field<SysDepartment>(f => f.ParentId, Operator.Eq, parentId));
            if (childMenus != null)
            {
                foreach (var childMenu in childMenus)
                {
                    SysDepartmentSelectTreeViewModel sysDepartmentSelectTreeViewModel = new SysDepartmentSelectTreeViewModel();
                    sysDepartmentSelectTreeViewModel.Name = childMenu.DepartmentName;
                    sysDepartmentSelectTreeViewModel.Value = childMenu.Id;
                    sysDepartmentSelectTreeViewModel.Selected = childMenu.Id == departmentId ? true : false;
                    sysDepartmentSelectTreeViewModel.Disabled = false;
                    if (Childrens.Children == null)
                    {
                        Childrens.Children = new List<SysDepartmentSelectTreeViewModel>();
                    }
                    Childrens.Children.Add(sysDepartmentSelectTreeViewModel);
                    GetChildDepartment(childMenu.Id, departmentId, sysDepartmentSelectTreeViewModel);
                }
            }
        }
    }
}

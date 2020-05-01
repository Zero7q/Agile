using Agile.Data;
using Agile.Models.Domain;
using Agile.Models.ViewModels;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agile.Services
{
    public class SysDepartmentService : ISysDepartmentService
    {
        private readonly IRepository<SysDepartment> _repository;
        public SysDepartmentService(IRepository<SysDepartment> repository)
        {
            _repository = repository;
        }

        public bool Delete(object predicate)
        {
            return _repository.Delete(predicate);
        }

        public SysDepartment GetByCondition(object predicate)
        {
            return _repository.GetByCondition(predicate);
        }

        public List<SysDepartment> GetList(object predicate = null, IList<ISort> sort = null)
        {
            return _repository.GetList(predicate, sort).ToList();
        }

        public List<SysDepartment> GetPage(object predicate, IList<ISort> sort, int page, int resultsPerPage, out int total)
        {
            return _repository.GetPage(predicate, sort, page, resultsPerPage, out total).ToList();
        }

        public void Insert(IEnumerable<SysDepartment> entities)
        {
            _repository.Insert(entities);
        }

        public SysDepartment Insert(SysDepartment entity)
        {
            return this._repository.Insert(entity);
        }

        public bool Update(SysDepartment entity)
        {
            return _repository.Update(entity);
        }

        public List<SysDepartmentViewModel> GetTreeData()
        {
            var sysDepartments = new List<SysDepartmentViewModel>();
            var departments = GetList();
            foreach (var sysDepartment in departments)
            {
                sysDepartments.Add(new SysDepartmentViewModel()
                {
                    Id = sysDepartment.Id,
                    ParentId = sysDepartment.ParentId,
                    DepartmentName = sysDepartment.DepartmentName
                });
            }
            return sysDepartments;
        }
    }
}

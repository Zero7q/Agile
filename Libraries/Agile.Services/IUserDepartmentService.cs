using Agile.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Services
{
    public interface IUserDepartmentService
    {
        List<SysDepartmentSelectTreeViewModel> GetDepartments(int departmentId);
    }
}

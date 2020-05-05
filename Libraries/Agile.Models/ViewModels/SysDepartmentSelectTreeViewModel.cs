using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.ViewModels
{
    public class SysDepartmentSelectTreeViewModel
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public bool Selected { get; set; }
        public bool Disabled { get; set; }
        public List<SysDepartmentSelectTreeViewModel> Children { get; set; }
    }
}

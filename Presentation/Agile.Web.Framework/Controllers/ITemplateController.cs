using Agile.Core;
using Agile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Web.Framework.Controllers
{
    public interface ITemplateController<T, K>
        where T : BaseEntity, new()
        where K : BaseViewModel, new()
    {
        K OnListLoading();
    }
}

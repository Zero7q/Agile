using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agile.Web.Framework.Controllers
{
    [Area(AreaNames.Admin)]
    public abstract class BasePluginController : BaseController
    {
        public virtual object Parse(object souce, object target)
        {
            var souceProperties = souce.GetType().GetProperties();
            var targetProperties = target.GetType().GetProperties();
            foreach (var sourcePropertyInfo in souceProperties)
            {
                var targetPropertyInfo = targetProperties.ToList().FirstOrDefault(s => s.Name.Equals(sourcePropertyInfo.Name));
                if (targetPropertyInfo != null && targetPropertyInfo.PropertyType == sourcePropertyInfo.PropertyType)
                {
                    targetPropertyInfo.SetValue(target, sourcePropertyInfo.GetValue(souce));
                }
            }
            return target;
        }
    }
}

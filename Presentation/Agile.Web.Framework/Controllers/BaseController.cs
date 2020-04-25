using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Web.Framework.Controllers
{
    public abstract class BaseController : Controller
    {
        public IActionResult Success(object data)
        {
            var result = new
            {
                Code = 200,
                Msg = "成功",
                Data = data
            };
            return Json(result);
        }
    }
}

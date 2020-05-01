using Agile.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Web.Framework.Controllers
{
    public abstract class BaseController : Controller
    {
        public IActionResult Success(object datas, int total)
        {
            var result = new
            {
                code = 0,
                msg = "成功",
                count = total,
                data = datas
            };
            return Json(result);
        }

        public IActionResult Success(object datas)
        {
            var result = new
            {
                code = 0,
                msg = "成功",
                data = datas
            };
            return Json(result);
        }

        public IActionResult Success(string message = "成功")
        {
            var result = new
            {
                code = 0,
                msg = message
            };
            return Json(result);
        }

        public IActionResult Error(string message = "失败")
        {
            var result = new
            {
                code = 1,
                msg = message
            };
            return Json(result);
        }
    }
}

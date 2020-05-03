using Agile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Agile.Web.Framework.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult SuccessJson(object datas, int total)
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

        public IActionResult SuccessJson(object datas)
        {
            var result = new
            {
                code = 0,
                msg = "成功",
                data = datas
            };
            return Json(result);
        }

        public IActionResult SuccessJson(string message = "成功")
        {
            var result = new
            {
                code = 0,
                msg = message
            };
            return Json(result);
        }

        public IActionResult ErrorJson(string message = "失败")
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace helloWorlld.Controllers
{
    public abstract class baseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers.ContainsKey("User-Agent") &&
                Regex.IsMatch(context.HttpContext.Request.Headers["User-Agent"], @"Trident/7.*rv:11"))
            {
                context.Result = Content("Internet Explorer запрещён!!!");
            }
            base.OnActionExecuting(context);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System.Text;

namespace helloWorlld.Controllers
{
    public class HomeController : baseController
    {

        private IConfiguration _configuration;

        // Q : что передаётся в метод контроллера? варианты определения? Нужно ли для этого добавлять службу в качестве синглтона?(нет)
        public HomeController(IConfiguration Configuration) {
            _configuration = Configuration;
        }

        public IActionResult Index()
        {
            if (!String.IsNullOrEmpty(HttpContext.Request.Cookies["who"]))
                ViewData["who"] = HttpContext.Request.Cookies["who"];
            else
                ViewData["who"] = "добрый человек";

            ViewData["CompanyName"] = _configuration.GetSection("CompanyName");
            return View();
        }

        public string Index2(int id, int id2)
        {
            return $"Your value is {id} and {id2}";
        }

        //[ActionName("anotherName")]
        [HttpPost]
        public IActionResult Save(string who, string what) {
            ViewData["who"] = who;
            ViewData["what"] = what;

            HttpContext.Response.Cookies.Append("who", who);

            return View();
        }

        public VirtualFileResult GetCat() {
            var filepath = Path.Combine("~/Images", "cat.jpg");
            return File(filepath,"image/jpeg");
        }

        public ContentResult getCompanyName() {
            // var res = new IActionResult();
            //var HttpResponse Response = HttpContext.Current.Response;
            //HttpContext.Response.ContentType = "text/html; charset=utf-8";

            // TODO : fix encoding
            return Content(_configuration["CompanyName"], "text/html", Encoding.UTF8);

            //return 
        }
    }
}

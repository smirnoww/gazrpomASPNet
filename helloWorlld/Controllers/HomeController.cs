using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace helloWorlld.Controllers
{
    public class HomeController : baseController
    {

        private IConfiguration _configuration;

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

        public string getCompanyName() {
            return _configuration["CompanyName"];
        }
    }
}

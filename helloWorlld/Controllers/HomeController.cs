using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using helloWorlld.Classes;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

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
            try
            {
                string cnStr = @"Data Source=wsclass05stud08;Initial Catalog=DB013;Integrated Security=True";
                SqlConnection cn = new SqlConnection(cnStr);
                cn.Open();
            }
            catch (Exception e)
            {
                ViewData["MessageType"] = "Критичная ошибка";
                ViewData["MessageText"] = "Ошибка подключения к БД";
                ViewData["MessageTechDetails"] = e.Message;
                return View("Message");
            }

            if (!String.IsNullOrEmpty(HttpContext.Request.Cookies["who"]))
                ViewData["who"] = HttpContext.Request.Cookies["who"];
            else
                ViewData["who"] = "добрый человек";

                //ViewBag.jobs = new SelectList("пахать", "копать");

            //  ViewData["CompanyName"] = Win1251ToUTF8(_configuration.GetSection("CompanyName").Value);
            ViewData["CompanyName"] = _configuration.GetSection("CompanyName").Value;
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

            var model = new Assignment(who,what);

            return View(model);
        }

        public VirtualFileResult GetCat() {
            var filepath = Path.Combine("~/Images", "cat.jpg");
            return File(filepath, "image/jpeg");
        }

        public string getCompanyName() {
            // var res = new IActionResult();
            //var HttpResponse Response = HttpContext.Current.Response;
            //HttpContext.Response.ContentType = "text/html; charset=utf-8";
            Response.Headers["Content-Type"] = "charset=utf-8";
            // TODO : fix encoding
            // return Content(_configuration["CompanyName"], "text/html", Encoding.UTF8);

            return _configuration["CompanyName"];
        }

        static private string Win1251ToUTF8(string source)
        {
            /*
            Encoding utf8 = Encoding.GetEncoding("utf-8");
            Encoding win1251 = Encoding.GetEncoding("win-1251");
            byte[] utf8Bytes = win1251.GetBytes(source);
            byte[] win1251Bytes = Encoding.Convert(win1251, utf8, utf8Bytes);
            source = win1251.GetString(win1251Bytes);
            */
            Encoding win1251 = Encoding.GetEncoding(1251);
            Encoding utf8 = Encoding.UTF8;
            byte[] win1251Bytes = win1251.GetBytes(source);
            byte[] utf8Bytes = Encoding.Convert(win1251, utf8, win1251Bytes);
            string utf8String = Encoding.UTF8.GetString(utf8Bytes);

            return source;
        }
    }

  

}

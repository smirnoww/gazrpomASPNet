using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Views.Models;

namespace Views.Controllers
{

    // TODO : check "TempData is used to pass data between two consecutive requests."

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                TimeSpan start = new TimeSpan(0, 0, 0); //0 o'clock
                TimeSpan end = new TimeSpan(12, 0, 0); //12 o'clock
                TimeSpan now = DateTime.Now.TimeOfDay;

                if (((now > start) && (now < end)))
                {
                    return View("Morning");
                }
                else
                {
                    return View("Evening");
                }
            }
            catch
            {
                return View();
            }
        }

        public IActionResult good()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

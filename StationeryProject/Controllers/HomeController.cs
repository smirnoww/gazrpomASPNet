using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StationeryProject.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace StationeryProject.Controllers
{
    public class HomeController : Controller
        {
        public StationeryContext _db;
        public HomeController(StationeryContext db)
        {
            //string connectString = configuration.GetConnectionString("DefaultConnection");
            _db = db;
           
        }

        [Authorize]
        public IActionResult Index()
        {
            var users = from i in _db.SprUser select i;
            var products = from i in _db.SprProduct select i;

            ViewBag.usersCol = users;
            ViewBag.productsCol = products;

            return View();
        }   //  Index()


        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddRequest(UserProductRequest upr)
        {
            if (ModelState.IsValid)
            {

                _db.UserProductRequest.Add(upr);

                _db.SaveChanges();

                var request = from
                                r in _db.UserProductRequest
                              join u in _db.SprUser on r.UserId equals u.Id
                              join p in _db.SprProduct on r.ProductId equals p.Id
                              select
                                  new { r.Id, u.FirstName, u.LastName, p.ProductName, r.ProductAmount };
                request = request.Where(r => r.Id == upr.Id);

                upr.setProductName(request.First().ProductName);
                upr.setUserName(request.First().FirstName + " " + request.First().LastName);

                return View(upr);
            }
            else
            {
                var users = from i in _db.SprUser select i;
                var products = from i in _db.SprProduct select i;

                ViewBag.usersCol = users;
                ViewBag.productsCol = products;

                return View("Index");
            }

        }   //  AddRequest()

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

﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StationeryProject.Models;
using Microsoft.Extensions.Configuration;


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


        public IActionResult Index()
        {
            var users = from i in _db.SprUser select i;
            var products = from i in _db.SprProduct select i;

            ViewBag.usersCol = users;
            ViewBag.productsCol = products;

            return View();
        }   //  Index()


        [HttpPost]
        public IActionResult AddRequest(long UserId, long ProductId, int amount)
        {
            UserProductRequest upr = new UserProductRequest(_db);

            upr.UserId = UserId;
            upr.ProductId = ProductId;
            upr.ProductAmount = amount;

            _db.UserProductRequest.Add(upr);

            _db.SaveChanges();

/* Эта функциональность перенесена в модель UserProductRequest
            var request = from
                            r in _db.UserProductRequest
                            join u in _db.SprUser on r.UserId equals u.Id
                            join p in _db.SprProduct on r.ProductId equals p.Id
                          select
                              new { r.Id, u.LastName, p.ProductName, r.ProductAmount };
            request = request.Where(r => r.Id == upr.Id);
*/

            return View(upr);

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

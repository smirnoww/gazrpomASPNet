﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace helloWorlld.Controllers
{
    public class HomeController : baseController
    {

        public IActionResult Index()
        {
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
            
            return View();
        }

        public VirtualFileResult GetCat() {
            var filepath = Path.Combine("~/Images", "cat.jpg");
            return File(filepath,"image/jpeg");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MiddlewareDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("/ErrorPages/{code:int}")]
        public IActionResult StatusCodePagesWithRedirects(int code)
        {
            ViewData["code"]=code;
            return View();
        }

        public IActionResult ErrorPage(int? code)
        {
            int _code = 0;
            if(code.HasValue)
            {
                ViewBag.code = code.Value;
            }
            else
            {
                ViewBag.code = _code;
            }
            return View();
        }
    }
}
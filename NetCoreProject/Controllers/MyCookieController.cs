using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreProject.Controllers
{
    public class MyCookieController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Response.Cookies.Append(
                "haha", 
                "哈哈", 
                new CookieOptions()
                {
                     Expires=DateTime.Now.AddMinutes(5)
                });
            return View();
        }
    }
}
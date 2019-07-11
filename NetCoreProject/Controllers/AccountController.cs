using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace NetCoreProject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            var claims = new List<Claim>
            {
               // new Claim("")
            };
            return View();
        }
    }
}
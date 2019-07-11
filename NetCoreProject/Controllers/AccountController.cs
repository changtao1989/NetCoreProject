using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace NetCoreProject.Controllers
{
    public class AccountController : Controller
    {
        public async Task<IActionResult> Login()
        {
            //基本信息
            var claims = new List<Claim>
            {
               new Claim(ClaimTypes.Name,"changfutao"),
               new Claim(ClaimTypes.Role,"admin")
            };
            //身份证
            var claimsIdentity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            //写入Cookie
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity));

            return Ok();
        }

        public async Task<IActionResult> LoginOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}
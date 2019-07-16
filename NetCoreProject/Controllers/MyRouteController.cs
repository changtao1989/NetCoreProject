using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreProject.Controllers
{
    public class MyRouteController : Controller
    {
        /*
        默认传统路由{controller=Home}/{action=Index}/{id?} 
        Web API应使用属性路由,将应用功能建模为一组资源，其中操作是由HTTP谓词表示。
        路由使用"终结点"(Endpoint)来表示应用中的逻辑终结点     
        */
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public string Article()
        {
            return "Article";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace NetCoreProject.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public String Index()
        {
            return "Index";
        }
    }
}
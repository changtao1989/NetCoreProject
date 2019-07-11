using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace NetCoreProject.Controllers
{
    [Route("[controller]")]
    public class EnvironmentController : Controller
    {
        private IConfiguration _configuration;
        public EnvironmentController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            var val=this._configuration["Environment"].ToString();
            return View("Index",val);
        }
    }
}
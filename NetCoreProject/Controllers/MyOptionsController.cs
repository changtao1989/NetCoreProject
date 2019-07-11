using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NetCoreProject.Models;

namespace NetCoreProject.Controllers
{
    public class MyOptionsController : Controller
    {
        private IConfiguration _configuration;
        private Person _personOption;
        private Person _personOption1;
        public MyOptionsController(IConfiguration configuration,Person personOption,IOptionsSnapshot<Person>optionsSnapshot)
        {
            this._configuration = configuration;
            this._personOption = personOption;
            this._personOption1 = optionsSnapshot.Value;
        }
        public IActionResult Index()
        {
            return View();
        }

        public string GetKey()
        {
            //1.IConfiguration.GetValue方式读取节点的内容
            string key1 = this._configuration.GetValue<string>("Key");
            //2.IConfiguration["Key"]读取节点的内容
            string key2 = this._configuration["Key"];
            return key1+" "+key2;
        }

        public string GetKey1()
        {
            //1.IConfiguration.GetValue方式读取节点的内容,如果有子节点通过:
            string key1 = this._configuration.GetValue<string>("ASP.NET:Name1");
            //2.IConfiguration["Key"]读取节点的内容
            string key2 = this._configuration["ASP.NET:Name2"];
            return key1 + " " + key2;
        }

        public string GetPerson()
        {
            return this._personOption.Name +" "+_personOption.Age.ToString();
        }

        public string GetPerson1()
        {
            return this._personOption1.Name + " " + _personOption1.Age.ToString();
        }
    }
}
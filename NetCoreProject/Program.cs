using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NetCoreProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) => 
                {
                    builder
                           .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json")
                           //第二个参数 是否文件必须存在 第三个参数 如果文件有变更，会更新但web不会重新启动
                           .AddJsonFile($"Configs/config.json",true,true);
                })
                .UseStartup<Startup>();
    }
}

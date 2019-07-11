using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreProject
{
    public class Startup
    {
       
        public void ConfigureServices(IServiceCollection services)
        {
            //在ASP.NET Core2.2中使用最新路由方案，需要为MVC服务注册指定兼容性版本
            services.AddMvc()
                    .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //在launchSettings.json里配置了环境变量，可以通过IsEnvironment方法调用
            if (env.IsEnvironment("UAT"))
            {

            }

            app.UseMvcWithDefaultRoute();
        }
    }
}
